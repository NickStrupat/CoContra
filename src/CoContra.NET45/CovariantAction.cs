using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoContra {
	public sealed class CovariantAction<T> : CoContravariantDelegateBase<Action<T>, CovariantAction<T>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T>(Action<T> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T>(CovariantAction<T> caction) => caction.Invoke;

		public void Invoke(T arg) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg);
		}

#if NET4
		public Task InvokeAsync(T arg, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg), cancellationToken);
#else
		public Task InvokeAsync(T arg, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T arg, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2> : CoContravariantDelegateBase<Action<T1, T2>, CovariantAction<T1, T2>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2>(Action<T1, T2> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2>(CovariantAction<T1, T2> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3> : CoContravariantDelegateBase<Action<T1, T2, T3>, CovariantAction<T1, T2, T3>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3>(Action<T1, T2, T3> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3>(CovariantAction<T1, T2, T3> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4> : CoContravariantDelegateBase<Action<T1, T2, T3, T4>, CovariantAction<T1, T2, T3, T4>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4>(CovariantAction<T1, T2, T3, T4> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5>, CovariantAction<T1, T2, T3, T4, T5>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5>(CovariantAction<T1, T2, T3, T4, T5> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6>, CovariantAction<T1, T2, T3, T4, T5, T6>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6>(CovariantAction<T1, T2, T3, T4, T5, T6> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6, T7> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7>, CovariantAction<T1, T2, T3, T4, T5, T6, T7>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6, T7>(CovariantAction<T1, T2, T3, T4, T5, T6, T7> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8>, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

	public sealed class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> {
		public CovariantAction() : base() {}
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) : base(action.CheckNull(nameof(action))) {}

		public static explicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) => ConvertToCoContravariantDelegate(action);
		public static explicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> caction) => caction.Invoke;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
		}

#if NET4
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, CancellationToken cancellationToken = default(CancellationToken)) => Task.Factory.StartNew(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16), cancellationToken);
#else
		public Task InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, CancellationToken cancellationToken = default(CancellationToken)) => Task.Run(() => Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16), cancellationToken);
#endif

		public IAsyncResult BeginInvoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, AsyncCallback callback, Object state) {
			var task = InvokeAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
			var tcs = new TaskCompletionSource<Boolean>(state);
			task.ContinueWith(t => {
				if (t.IsFaulted)
					tcs.TrySetException(t.Exception.InnerExceptions);
				else if (t.IsCanceled)
					tcs.TrySetCanceled();
				else {
					t.Wait();
					tcs.TrySetResult(true);
				}
				callback?.Invoke(tcs.Task);
			}, TaskScheduler.Default);
			return tcs.Task;
		}

		public void EndInvoke(IAsyncResult asyncResult) => ((Task) asyncResult).Wait();
	}

}