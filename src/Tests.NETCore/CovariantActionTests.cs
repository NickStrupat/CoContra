using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CoContra;

#if NET4
using NUnit.Framework;
using Fact = NUnit.Framework.TestAttribute;
#else
using Xunit;
#endif

namespace Tests {
	public class CovariantActionTests {
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
		public void CombineCovariantDelegatesWithCovariantAction() {
			Action<String> stringFactory = s => { };
			Action<Object> objectFactory = o => { };

			CovariantAction<String> multi1 = objectFactory;
			multi1 += stringFactory;

			CovariantAction<String> multi2 = stringFactory;
			multi2 += objectFactory;
		}

		[Fact]
		public void NullConstructorArgument() {
			new CovariantAction<Object>(null);
		}

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
			Assert.True(ReferenceEquals(foo.VoidBarMethodInfo, caction.GetMethodInfo()));
			Assert.True(ReferenceEquals(action.GetMethodInfo(), caction.GetMethodInfo()));

			action += foo2.Baz;
			caction += foo2.Baz;
			Assert.True(ReferenceEquals(foo2.VoidBazMethodInfo, caction.GetMethodInfo()));
			Assert.True(ReferenceEquals(action.GetMethodInfo(), caction.GetMethodInfo()));

			Action<Object> a = x => { };
			action += a;
			caction += a;
			Assert.True(ReferenceEquals(action.GetMethodInfo(), caction.GetMethodInfo()));

			action += Foo.StaticMethod;
			caction += Foo.StaticMethod;
			Assert.True(ReferenceEquals(Foo.StaticVoidMethodMethodInfo, caction.GetMethodInfo()));
			Assert.True(ReferenceEquals(action.GetMethodInfo(), caction.GetMethodInfo()));
		}

		private const String InvokeArgument = "Test";
		private const String InvokeArgument2 = "Test2";

		[Fact]
		public void Invoke() {
			var count = 0;
			var caction = new CovariantAction<String>(s => {
				count++;
				Assert.True(s == InvokeArgument);
			});
			var action = new Action<Object>(o => {
				count++;
				Assert.True((String) o == InvokeArgument);
			});
			caction += action;
			Assert.True(0 == count);
			caction.Invoke(InvokeArgument);
			Assert.True(2 == count);
		}

		[Fact]
		public void DynamicInvoke() {
			var count = 0;
			var caction = new CovariantAction<String>(s => {
				count++;
				Assert.True(s == InvokeArgument);
			});
			var action = new Action<Object>(o => {
				count++;
				Assert.True((String) o == InvokeArgument);
			});
			caction += action;
			Assert.True(0 == count);
			caction.DynamicInvoke(InvokeArgument);
			Assert.True(2 == count);
		}

		[Fact]
		public void InvokeAsync() {
			var count = 0;
			var caction = new CovariantAction<String>(s => {
				count++;
				Assert.True(s == InvokeArgument);
			});
			var action = new Action<Object>(o => {
				count++;
				Assert.True((String) o == InvokeArgument);
			});
			caction += action;
			Assert.True(0 == count);
			caction.InvokeAsync(InvokeArgument).Wait();
			Assert.True(2 == count);
		}

		[Fact]
		public void BeginInvoke() {
			var count = 0;
			var caction = new CovariantAction<String>(s => {
				count++;
				Assert.True(s == InvokeArgument);
			});
			var action = new Action<Object>(o => {
				count++;
				Assert.True((String) o == InvokeArgument);
			});
			caction += action;
			Assert.True(0 == count);
			var ar = caction.BeginInvoke(InvokeArgument, null, null);
			caction.EndInvoke(ar);
			Assert.True(2 == count);
		}

		[Fact]
		public void EventBackingField() {
			var foo = new Foo();
			foo.Actions += s => Assert.True(InvokeArgument == s);
			foo.RaiseActions(InvokeArgument);
			
			foo.ReadOnlyActions += s => Assert.True(InvokeArgument2 == s);
			foo.RaiseReadOnlyActions(InvokeArgument2);
		}

		[Fact]
		public void InvocationList() {
			Action<String> a1 = A1;
			Action<String> a2 = A2;
			Action<String> a3 = A3;

			CovariantAction<String> caction = a1;
			caction += a2;
			caction += a3;

			Action<String> action = a1;
			action += a2;
			action += a3;

			var cail = caction.GetInvocationList().Cast<Delegate>();
			var ail = action.GetInvocationList();
			Assert.True(cail.SequenceEqual(ail));
		}

		private static void A3(String s) {}
		private static void A2(String s) {}
		private static void A1(String s) {}

		// TODO:
		// operators
		// equality methods
	}
}
