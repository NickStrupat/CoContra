using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CoContra;

namespace Testing {
	public class Program {
		public static void Main(string[] args) {
			Func<String> stringFactory = () => "hello";
			Func<Object> objectFactory = () => new object();

			CoContravariantFunc<object> multi1 = stringFactory;
			multi1 += objectFactory;

			CoContravariantFunc<object> multi2 = objectFactory;
			multi2 += stringFactory;

			Func<Object> m = multi1;
			var d = m.Invoke();
			var b = multi1.Invoke();
			var c = multi2.Invoke();

			var what = Make<ImmutableArray<String>>();
			var w = Activator.CreateInstance<ImmutableArray<Int64>>();
			var x = new ImmutableArray<String>();
			var y = ImmutableArray<String>.Empty;

			//var cd = ContravariantEvent<Func<String>>.Empty;

			DoIt doIt = Console.Write;
			doIt += Console.WriteLine;
			doIt("asdf");

			var ca = new CovariantAction<String>((s => s += ""));
			ca.Add(e => e += 3);
			Func<Int64, Int64> a = t => t + 4;

			var thing = new Thing();
			thing.Foo();
		}

		private static T Make<T>() where T : struct => new T();

		public delegate void DoIt(String @string);
	}

	public class Thing {
		private CovariantAction<String> what;
		public event Action<String> What { add { what += value; } remove { what -= value; } }

		public event Action<String> What2;
		public event Func<String> Bar;
		public event EventHandler<String> Event;
		public event EventHandler Event2;

		public void Foo() {
			Bar += () => "asdf";
			Bar += () => "fdsa";
			var dfsa = Bar();
		}
	}
	//public class ClickEventArgs : EventArgs { }

	//public class Button {
	//	private CovariantEventHandler<EventArgs> click;
	//	public event EventHandler<EventArgs> Click { add { click += value; } remove { click -= value; } }

	//	public void MouseDown() {
	//		click?.Invoke(this, new ClickEventArgs());
	//	}
	//}

	//class Program {
	//	static void Main(string[] args) {
	//		Button button = new Button();

	//		button.Click += new EventHandler<ClickEventArgs>(button_Click);
	//		button.Click += new EventHandler<EventArgs>(button_Click);

	//		button.MouseDown();
	//	}

	//	static void button_Click(object s, EventArgs e) {
	//		Console.WriteLine("Button was clicked");
	//	}
	//}
}
