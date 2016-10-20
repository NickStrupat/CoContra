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
			new CoContravariantFunc<Object>(null);
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

			Func<Object> f = () => null;
			func += f;
			ccfunc += f;
			Assert.True(ReferenceEquals(f.Target, ccfunc.Target));
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

			var func = new Func<Object>(foo.Bar);
			var ccfunc = new CoContravariantFunc<Object>(foo.Bar);
			Assert.True(ReferenceEquals(foo.ObjectBarMethodInfo, ccfunc.GetMethodInfo()));
			Assert.True(ReferenceEquals(func.GetMethodInfo(), ccfunc.GetMethodInfo()));

			func += foo2.Baz;
			ccfunc += foo2.Baz;
			Assert.True(ReferenceEquals(foo2.ObjectBazMethodInfo, ccfunc.GetMethodInfo()));
			Assert.True(ReferenceEquals(func.GetMethodInfo(), ccfunc.GetMethodInfo()));

			Func<Object> f = () => null;
			func += f;
			ccfunc += f;
			Assert.True(ReferenceEquals(func.GetMethodInfo(), ccfunc.GetMethodInfo()));

			func += Foo.StaticMethod;
			ccfunc += Foo.StaticMethod;
			Assert.True(ReferenceEquals(Foo.StaticObjectMethodMethodInfo, ccfunc.GetMethodInfo()));
			Assert.True(ReferenceEquals(func.GetMethodInfo(), ccfunc.GetMethodInfo()));
		}

		private const String InvokeArgument = "Test";
		private const String InvokeArgument2 = "Test2";
		private const String ReturnValue = "Result";

		[Fact]
		public void Invoke() {
			var count = 0;
			var ccfunc = new CoContravariantFunc<String, Object>(s => {
				count++;
				Assert.True(s == InvokeArgument);
				return ReturnValue;
			});
			var func = new Func<Object, String>(o => {
				count++;
				Assert.True((String) o == InvokeArgument);
				return ReturnValue;
			});
			ccfunc += func;
			var result = ccfunc.Invoke(InvokeArgument);
			Assert.True(ReturnValue == (String) result);
			Assert.True(2 == count);
		}

		[Fact]
		public void DynamicInvoke() {
			var count = 0;
			var ccfunc = new CoContravariantFunc<String, Object>(s => {
				count++;
				Assert.True(s == InvokeArgument);
				return ReturnValue;
			});
			var func = new Func<Object, String>(o => {
				count++;
				Assert.True((String) o == InvokeArgument);
				return ReturnValue;
			});
			ccfunc += func;
			var result = ccfunc.DynamicInvoke(InvokeArgument);
			Assert.True(ReturnValue == (String) result);
			Assert.True(2 == count);
		}

		[Fact]
		public void InvokeAsync() {
			var count = 0;
			var ccfunc = new CoContravariantFunc<String, Object>(s => {
				count++;
				Assert.True(s == InvokeArgument);
				return ReturnValue;
			});
			var func = new Func<Object, String>(o => {
				count++;
				Assert.True((String) o == InvokeArgument);
				return ReturnValue;
			});
			ccfunc += func;
			var result = ccfunc.InvokeAsync(InvokeArgument).Result;
			Assert.True(ReturnValue == (String) result);
			Assert.True(2 == count);
		}

		[Fact]
		public void BeginInvoke() {
			var count = 0;
			var ccfunc = new CoContravariantFunc<String, Object>(s => {
				count++;
				Assert.True(s == InvokeArgument);
				return ReturnValue;
			});
			var func = new Func<Object, String>(o => {
				count++;
				Assert.True((String) o == InvokeArgument);
				return ReturnValue;
			});
			ccfunc += func;
			Assert.True(0 == count);
			var ar = ccfunc.BeginInvoke(InvokeArgument, null, null);
			var result = ccfunc.EndInvoke(ar);
			Assert.True(ReturnValue == (String) result);
			Assert.True(2 == count);
		}

		[Fact]
		public void EventBackingField() {
			var foo = new Foo();
			foo.ReadOnlyFuncs += s => {
				Assert.True(s == InvokeArgument);
				return ReturnValue;
			};
			var result = foo.RaiseReadOnlyFuncs(InvokeArgument);
			Assert.True(ReturnValue == (String) result);

			foo.Funcs += s => {
				Assert.True(s == InvokeArgument2);
				return ReturnValue;
			};
			result = foo.RaiseFuncs(InvokeArgument2);
			Assert.True(ReturnValue == (String) result);
		}
	}
}