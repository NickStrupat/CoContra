using System;
using System.Reflection;
using CoContra;

namespace Tests {
	internal static class Extensions {
		public static MethodInfo GetMethodInfo(this Action<Object> action) => action.Method;
		public static MethodInfo GetMethodInfo(this CovariantAction<Object> caction) => caction.Method;
		public static MethodInfo GetMethodInfo(this Func<Object> func) => func.Method;
		public static MethodInfo GetMethodInfo(this CoContravariantFunc<Object> ccfunc) => ccfunc.Method;
		public static Type GetTypeInfo(this Type type) => type;
	}
}