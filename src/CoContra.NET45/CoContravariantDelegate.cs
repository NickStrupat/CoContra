using System;
using System.Collections.Immutable;
using System.Reflection;

namespace CoContra {
	public abstract class CoContravariantDelegate {
		internal CoContravariantDelegate() {}

		/// <summary>Gets the class instance on which the current delegate invokes the instance method.</summary>
		/// <returns>The object on which the current delegate invokes the instance method, if the delegate represents an instance method; null if the delegate represents a static method.</returns>
		public abstract Object Target { get; }

#if NET4 || NET45
		/// <summary>Gets the method represented by the delegate.</summary>
		public abstract MethodInfo Method { get; }
#endif
#if !NET4
		/// <summary>Gets an object that represents the method represented by the specified delegate.</summary>
		/// <returns>An object that represents the method.</returns>
		public abstract MethodInfo GetMethodInfo();
#endif

		/// <summary>Dynamically invokes (late-bound) the method represented by the current delegate.</summary>
		/// <returns>The object returned by the method represented by the delegate.</returns>
		public abstract Object DynamicInvoke(params Object[] args);


		internal abstract ImmutableArray<Delegate> GetInvocationListInternal();

		public ImmutableArray<Delegate> GetInvocationList() => GetInvocationListInternal();


		internal abstract CoContravariantDelegate CombineInternal(Delegate d);
		internal abstract CoContravariantDelegate CombineInternal(CoContravariantDelegate ccd);
		internal abstract CoContravariantDelegate CombineInternal(params CoContravariantDelegate[] ccds);
		internal abstract CoContravariantDelegate CombineInternal(params Delegate[] ds);

		internal abstract CoContravariantDelegate RemoveInternal(Delegate d);
		internal abstract CoContravariantDelegate RemoveInternal(CoContravariantDelegate ccd2);

		internal abstract CoContravariantDelegate RemoveAllInternal(Delegate d);
		internal abstract CoContravariantDelegate RemoveAllInternal(CoContravariantDelegate ccd2);

		
		public static CoContravariantDelegate Combine(CoContravariantDelegate ccd, Delegate d)                            => ccd.CheckNull(nameof(ccd)).CombineInternal(d);
		public static CoContravariantDelegate Combine(CoContravariantDelegate ccd, CoContravariantDelegate ccd2)          => ccd.CheckNull(nameof(ccd)).CombineInternal(ccd2);
		public static CoContravariantDelegate Combine(CoContravariantDelegate ccd, params CoContravariantDelegate[] ccds) => ccd.CheckNull(nameof(ccd)).CombineInternal(ccds);
		public static CoContravariantDelegate Combine(CoContravariantDelegate ccd, params Delegate[] ds)                  => ccd.CheckNull(nameof(ccd)).CombineInternal(ds);

		public static CoContravariantDelegate Remove(CoContravariantDelegate ccd, Delegate d)                             => ccd.CheckNull(nameof(ccd)).RemoveInternal(d);
		public static CoContravariantDelegate Remove(CoContravariantDelegate ccd, CoContravariantDelegate ccd2)           => ccd.CheckNull(nameof(ccd)).RemoveInternal(ccd2);

		public static CoContravariantDelegate RemoveAll(CoContravariantDelegate ccd, Delegate d)                          => ccd.CheckNull(nameof(ccd)).RemoveAllInternal(d);
		public static CoContravariantDelegate RemoveAll(CoContravariantDelegate ccd, CoContravariantDelegate ccd2)        => ccd.CheckNull(nameof(ccd)).RemoveAllInternal(ccd2);
	}

	internal static class CoContravariantDelegateHelperExtensions {
		public static T CheckNull<T>(this T value, String paramName) {
			if (value == null)
				throw new ArgumentNullException(paramName);
			return value;
		}

		public static T CastDelegate<T>(this Object @object, String paramName) where T : class {
			if (@object == null)
				return null;
			var x = @object as T;
			if (x == null)
				throw new ArgumentException("The delegate types do not match", paramName);
			return x;
		}
	}
}