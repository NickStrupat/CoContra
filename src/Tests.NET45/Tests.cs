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
	}
}
