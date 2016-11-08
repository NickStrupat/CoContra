using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace CoContra {
	/// <summary>Represents a delegate, which is a data structure that refers to a static method or to a class instance and an instance method of that class.</summary>
	public abstract class CoContravariantDelegateBase<TDelegate, TDerived> : CoContravariantDelegate, IEquatable<TDerived>
	where TDelegate : class
	where TDerived : CoContravariantDelegateBase<TDelegate, TDerived>, new() {
		private ImmutableArray<TDelegate> array;

		internal CoContravariantDelegateBase() { array = ImmutableArray<TDelegate>.Empty; }
		internal CoContravariantDelegateBase(TDerived other) { array = other.array; }
		internal CoContravariantDelegateBase(TDelegate @delegate) { array = ImmutableArray<TDelegate>.Empty.Add(@delegate); }
		
		private static readonly MethodInfo invokeMethodInfo = typeof(TDerived).GetMethod(nameof(CovariantAction<Object>.Invoke));
		protected static TDerived TryUnwrapDelegate(MethodInfo method, Object target) => method != invokeMethodInfo ? null : target as TDerived;
		
		internal override ImmutableArray<Delegate> GetInvocationListInternal() => GetInvocationList().CastArray<Delegate>();
		public new ImmutableArray<TDelegate> GetInvocationList() => InterlockedGet(ref array);

		public void Add(TDelegate @delegate) {
			if (@delegate == null)
				return;

			ImmutableArray<TDelegate> initial, computed;
			do {
				initial = GetInvocationList();
				computed = initial.Add(@delegate);
			}
			while (initial != ImmutableInterlocked.InterlockedCompareExchange(ref array, computed, initial));
		}

		public void Remove(TDelegate @delegate) {
			if (@delegate == null)
				return;

			ImmutableArray<TDelegate> initial, computed;
			do {
				initial = GetInvocationList();
				computed = RemoveLast(initial, @delegate);
			}
			while (initial != ImmutableInterlocked.InterlockedCompareExchange(ref array, computed, initial));
		}

		/// <summary>Determines whether the specified object and the current delegate are of the same type and share the same targets, methods, and invocation list.</summary>
		/// <returns>true if <paramref name="obj" /> and the current delegate have the same targets, methods, and invocation list; otherwise, false.</returns>
		/// <param name="obj">The object to compare with the current delegate.</param>
		public override Boolean Equals(Object obj) => Equals(obj as TDerived);

		/// <summary>Returns a hash code for the delegate.</summary>
		/// <returns>A hash code for the delegate.</returns>
		public override Int32 GetHashCode() => array.GetHashCode();

		/// <summary>Determines whether the specified object and the current delegate are of the same type and share the same targets, methods, and invocation list.</summary>
		/// <returns>true if <paramref name="obj" /> and the current delegate have the same targets, methods, and invocation list; otherwise, false.</returns>
		/// <param name="obj">The object to compare with the current delegate.</param>
		public Boolean Equals(TDerived other) => other != null && (array.Equals(other.array) || array.SequenceEqual(other.array));

		private static ImmutableArray<TDelegate> InterlockedGet(ref ImmutableArray<TDelegate> array) {
			return ImmutableInterlocked.InterlockedCompareExchange(ref array, ImmutableArray<TDelegate>.Empty, ImmutableArray<TDelegate>.Empty);
		}

		internal override CoContravariantDelegate CombineInternal(Delegate d) => Combine(this as TDerived, d as TDelegate);
		internal override CoContravariantDelegate CombineInternal(CoContravariantDelegate ccd) => Combine(this as TDerived, ccd as TDerived);
		internal override CoContravariantDelegate CombineInternal(params CoContravariantDelegate[] ccds) => Combine(this as TDerived, ccds as TDerived[]);
		internal override CoContravariantDelegate CombineInternal(params Delegate[] ds) => Combine(this as TDerived, ds as TDelegate[]);

		internal override CoContravariantDelegate RemoveInternal(Delegate d) => Remove(this as TDerived, d as TDelegate);
		internal override CoContravariantDelegate RemoveInternal(CoContravariantDelegate ccd2) => Remove(this as TDerived, ccd2 as TDerived);

		internal override CoContravariantDelegate RemoveAllInternal(Delegate d) => RemoveAll(this as TDerived, d as TDelegate);
		internal override CoContravariantDelegate RemoveAllInternal(CoContravariantDelegate ccd2) => RemoveAll(this as TDerived, ccd2 as TDerived);

		private static ImmutableArray<TDelegate> RemoveLast(ImmutableArray<TDelegate> source, TDelegate value) {
			var list = source;
			var index = list.LastIndexOf(value);
			if (index >= 0)
				return list.RemoveAt(index);
			return list;
		}

		public static TDerived Combine(TDerived ccd, TDelegate @delegate) {
			if (ccd == null)
				throw new ArgumentNullException(nameof(ccd));
			if (@delegate == null)
				throw new ArgumentNullException(nameof(@delegate));

			return new TDerived {
				array = ccd.array.AddRange(((Delegate)(Object)@delegate).GetInvocationList().Cast<TDelegate>())
			};
		}

		public static TDerived Combine(TDerived d1, TDerived d2) {
			if (d1 == null)
				throw new ArgumentNullException(nameof(d1));
			if (d2 == null)
				throw new ArgumentNullException(nameof(d2));

			return new TDerived {
				array = d1.array.AddRange(d2.array)
			};
		}

		public static TDerived Combine(TDerived ccd1, params TDerived[] ccds) {
			if (ccd1 == null)
				throw new ArgumentNullException(nameof(ccd1));
			if (ccds == null)
				throw new ArgumentNullException(nameof(ccds));

			var x = new TDerived { array = ccd1.array };
			foreach (var ccd in ccds)
				x.array = x.array.AddRange(ccd.array);
			return x;
		}

		public static TDerived Combine(TDerived ccd, params TDelegate[] delegates) {
			if (ccd == null)
				throw new ArgumentNullException(nameof(ccd));
			if (delegates == null)
				throw new ArgumentNullException(nameof(delegates));

			var x = new TDerived { array = ccd.array };
			foreach (var @delegate in delegates)
				x.array = x.array.AddRange(((Delegate) (Object) @delegate).GetInvocationList().Cast<TDelegate>());
			return x;
		}

		public static TDerived Remove(TDerived source, TDelegate value) {
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return new TDerived {
				array = RemoveLast(source.array, value)
			};
		}

		public static TDerived Remove(TDerived source, TDerived value) {
			if (source == null)
				return null;
			if (value == null)
				return source;

			var lastIndexOfEndOfValueInvocationList = -1;
			var sourceArray = source.array;
			var valueArray = value.array;
			var valueArrayLength = valueArray.Length;

			var upperLimit = sourceArray.Length - valueArrayLength;
			for (var i = 0; i != upperLimit; ++i) {
				if (sourceArray.Reverse().Skip(i).Take(valueArrayLength).SequenceEqual(valueArray.Reverse())) {
					lastIndexOfEndOfValueInvocationList = i;
					break;
				}
			}
			if (lastIndexOfEndOfValueInvocationList == -1)
				return source;

			return new TDerived {
				array = sourceArray.RemoveRange(lastIndexOfEndOfValueInvocationList - valueArrayLength, valueArrayLength)
			};
		}

		public static TDerived RemoveAll(TDerived source, TDelegate value) {
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			var list = source.array;
			for (;;) {
				var index = list.LastIndexOf(value);
				if (index < 0)
					break;
				list = list.RemoveAt(index);
			}
			return new TDerived { array = list };
		}
	}
}