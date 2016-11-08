using System;
using System.Reflection;

namespace CoContra {
	internal static class ReflectionExtensions {
		public static MethodInfo GetMethodInfo(this Delegate del) => del.Method;
	}
}