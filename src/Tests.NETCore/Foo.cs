using System;
using System.Reflection;

namespace Tests {
	class Foo {
		public void Bar(Object o) { }
		public void Baz(Object o) { }
		public static void StaticMethod(Object o) { }

		public Object Bar() => null;
		public Object Baz() => null;
		public static Object StaticMethod() => null;

		public readonly MethodInfo VoidBarMethodInfo;
		public readonly MethodInfo VoidBazMethodInfo;
		public static readonly MethodInfo StaticVoidMethodMethodInfo;

		public readonly MethodInfo ObjectBarMethodInfo;
		public readonly MethodInfo ObjectBazMethodInfo;
		public static readonly MethodInfo StaticObjectMethodMethodInfo;

		public Foo() {
			VoidBarMethodInfo = new Action<Object>(Bar).GetMethodInfo();
			VoidBazMethodInfo = new Action<Object>(Baz).GetMethodInfo();
			ObjectBarMethodInfo = new Func<Object>(Bar).GetMethodInfo();
			ObjectBazMethodInfo = new Func<Object>(Baz).GetMethodInfo();
		}

		static Foo() {
			StaticVoidMethodMethodInfo = new Action<Object>(StaticMethod).GetMethodInfo();
			StaticObjectMethodMethodInfo = new Func<Object>(StaticMethod).GetMethodInfo();
		}
	}
}