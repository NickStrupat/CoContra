using System;
using CoContra;

#if NET4
using NUnit.Framework;
using Fact = NUnit.Framework.TestAttribute;
#else
using Xunit;
#endif

namespace Tests {
	public class Tests {
		[Fact]
		public void CombineCovariantDelegatesWithActionFails() {
			Action<String> stringFactory = s => { };
			Action<Object> objectFactory = o => { };

			Action<String> multi1 = objectFactory;
			Assert.Throws<ArgumentException>(() => multi1 += stringFactory);

			Action<String> multi2 = stringFactory;
			Assert.Throws<ArgumentException>(() => multi2 += objectFactory);
		}

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
		public void CombineCovariantDelegatesWithCovariantAction() {
			Action<String> stringFactory = s => { };
			Action<Object> objectFactory = o => { };

			CovariantAction<String> multi1 = objectFactory;
			multi1 += stringFactory;

			CovariantAction<String> multi2 = stringFactory;
			multi2 += objectFactory;
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

		class Foo { public void Bar(Object o) { } public void Baz(Object o) { } public static void StaticMethod(Object o) { } }
		[Fact]
		public void TargetProperty() {
			var foo = new Foo();
			var foo2 = new Foo();

			var action = new Action<Object>(foo.Bar);
			var caction = new CovariantAction<Object>(foo.Bar);
			Assert.True(ReferenceEquals(foo, caction.Target));
			Assert.True(ReferenceEquals(action.Target, caction.Target));

			action += foo2.Baz;
			caction += foo2.Baz;
			Assert.True(ReferenceEquals(foo2, caction.Target));
			Assert.True(ReferenceEquals(action.Target, caction.Target));

			Action<Object> a = x => { };
			action += a;
			caction += a;
			Assert.True(ReferenceEquals(a.Target, caction.Target));
			Assert.True(ReferenceEquals(action.Target, caction.Target));

			action += Foo.StaticMethod;
			caction += Foo.StaticMethod;
			Assert.True(ReferenceEquals(null, caction.Target));
			Assert.True(ReferenceEquals(action.Target, caction.Target));
		}

		[Fact]
		public void MethodProperty() {
			var foo = new Foo();
			var foo2 = new Foo();

			var action = new Action<Object>(foo.Bar);
			var caction = new CovariantAction<Object>(foo.Bar);
			Assert.True(ReferenceEquals(foo.GetType().GetMethod(nameof(Foo.Bar)), caction.Method));
			Assert.True(ReferenceEquals(action.Method, caction.Method));

			action += foo2.Baz;
			caction += foo2.Baz;
			Assert.True(ReferenceEquals(foo2.GetType().GetMethod(nameof(Foo.Baz)), caction.Method));
			Assert.True(ReferenceEquals(action.Method, caction.Method));

			Action<Object> a = x => { };
			action += a;
			caction += a;
			Assert.True(ReferenceEquals(action.Method, caction.Method));

			action += Foo.StaticMethod;
			caction += Foo.StaticMethod;
			Assert.True(ReferenceEquals(typeof(Foo).GetMethod(nameof(Foo.StaticMethod)), caction.Method));
			Assert.True(ReferenceEquals(action.Method, caction.Method));
		}
	}
}
