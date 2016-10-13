using System;

namespace CoContra {
	public class CoContravariantFunc<TResult> : CoContravariantDelegateBase<Func<TResult>> {
		public CoContravariantFunc(Func<TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<TResult>(Func<TResult> func) { return new CoContravariantFunc<TResult>(func); }
		public static implicit operator Func<TResult>(CoContravariantFunc<TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<TResult> operator +(CoContravariantFunc<TResult> cf, Func<TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<TResult> operator -(CoContravariantFunc<TResult> cf, Func<TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke() {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke();
			return result;
		}
	}

	public class CoContravariantFunc<T, TResult> : CoContravariantDelegateBase<Func<T, TResult>> {
		public CoContravariantFunc(Func<T, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T, TResult>(Func<T, TResult> func) { return new CoContravariantFunc<T, TResult>(func); }
		public static implicit operator Func<T, TResult>(CoContravariantFunc<T, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T, TResult> operator +(CoContravariantFunc<T, TResult> cf, Func<T, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T, TResult> operator -(CoContravariantFunc<T, TResult> cf, Func<T, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T arg) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, TResult> : CoContravariantDelegateBase<Func<T1, T2, TResult>> {
		public CoContravariantFunc(Func<T1, T2, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, TResult>(Func<T1, T2, TResult> func) { return new CoContravariantFunc<T1, T2, TResult>(func); }
		public static implicit operator Func<T1, T2, TResult>(CoContravariantFunc<T1, T2, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, TResult> operator +(CoContravariantFunc<T1, T2, TResult> cf, Func<T1, T2, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, TResult> operator -(CoContravariantFunc<T1, T2, TResult> cf, Func<T1, T2, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func) { return new CoContravariantFunc<T1, T2, T3, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, TResult>(CoContravariantFunc<T1, T2, T3, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, TResult> operator +(CoContravariantFunc<T1, T2, T3, TResult> cf, Func<T1, T2, T3, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, TResult> operator -(CoContravariantFunc<T1, T2, T3, TResult> cf, Func<T1, T2, T3, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, TResult>(CoContravariantFunc<T1, T2, T3, T4, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, TResult> cf, Func<T1, T2, T3, T4, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, TResult> cf, Func<T1, T2, T3, T4, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, TResult> cf, Func<T1, T2, T3, T4, T5, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, TResult> cf, Func<T1, T2, T3, T4, T5, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> cf, Func<T1, T2, T3, T4, T5, T6, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, TResult> cf, Func<T1, T2, T3, T4, T5, T6, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
			return result;
		}
	}

	public class CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> : CoContravariantDelegateBase<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>> {
		public CoContravariantFunc(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) : base(func) {}
		public static implicit operator CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) { return new CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(func); }
		public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> cfunc) { return cfunc.Invoke; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> operator +(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) { cf.Add(func); return cf; }
		public static CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> operator -(CoContravariantFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> cf, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) { cf.Remove(func); return cf; }

		public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) {
			var array = GetInvocationList();
			var result = default(TResult);
			for (var i = 0; i < array.Length; i++)
				result = array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
			return result;
		}
	}

}