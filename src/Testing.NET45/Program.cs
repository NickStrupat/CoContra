using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoContra;

namespace Testing.NET45 {
	class Program {
		static void Main(string[] args) {
			var b = new CovariantAction<Int32>(Console.WriteLine);
			var c = new Action<String>(Console.WriteLine);
			var d = c.BeginInvoke("Asdf", null, null);
			c.EndInvoke(d);
			var e = new Func<String>(() => "e");
			var f = e.BeginInvoke(null, null);
			var g = e.EndInvoke(f);

			const Int32 iterations = 10000;
			var sw = new Stopwatch();

			var ca = new CovariantAction<Object>(o => { });
			ca += o => { };
			ca += o => Console.BackgroundColor = ConsoleColor.Blue;
			ca += o => { };
			sw.Start();
			for (var i = 0; i != iterations; ++i)
				ca.Invoke(null);
			sw.Stop();
			Console.WriteLine(sw.ElapsedMilliseconds);

			var aa = new Action<Object>(o => { });
			aa += o => { };
			aa += o => Console.BackgroundColor = ConsoleColor.Black;
			aa += o => { };
			sw.Restart();
			for (var i = 0; i != iterations; ++i)
				aa.Invoke(null);
			sw.Stop();
			Console.WriteLine(sw.ElapsedMilliseconds);
			return;

			//var h = new Action<String>(s => Console.WriteLine(s.GetType() + "a"));
			//h += new Action<Object>(o => Console.WriteLine(o.GetType()));

			var j = new CovariantAction<String>(s => Console.WriteLine(s.GetType() + "a"));
			j += new CovariantAction<Object>(o => Console.WriteLine(o.GetType()));
			j.Invoke("ffff");
		}
	}
}
