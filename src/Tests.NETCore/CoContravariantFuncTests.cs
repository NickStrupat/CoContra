using System;
using System.Reflection;
using CoContra;

#if NET4
using NUnit.Framework;
using Fact = NUnit.Framework.TestAttribute;
#else
using Xunit;
#endif

namespace Tests {
	public class CoContravariantFuncTests {
		[Fact]
		public void CombineContravariantDelegatesWithFuncFails() {
			Func<String> stringFactory = () => "hello";
			Func<Object> objectFactory = () => new Object();

			Func<Object> multi1 = stringFactory;
			Assert.Throws<ArgumentException>(() => multi1 += objectFactory);

			Func<Object> multi2 = objectFactory;
			Assert.Throws<ArgumentException>(() => multi2 += stringFactory);
		}

		[Fact]
		public void CombineContravariantDelegatesWithContravariantFunc() {
			Func<String> stringFactory = () => "hello";
			Func<Object> objectFactory = () => new Object();

			CoContravariantFunc<Object> multi1 = stringFactory;
			multi1 += objectFactory;

			CoContravariantFunc<Object> multi2 = objectFactory;
			multi2 += stringFactory;
		}

		[Fact]
		public void NullConstructorArgument() {
			Assert.Throws<ArgumentNullException>(() => new CoContravariantFunc<Object>(null));
		}

		[Fact]
		public void TargetProperty() {
			var foo = new Foo();
			var foo2 = new Foo();

			var func = new Func<Object>(foo.Bar);
			var ccfunc = new CoContravariantFunc<Object>(foo.Bar);
			Assert.True(ReferenceEquals(foo, ccfunc.Target));
			Assert.True(ReferenceEquals(func.Target, ccfunc.Target));

			func += foo2.Baz;
			ccfunc += foo2.Baz;
			Assert.True(ReferenceEquals(foo2, ccfunc.Target));
			Assert.True(ReferenceEquals(func.Target, ccfunc.Target));

			Func<Object> a = () => null;
			func += a;
			ccfunc += a;
			Assert.True(ReferenceEquals(a.Target, ccfunc.Target));
			Assert.True(ReferenceEquals(func.Target, ccfunc.Target));

			func += Foo.StaticMethod;
			ccfunc += Foo.StaticMethod;
			Assert.True(ReferenceEquals(null, ccfunc.Target));
			Assert.True(ReferenceEquals(func.Target, ccfunc.Target));
		}

		[Fact]
		public void MethodProperty() {
			var foo = new Foo();
			var foo2 = new Foo();

			var action = new Func<Object>(foo.Bar);
			var caction = new CoContravariantFunc<Object>(foo.Bar);
			Assert.True(ReferenceEquals(foo.ObjectBarMethodInfo, caction.GetMethodInfo()));
			Assert.True(ReferenceEquals(action.GetMethodInfo(), caction.GetMethodInfo()));

			action += foo2.Baz;
			caction += foo2.Baz;
			Assert.True(ReferenceEquals(foo2.ObjectBazMethodInfo, caction.GetMethodInfo()));
			Assert.True(ReferenceEquals(action.GetMethodInfo(), caction.GetMethodInfo()));

			Func<Object> a = () => null;
			action += a;
			caction += a;
			Assert.True(ReferenceEquals(action.GetMethodInfo(), caction.GetMethodInfo()));

			action += Foo.StaticMethod;
			caction += Foo.StaticMethod;
			Assert.True(ReferenceEquals(Foo.StaticObjectMethodMethodInfo, caction.GetMethodInfo()));
			Assert.True(ReferenceEquals(action.GetMethodInfo(), caction.GetMethodInfo()));
		}

		[Fact]
		public void Invoke() {
			var count = 0;
			var caction = new CoContravariantFunc<Object>(() => count++);
			var action = new Func<String>(() => count++.ToString());
			caction += action;
			caction.Invoke();
			Assert.True(2 == count);
		}
	}
}