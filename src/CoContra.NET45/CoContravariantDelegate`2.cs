using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace CoContra {
	/// <summary>Represents a delegate, which is a data structure that refers to a static method or to a class instance and an instance method of that class.</summary>
	public abstract class CoContravariantDelegate<TDelegate, TDerived> : CoContravariantDelegate, IEquatable<TDerived>
	where TDelegate : class
	where TDerived : CoContravariantDelegate<TDelegate, TDerived>, new() {
		private ImmutableArray<TDelegate> array;

		internal CoContravariantDelegate() { array = ImmutableArray<TDelegate>.Empty; }
		internal CoContravariantDelegate(TDerived other) { array = other.array; }
		internal CoContravariantDelegate(TDelegate @delegate) { SetArray(out array, @delegate); }

		private static void SetArray(out ImmutableArray<TDelegate> array, TDelegate @delegate) => array = ImmutableArray.CreateRange(GetDelegateInvocationList(@delegate));
		private static TDerived MakeDerived(TDelegate @delegate) {
			var d = new TDerived();
			SetArray(out d.array, @delegate);
			return d;
		}

		public static TDerived operator +(CoContravariantDelegate<TDelegate, TDerived> ccd, TDelegate d) => Combine((TDerived) ccd, ConvertToCoContravariantDelegate(d));
		public static TDerived operator -(CoContravariantDelegate<TDelegate, TDerived> ccd, TDelegate d) => Remove((TDerived) ccd, ConvertToCoContravariantDelegate(d));
		public static TDerived operator +(CoContravariantDelegate<TDelegate, TDerived> ccd, TDerived ccd2) => Combine((TDerived) ccd, ccd2);
		public static TDerived operator -(CoContravariantDelegate<TDelegate, TDerived> ccd, TDerived ccd2) => Remove((TDerived) ccd, ccd2);
		public static Boolean operator ==(CoContravariantDelegate<TDelegate, TDerived> left, TDerived right) => (((TDerived) left)?.Equals(right)).GetValueOrDefault();
		public static Boolean operator !=(CoContravariantDelegate<TDelegate, TDerived> left, TDerived right) => !((TDerived) left == right);

		private static readonly MethodInfo invokeMethodInfo = typeof(TDerived).GetMethod(nameof(CovariantAction<Object>.Invoke));
		private static TDerived TryUnwrapDelegate(Delegate @delegate) => @delegate == null || @delegate.GetMethodInfo() != invokeMethodInfo ? null : @delegate.Target as TDerived;

		protected static TDerived ConvertToCoContravariantDelegate(TDelegate @delegate) => TryUnwrapDelegate(@delegate as Delegate) ?? MakeDerived(@delegate);

		internal sealed override ImmutableArray<Delegate> GetInvocationListInternal() => GetInvocationList().CastArray<Delegate>();
		public new ImmutableArray<TDelegate> GetInvocationList() => InterlockedGet(ref array);

		private static ImmutableArray<TDelegate> InterlockedGet(ref ImmutableArray<TDelegate> array) {
			return ImmutableInterlocked.InterlockedCompareExchange(ref array, ImmutableArray<TDelegate>.Empty, ImmutableArray<TDelegate>.Empty);
		}

		public void Add(TDelegate @delegate) {
			if (@delegate == null)
				return;

			ImmutableArray<TDelegate> initial, computed;
			do {
				initial = GetInvocationList();
				computed = CombineInvocationLists(initial, GetDelegateInvocationList(@delegate));
			}
			while (initial != ImmutableInterlocked.InterlockedCompareExchange(ref array, computed, initial));
		}

		public void Remove(TDelegate @delegate) {
			if (@delegate == null)
				return;

			ImmutableArray<TDelegate> initial, computed;
			do {
				initial = GetInvocationList();
				computed = RemoveLast(initial, GetDelegateInvocationList(@delegate));
			}
			while (initial != ImmutableInterlocked.InterlockedCompareExchange(ref array, computed, initial));
		}

		/// <summary>Determines whether the specified object and the current delegate are of the same type and share the same targets, methods, and invocation list.</summary>
		/// <returns>true if <paramref name="obj" /> and the current delegate have the same targets, methods, and invocation list; otherwise, false.</returns>
		/// <param name="obj">The object to compare with the current delegate.</param>
		public sealed override Boolean Equals(Object obj) => Equals(obj as TDerived);

		/// <summary>Returns a hash code for the delegate.</summary>
		/// <returns>A hash code for the delegate.</returns>
		public sealed override Int32 GetHashCode() => array.GetHashCode();

		/// <summary>Determines whether the specified object and the current delegate are of the same type and share the same targets, methods, and invocation list.</summary>
		/// <returns>true if <paramref name="other" /> and the current delegate have the same targets, methods, and invocation list; otherwise, false.</returns>
		/// <param name="other">The object to compare with the current delegate.</param>
		public Boolean Equals(TDerived other) => !ReferenceEquals(other, null) && (array.Equals(other.array) || array.SequenceEqual(other.array));

		internal sealed override CoContravariantDelegate CombineInternal(CoContravariantDelegate ccd)           => CombineImpl((TDerived) this, (TDerived) ccd);
		internal sealed override CoContravariantDelegate CombineInternal(params CoContravariantDelegate[] ccds) => CombineImpl((TDerived[]) ccds);
		internal sealed override CoContravariantDelegate RemoveInternal(CoContravariantDelegate ccd)            => RemoveImpl((TDerived) this, (TDerived) ccd);
		internal sealed override CoContravariantDelegate RemoveAllInternal(CoContravariantDelegate ccd)         => RemoveAllImpl((TDerived) this, (TDerived) ccd);

		private static ImmutableArray<TDelegate> GetDelegateInvocationList(TDelegate @delegate) => ((Delegate) (Object) @delegate).GetInvocationList().Cast<TDelegate>().ToImmutableArray();

		private static ImmutableArray<TDelegate> CombineInvocationLists(ImmutableArray<TDelegate> source, ImmutableArray<TDelegate> invocationList) {
			var capacity = source.Length + invocationList.Length;
			var builder = ImmutableArray.CreateBuilder<TDelegate>(capacity);
			builder.AddRange(source);
			builder.AddRange(invocationList);
			return builder.ToImmutable();
		}

		private static ImmutableArray<TDelegate> CombineInvocationLists(ImmutableArray<TDelegate>[] invocationLists) {
			var capacity = invocationLists.Sum(x => x.Length);
			var builder = ImmutableArray.CreateBuilder<TDelegate>(capacity);
			foreach (var invocationList in invocationLists)
				builder.AddRange(invocationList);
			return builder.ToImmutable();
		}

		private static ImmutableArray<T> RemoveLast<T>(ImmutableArray<T> source, ImmutableArray<T> invocationList) {
			var index = ReverseSearch(source, invocationList);
			if (index == -1)
				return source;
			return source.RemoveRange(index, invocationList.Length);
		}

		private static Int32 ReverseSearch<T>(ImmutableArray<T> haystack, ImmutableArray<T> needle) {
			for (var i = haystack.Length - needle.Length; i >= 0; i--) {
				if (Match(haystack, needle, i))
					return i;
			}
			return -1;
		}

		private static Boolean Match<T>(ImmutableArray<T> haystack, ImmutableArray<T> needle, Int32 start) {
			if (needle.Length + start > haystack.Length)
				return false;
			for (var i = 0; i < needle.Length; i++) {
				if (!needle[i].Equals(haystack[i + start]))
					return false;
			}
			return true;
		}



		private static TDerived CombineImpl(TDerived ccd, TDerived ccd2) {
			if (ReferenceEquals(ccd2, null))
				return ccd;
			return new TDerived {
				array = CombineInvocationLists(ccd.GetInvocationList(), ccd2.GetInvocationList())
			};
		}

		private static TDerived CombineImpl(params TDerived[] ccds) {
			return new TDerived {
				array = CombineInvocationLists(ccds.Select(x => x.GetInvocationList()).ToArray())
			};
		}

		private static TDerived RemoveImpl(TDerived ccd, TDerived ccd2) {
			if (ReferenceEquals(ccd2, null))
				return ccd;
			return new TDerived {
				array = RemoveLast(ccd.GetInvocationList(), ccd2.GetInvocationList())
			};
		}

		private static TDerived RemoveAllImpl(TDerived ccd, TDerived ccd2) {
			if (ReferenceEquals(ccd2, null))
				return ccd;
			var sourceInvocationList = ccd.GetInvocationList();
			ImmutableArray<TDelegate> temp;
			do {
				temp = RemoveLast(sourceInvocationList, ccd2.GetInvocationList());
			}
			while (temp != sourceInvocationList);
			return new TDerived { array = temp };
		}



		public static TDerived Combine(TDerived ccd, TDerived ccd2)   => (TDerived) CoContravariantDelegate.Combine(ccd, ccd2);
		public static TDerived Combine(params TDerived[] ccds)        => (TDerived) CoContravariantDelegate.Combine(ccds);
		public static TDerived Remove(TDerived ccd, TDerived ccd2)    => (TDerived) CoContravariantDelegate.Remove(ccd, ccd2);
		public static TDerived RemoveAll(TDerived ccd, TDerived ccd2) => (TDerived) CoContravariantDelegate.RemoveAll(ccd, ccd2);
	}
}