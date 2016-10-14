using System;
using System.Collections;
using System.Collections.Immutable;

namespace CoContra {
	public abstract class CoContravariantDelegateBase<TDelegate> : IEquatable<CoContravariantDelegateBase<TDelegate>>, IStructuralComparable, IStructuralEquatable where TDelegate : class {
		private ImmutableArray<TDelegate> array = ImmutableArray<TDelegate>.Empty;

		protected CoContravariantDelegateBase(TDelegate @delegate) {
			Add(@delegate);
		}

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

		public override Boolean Equals(Object obj) => array.Equals(obj);
		public override Int32 GetHashCode() => array.GetHashCode();
		public Boolean Equals(CoContravariantDelegateBase<TDelegate> other) => other != null && array.Equals(other.array);

		Int32 IStructuralComparable.CompareTo(Object other, IComparer comparer) => ((IStructuralComparable) array).CompareTo(other, comparer);
		Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer) => ((IStructuralEquatable) array).Equals(other, comparer);
		Int32 IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => ((IStructuralEquatable) array).GetHashCode(comparer);

		protected TDelegate GetSingleOrNull() {
			var invocationList = GetInvocationList();
			return invocationList.Length == 1 ? invocationList[0] : null;
		}

		private static ImmutableArray<TDelegate> InterlockedGet(ref ImmutableArray<TDelegate> array) {
			return ImmutableInterlocked.InterlockedCompareExchange(ref array, ImmutableArray<TDelegate>.Empty, ImmutableArray<TDelegate>.Empty);
		}
	}
}