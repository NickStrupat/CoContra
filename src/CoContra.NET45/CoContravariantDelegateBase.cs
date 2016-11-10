using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace CoContra {
	/// <summary>Represents a delegate, which is a data structure that refers to a static method or to a class instance and an instance method of that class.</summary>
	public abstract class CoContravariantDelegateBase<TDelegate, TDerived> : CoContravariantDelegate, IEquatable<TDerived>
	where TDelegate : class
	where TDerived : CoContravariantDelegateBase<TDelegate, TDerived>, new() {
		private ImmutableArray<TDelegate> array;

		internal CoContravariantDelegateBase() { array = ImmutableArray<TDelegate>.Empty; }
		internal CoContravariantDelegateBase(TDerived other) { array = other.array; }
		internal CoContravariantDelegateBase(TDelegate @delegate) { array = CombineInvocationLists(ImmutableArray<TDelegate>.Empty, GetDelegateInvocationList(@delegate)); }
		
		private static readonly MethodInfo invokeMethodInfo = typeof(TDerived).GetMethod(nameof(CovariantAction<Object>.Invoke));
		protected static TDerived TryUnwrapDelegate(MethodInfo method, Object target) => method != invokeMethodInfo ? null : target as TDerived;
		
		internal sealed override ImmutableArray<Delegate> GetInvocationListInternal() => GetInvocationList().CastArray<Delegate>();
		public new ImmutableArray<TDelegate> GetInvocationList() => InterlockedGet(ref array);

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
		/// <returns>true if <paramref name="obj" /> and the current delegate have the same targets, methods, and invocation list; otherwise, false.</returns>
		/// <param name="obj">The object to compare with the current delegate.</param>
		public Boolean Equals(TDerived other) => other != null && (array.Equals(other.array) || array.SequenceEqual(other.array));

		private static ImmutableArray<TDelegate> InterlockedGet(ref ImmutableArray<TDelegate> array) {
			return ImmutableInterlocked.InterlockedCompareExchange(ref array, ImmutableArray<TDelegate>.Empty, ImmutableArray<TDelegate>.Empty);
		}

		internal sealed override CoContravariantDelegate CombineInternal(Delegate d)                            => Combine((TDerived) this, d   .CastDelegate<TDelegate>  (nameof(d)));
		internal sealed override CoContravariantDelegate CombineInternal(CoContravariantDelegate ccd)           => Combine((TDerived) this, ccd .CastDelegate<TDerived>   (nameof(ccd)));
		internal sealed override CoContravariantDelegate CombineInternal(params CoContravariantDelegate[] ccds) => Combine((TDerived) this, ccds.CastDelegate<TDerived[]> (nameof(ccds)));
		internal sealed override CoContravariantDelegate CombineInternal(params Delegate[] ds)                  => Combine((TDerived) this, ds  .CastDelegate<TDelegate[]>(nameof(ds)));

		internal sealed override CoContravariantDelegate RemoveInternal(Delegate d)                   => Remove((TDerived) this, d   .CastDelegate<TDelegate>(nameof(d)));
		internal sealed override CoContravariantDelegate RemoveInternal(CoContravariantDelegate ccd2) => Remove((TDerived) this, ccd2.CastDelegate<TDerived> (nameof(ccd2)));

		internal sealed override CoContravariantDelegate RemoveAllInternal(Delegate d)                   => RemoveAll((TDerived) this, d   .CastDelegate<TDelegate>(nameof(d)));
		internal sealed override CoContravariantDelegate RemoveAllInternal(CoContravariantDelegate ccd2) => RemoveAll((TDerived) this, ccd2.CastDelegate<TDerived> (nameof(ccd2)));

		private static TDelegate[] GetDelegateInvocationList(TDelegate @delegate) => ((Delegate) (Object) @delegate).GetInvocationList().Cast<TDelegate>().ToArray();

		private static ImmutableArray<TDelegate> CombineInvocationLists(ImmutableArray<TDelegate> source, params ICollection<TDelegate>[] invocationLists) {
			var capacity = invocationLists.Sum(x => x.Count);
			var builder = ImmutableArray.CreateBuilder<TDelegate>(capacity);
			builder.AddRange(source);
			foreach (var invocationList in invocationLists)
				builder.AddRange(invocationList);
			return builder.ToImmutable();
		}

		private static ImmutableArray<TDelegate> RemoveLast(ImmutableArray<TDelegate> source, ICollection<TDelegate> invocationList) {
			if (invocationList.Count > source.Length)
				return source;
			var lastIndexOfEndOfValueInvocationList = -1;
			for (var i = source.Length - invocationList.Count; i != 0; i--) {
				if (source.Skip(i).Take(invocationList.Count).SequenceEqual(invocationList)) {
					lastIndexOfEndOfValueInvocationList = i;
					break;
				}
			}
			if (lastIndexOfEndOfValueInvocationList == -1)
				return source;
			return source.RemoveRange(lastIndexOfEndOfValueInvocationList, invocationList.Count);
		}



		public static TDerived Combine(TDerived ccd, TDelegate @delegate) {
			if (ccd == null)
				throw new ArgumentNullException(nameof(ccd));
			if (@delegate == null)
				throw new ArgumentNullException(nameof(@delegate));
			return new TDerived {
				array = CombineInvocationLists(ccd.GetInvocationList(), GetDelegateInvocationList(@delegate))
			};
		}

		public static TDerived Combine(TDerived d1, TDerived d2) {
			if (d1 == null)
				throw new ArgumentNullException(nameof(d1));
			if (d2 == null)
				throw new ArgumentNullException(nameof(d2));
			return new TDerived {
				array = CombineInvocationLists(d1.GetInvocationList(), d2.GetInvocationList())
			};
		}

		public static TDerived Combine(TDerived ccd1, params TDerived[] ccds) {
			if (ccd1 == null)
				throw new ArgumentNullException(nameof(ccd1));
			if (ccds == null)
				throw new ArgumentNullException(nameof(ccds));
			var invocationLists = ccds.Select(x => x.GetInvocationList().ToArray()).ToArray();
			return new TDerived {
				array = CombineInvocationLists(ccd1.GetInvocationList(), invocationLists)
			};
		}

		public static TDerived Combine(TDerived ccd, params TDelegate[] delegates) {
			if (ccd == null)
				throw new ArgumentNullException(nameof(ccd));
			if (delegates == null)
				throw new ArgumentNullException(nameof(delegates));
			var invocationLists = delegates.Select(GetDelegateInvocationList).ToArray();
			return new TDerived {
				array = CombineInvocationLists(ccd.GetInvocationList(), invocationLists)
			};
		}

		public static TDerived Remove(TDerived source, TDelegate value) {
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			return new TDerived {
				array = RemoveLast(source.GetInvocationList(), GetDelegateInvocationList(value))
			};
		}

		public static TDerived Remove(TDerived source, TDerived value) {
			if (source == null)
				return null;
			if (value == null)
				return source;
			return new TDerived {
				array = RemoveLast(source.GetInvocationList(), value.GetInvocationList())
			};
		}

		public static TDerived RemoveAll(TDerived source, TDelegate value) {
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			var sourceInvocationList = source.GetInvocationList();
			ImmutableArray<TDelegate> temp;
			do {
				temp = RemoveLast(sourceInvocationList, GetDelegateInvocationList(value));
			}
			while (temp != sourceInvocationList);
			return new TDerived { array = temp };
		}
	}
}