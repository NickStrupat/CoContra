using System;
using System.Collections.Immutable;

namespace CoContra {
	public abstract class CoContravariantDelegateBase<TDelegate, TDerived> : IEquatable<TDerived>
	where TDelegate : class
	where TDerived : CoContravariantDelegateBase<TDelegate, TDerived> {
		private ImmutableArray<TDelegate> array;

		internal CoContravariantDelegateBase() { array = ImmutableArray<TDelegate>.Empty; }
		internal CoContravariantDelegateBase(TDelegate @delegate) : this() { Add(@delegate); }

		public abstract Object DynamicInvoke(params Object[] args);

		public ImmutableArray<TDelegate> GetInvocationList() => InterlockedGet(ref array);

		protected void Add(TDelegate @delegate) {
			if (@delegate == null)
				return;

			ImmutableArray<TDelegate> initial, computed;
			do {
				initial = GetInvocationList();
				computed = initial.Add(@delegate);
			}
			while (initial != ImmutableInterlocked.InterlockedCompareExchange(ref array, computed, initial));
		}

		protected void Remove(TDelegate @delegate) {
			if (@delegate == null)
				return;

			ImmutableArray<TDelegate> initial, computed;
			do {
				initial = GetInvocationList();
				computed = initial.Remove(@delegate);
			}
			while (initial != ImmutableInterlocked.InterlockedCompareExchange(ref array, computed, initial));
		}

		public override Boolean Equals(Object obj) => array.Equals(obj);
		public override Int32 GetHashCode() => array.GetHashCode();
		public Boolean Equals(TDerived other) => other != null && array.Equals(other.array);

		protected TDelegate GetSingleOrNull() {
			var invocationList = GetInvocationList();
			return invocationList.Length == 1 ? invocationList[0] : null;
		}

		private static ImmutableArray<TDelegate> InterlockedGet(ref ImmutableArray<TDelegate> array) {
			return ImmutableInterlocked.InterlockedCompareExchange(ref array, ImmutableArray<TDelegate>.Empty, ImmutableArray<TDelegate>.Empty);
		}
	}
}