using System;
using System.Collections.Immutable;
using System.Linq;

namespace CoContra {
	public abstract class CoContravariantDelegateBase<TDelegate, TDerived> : IEquatable<TDerived>
	where TDelegate : class
	where TDerived : CoContravariantDelegateBase<TDelegate, TDerived> {
		private ImmutableArray<TDelegate> array;

		internal CoContravariantDelegateBase() { array = ImmutableArray<TDelegate>.Empty; }
		internal CoContravariantDelegateBase(TDelegate @delegate) : this() { Add(@delegate); }

		public abstract Object DynamicInvoke(params Object[] args);

		public ImmutableArray<TDelegate> GetInvocationList() => InterlockedGet(ref array);

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
				computed = initial.Remove(@delegate);
			}
			while (initial != ImmutableInterlocked.InterlockedCompareExchange(ref array, computed, initial));
		}

		public override Boolean Equals(Object obj) => Equals(obj as TDerived);
		public override Int32 GetHashCode() => array.GetHashCode();
		public Boolean Equals(TDerived other) => other != null && (array.Equals(other.array) || array.SequenceEqual(other.array));

		private static ImmutableArray<TDelegate> InterlockedGet(ref ImmutableArray<TDelegate> array) {
			return ImmutableInterlocked.InterlockedCompareExchange(ref array, ImmutableArray<TDelegate>.Empty, ImmutableArray<TDelegate>.Empty);
		}
	}
}