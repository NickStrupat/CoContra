using System;
using System.Collections.Generic;
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
	public class StaticMethodTests {
		[Fact]
		public void BaseCoContravariantDelegateCombineWithNativeDelegate() {
			Action<String> action = s => { };
			action += s => { };
			action += s => { };
			var ccd = new CovariantAction<String>(s => { });
			ccd += s => { };
			var ccd2 = CoContravariantDelegate.Combine(ccd, new CovariantAction<String>(action)); // <--------------

			var ccdil = ((CoContravariantDelegate) ccd).GetInvocationList();
			var actionil = action.GetInvocationList();
			Assert.True(ccd2.GetInvocationList().SequenceEqual(ccdil.Concat(actionil)));
		}

		[Fact]
		public void GenericCoContravariantDelegateCombineWithNativeDelegate() {
			Action<String> action = s => { };
			action += s => { };
			action += s => { };
			var ccd = new CovariantAction<String>(s => { });
			ccd += s => { };
			var ccd2 = CovariantAction<String>.Combine(ccd, new CovariantAction<String>(action)); // <--------------

			var ccdil = ((CoContravariantDelegate) ccd).GetInvocationList();
			var actionil = action.GetInvocationList();
			Assert.True(ccd2.GetInvocationList().AsEnumerable().SequenceEqual(ccdil.Concat(actionil)));
		}

		[Fact]
		public void BaseCoContravariantDelegateCombineWithCoContravariantDelegate() {
			var caction = new CovariantAction<String>(s => { });
			caction += s => { };
			caction += s => { };
			var ccd = new CovariantAction<String>(s => { });
			ccd += s => { };
			var ccd2 = CoContravariantDelegate.Combine(ccd, caction); // <--------------

			var ccdil = ((CoContravariantDelegate) ccd).GetInvocationList();
			var actionil = caction.GetInvocationList();
			Assert.True(ccd2.GetInvocationList().SequenceEqual(ccdil.Concat(actionil)));
		}
	}
}
