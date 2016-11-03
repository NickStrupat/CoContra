using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace CoContra {
#if NET4
	internal static class ReflectionExtensions {
		public static MethodInfo GetMethodInfo(this Delegate del) => del.Method;
	}
#endif

	/// <summary>Represents a delegate, which is a data structure that refers to a static method or to a class instance and an instance method of that class.</summary>
	public abstract class CoContravariantDelegateBase<TDelegate, TDerived> : IEquatable<TDerived>
	where TDelegate : class
	where TDerived : CoContravariantDelegateBase<TDelegate, TDerived> {
		private ImmutableArray<TDelegate> array;

		internal CoContravariantDelegateBase() { array = ImmutableArray<TDelegate>.Empty; }
		internal CoContravariantDelegateBase(TDelegate @delegate) : this() { Add(@delegate); }
		
		private static readonly MethodInfo invokeMethodInfo = typeof(TDerived).GetMethod(nameof(CovariantAction<Object>.Invoke));
		protected static TDerived TryUnwrapDelegate(MethodInfo method, Object target) => method != invokeMethodInfo ? null : target as TDerived;

		/// <summary>Dynamically invokes (late-bound) the method represented by the current delegate.</summary>
		/// <returns>The object returned by the method represented by the delegate.</returns>
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
	}
}