using System;
using System.Reflection;
using CoContra;

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

		// backing actions must not be readonly since the += and -= operators must be able to write to `actions`
		// the overloaded + and - operators just return the left operand (always `actions`), so there's so worry of a race condition there
		private CovariantAction<String> actions = new CovariantAction<String>();
		public event Action<String> Actions { add { actions += value; } remove { actions -= value; } }
		public void RaiseActions(String @string) => actions.Invoke(@string);

		// need to use Add() and Remove() here when the backing field is readonly
		private readonly CovariantAction<String> readOnlyActions = new CovariantAction<String>();
		public event Action<String> ReadOnlyActions { add { readOnlyActions.Add(value); } remove { readOnlyActions.Remove(value); } }
		public void RaiseReadOnlyActions(String @string) => readOnlyActions.Invoke(@string);

		// backing actions must not be readonly since the += and -= operators must be able to write to `actions`
		// the overloaded + and - operators just return the left operand (always `actions`), so there's so worry of a race condition there
		private CoContravariantFunc<String, Object> funcs = new CoContravariantFunc<String, Object>();
		public event Func<String, Object> Funcs { add { funcs += value; } remove { funcs -= value; } }
		public Object RaiseFuncs(String @string) => funcs.Invoke(@string);
		
		// need to use Add() and Remove() here when the backing field is readonly
		private readonly CoContravariantFunc<String, Object> readOnlyFuncs = new CoContravariantFunc<String, Object>();
		public event Func<String, Object> ReadOnlyFuncs { add { readOnlyFuncs.Add(value); } remove { readOnlyFuncs.Remove(value); } }
		public Object RaiseReadOnlyFuncs(String @string) => readOnlyFuncs.Invoke(@string);
	}
}