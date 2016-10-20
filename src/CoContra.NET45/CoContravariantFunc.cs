using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CoContra {
	public sealed class CoContravariantFunc<TResult> : CoContravariantDelegateBase<Func<TResult>, CoContravariantFunc<TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<TResult>(Func<TResult> func) { return new CoContravariantFunc<TResult>(func); }
		public static implicit operator Func<TResult>(CoContravariantFunc<TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<TResult> operator +(CoContravariantFunc<TResult> cf, Func<TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<TResult> operator -(CoContravariantFunc<TResult> cf, Func<TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<TResult> left, CoContravariantFunc<TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<TResult> left, CoContravariantFunc<TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke() {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke();
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(), cancellationToken);
#else
		public Task<TResult> InvokeAsync(CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(AsyncCallback callback, Object state) {
			var task = InvokeAsync();
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T, TResult> : CoContravariantDelegateBase<Func<T, TResult>, CoContravariantFunc<T, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T, TResult>(Func<T, TResult> func) { return new CoContravariantFunc<T, TResult>(func); }
		public static implicit operator Func<T, TResult>(CoContravariantFunc<T, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T, TResult> operator +(CoContravariantFunc<T, TResult> cf, Func<T, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T, TResult> operator -(CoContravariantFunc<T, TResult> cf, Func<T, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T, TResult> left, CoContravariantFunc<T, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T, TResult> left, CoContravariantFunc<T, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T arg) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T arg, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, TResult> : CoContravariantDelegateBase<Func<T1, T2, TResult>, CoContravariantFunc<T1, T2, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, TResult>(Func<T1, T2, TResult> func) { return new CoContravariantFunc<T1, T2, TResult>(func); }
		public static implicit operator Func<T1, T2, TResult>(CoContravariantFunc<T1, T2, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, TResult> operator +(CoContravariantFunc<T1, T2, TResult> cf, Func<T1, T2, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, TResult> operator -(CoContravariantFunc<T1, T2, TResult> cf, Func<T1, T2, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, TResult> left, CoContravariantFunc<T1, T2, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, TResult> left, CoContravariantFunc<T1, T2, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, TResult>, CoContravariantFunc<T1, T2, T3, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func) { return new CoContravariantFunc<T1, T2, T3, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, TResult>(CoContravariantFunc<T1, T2, T3, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, TResult> operator +(CoContravariantFunc<T1, T2, T3, TResult> cf, Func<T1, T2, T3, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, TResult> operator -(CoContravariantFunc<T1, T2, T3, TResult> cf, Func<T1, T2, T3, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, TResult> left, CoContravariantFunc<T1, T2, T3, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, TResult> left, CoContravariantFunc<T1, T2, T3, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, TResult>, CoContravariantFunc<T1, T2, T3, T4, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, TResult>(CoContravariantFunc<T1, T2, T3, T4, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, TResult> cf, Func<T1, T2, T3, T4, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, TResult> cf, Func<T1, T2, T3, T4, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, TResult> left, CoContravariantFunc<T1, T2, T3, T4, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, TResult> left, CoContravariantFunc<T1, T2, T3, T4, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, TResult> cf, Func<T1, T2, T3, T4, T5, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, TResult> cf, Func<T1, T2, T3, T4, T5, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> cf, Func<T1, T2, T3, T4, T5, T6, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> cf, Func<T1, T2, T3, T4, T5, T6, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public sealed class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>> {
		public CoContravariantFunc() : base() {}
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) { cf.Remove(func); return cf; }
		public static Boolean operator ==(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> left, CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetInvocationList().LastOrDefault()?.Target;
		
#if NET4 || NET45
		public MethodInfo Method => GetInvocationList().LastOrDefault()?.Method;
#endif
#if !NET4
		public MethodInfo GetMethodInfo() => GetInvocationList().LastOrDefault()?.GetMethodInfo();
#endif

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
			return result;
		}

#if NET4
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16), cancellationToken);
#else
		public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
			var tcs = new TaskCompletionSource<TResult>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else
					tcs.TrySetResult(t.Result);
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public TResult EndInvoke(IAsyncResult asyncResult) => ((Task<TResult>) asyncResult).Result;

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

}