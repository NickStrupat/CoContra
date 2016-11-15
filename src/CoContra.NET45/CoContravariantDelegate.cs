using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace CoContra {
	public abstract class CoContravariantDelegate {
		internal CoContravariantDelegate() {}

		public sealed override String ToString() => base.ToString();

		/// <summary>Gets the class instance on which the current delegate invokes the instance method.</summary>
		/// <returns>The object on which the current delegate invokes the instance method, if the delegate represents an instance method; null if the delegate represents a static method.</returns>
		public Object Target => GetInvocationList().LastOrDefault()?.Target;

#if NET4 || NET45
		/// <summary>Gets the method represented by the delegate.</summary>
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		/// <summary>Gets an object that represents the method represented by the specified delegate.</summary>
		/// <returns>An object that represents the method.</returns>
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		/// <summary>Dynamically invokes (late-bound) the method represented by the current delegate.</summary>
		/// <returns>The object returned by the method represented by the delegate.</returns>
		public Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}


		internal abstract ImmutableArray<Delegate> GetInvocationListInternal();

		public ImmutableArray<Delegate> GetInvocationList() => GetInvocationListInternal();

		internal abstract CoContravariantDelegate CombineInternal(CoContravariantDelegate ccd);
		internal abstract CoContravariantDelegate CombineInternal(params CoContravariantDelegate[] ccds);
		internal abstract CoContravariantDelegate RemoveInternal(CoContravariantDelegate ccd);
		internal abstract CoContravariantDelegate RemoveAllInternal(CoContravariantDelegate ccd);

		public static CoContravariantDelegate Combine(CoContravariantDelegate ccd, CoContravariantDelegate ccd2)   => ReferenceEquals(ccd, null) ? ccd2 : ccd.CombineInternal(ccd2);
		public static CoContravariantDelegate Combine(params CoContravariantDelegate[] ccds)                       => ccds?.FirstOrDefault()?.CombineInternal(ccds);
		public static CoContravariantDelegate Remove(CoContravariantDelegate ccd, CoContravariantDelegate ccd2)    => ccd?.RemoveInternal(ccd2);
		public static CoContravariantDelegate RemoveAll(CoContravariantDelegate ccd, CoContravariantDelegate ccd2) => ccd?.RemoveAllInternal(ccd2);
	}

	internal static class CoContravariantDelegateHelperExtensions {
		public static T CheckNull<T>(this T value, String paramName) {
			if (value == null)
				throw new ArgumentNullException(paramName);
			return value;
		}

		public static T CastDelegate<T>(this Object @object, String paramName = null) where T : class {
			if (@object == null)
				return null;
			var x = @object as T;
			if (x == null)
				throw new ArgumentException("The delegate types do not match", paramName);
			return x;
		}
	}
}