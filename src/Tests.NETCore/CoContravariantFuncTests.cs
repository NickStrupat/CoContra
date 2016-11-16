using System;
using System.Collections.Generic;
using System.Linq;
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

			CoContravariantFunc<Object> multi1 = new CoContravariantFunc<Object>(stringFactory);
			multi1 += objectFactory;

			CoContravariantFunc<Object> multi2 = new CoContravariantFunc<Object>(objectFactory);
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

		[Fact]
		public void InvocationList() {
			Func<String> f1 = F1;
			Func<String> f2 = F2;
			Func<String> f3 = F3;

			var ccfunc = new CoContravariantFunc<String>(f1);
			ccfunc += f2;
			ccfunc += f3;

			Func<String> func = f1;
			func += f2;
			func += f3;

			var ccfil = ccfunc.GetInvocationList().Cast<Delegate>();
			var fil = func.GetInvocationList();
			Assert.True(ccfil.SequenceEqual(fil));
		}

		private static String F3() => null;
		private static String F2() => null;
		private static String F1() => null;

		[Fact]
		public void Equals() {
			Func<String> a = F1;
			Func<String> b = F1;
			Assert.True(a.Equals(a));
			Assert.True(a.Equals(b));
			Assert.True(a.Equals((Object) a));
			Assert.True(a.Equals((Object) b));

			a += F2;
			b += F2;
			Assert.True(a.Equals(b));
			Assert.True(a.Equals((Object) b));

			a += F2;
			b += F3;
			Assert.False(a.Equals(b));
			Assert.False(a.Equals((Object) b));

			var cca = new CoContravariantFunc<String>(F1);
			var ccb = new CoContravariantFunc<String>(F1);
			Assert.True(cca.Equals(cca));
			Assert.True(cca.Equals(ccb));
			Assert.True(cca.Equals((Object) cca));
			Assert.True(cca.Equals((Object) ccb));

			cca += F2;
			ccb += F2;
			Assert.True(cca.Equals(ccb));
			Assert.True(cca.Equals((Object) ccb));

			cca += F2;
			ccb += F3;
			Assert.False(cca.Equals(ccb));
			Assert.False(cca.Equals((Object) ccb));
		}

		[Fact]
		public void ImplicitConversionToDelegateUnwrapsAWrappedCoContravariantDelegate() {
			var ca = new CoContravariantFunc<Int32>(() => 42);
			var a = (Func<Int32>) ca;
			var unwrappedca = (CoContravariantFunc<Int32>) a;
			Assert.True(ReferenceEquals(ca, unwrappedca));
		}

		[Fact]
		public void AddRemoveOrder() {
			var list = new List<Int32>();
			Func<String, Object> a = s => { list.Add(1); return null; };
			Func<String, Object> b = s => { list.Add(2); return null; };
			Func<String, Object> c = s => { list.Add(3); return null; };

			Func<String, Object> ma = a;
			ma += b;
			ma += c;
			ma += b;
			ma -= b;
			ma.Invoke("wat");
			Assert.True(list.SequenceEqual(new[] { 1, 2, 3 }));

			list.Clear();
			var mca = new CoContravariantFunc<String, Object>(a);
			mca += b;
			mca += c;
			mca += b;
			mca -= b;
			mca.Invoke("wat");
			Assert.True(list.SequenceEqual(new[] { 1, 2, 3 }));

			list.Clear();
			mca = new CoContravariantFunc<String, Object>(a);
			mca.Add(b);
			mca.Add(c);
			mca.Add(b);
			mca.Remove(b);
			mca.Invoke("wat");
			Assert.True(list.SequenceEqual(new[] { 1, 2, 3 }));
		}
	}
}