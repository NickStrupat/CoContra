﻿using System;

namespace CoContra {
	public class CovariantAction<T> : CoContravariantDelegateBase<Action<T>> {
		public CovariantAction(Action<T> action) : base(action) {}
		public static implicit operator CovariantAction<T>(Action<T> action) { return new CovariantAction<T>(action); }
		public static implicit operator Action<T>(CovariantAction<T> caction) { return caction.Invoke; }
		public static CovariantAction<T> operator +(CovariantAction<T> cf, Action<T> action) { cf.Add(action); return cf; }
		public static CovariantAction<T> operator -(CovariantAction<T> cf, Action<T> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T> left, CovariantAction<T> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T> left, CovariantAction<T> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T arg) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2> : CoContravariantDelegateBase<Action<T1, T2>> {
		public CovariantAction(Action<T1, T2> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2>(Action<T1, T2> action) { return new CovariantAction<T1, T2>(action); }
		public static implicit operator Action<T1, T2>(CovariantAction<T1, T2> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2> operator +(CovariantAction<T1, T2> cf, Action<T1, T2> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2> operator -(CovariantAction<T1, T2> cf, Action<T1, T2> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2> left, CovariantAction<T1, T2> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2> left, CovariantAction<T1, T2> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3> : CoContravariantDelegateBase<Action<T1, T2, T3>> {
		public CovariantAction(Action<T1, T2, T3> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3>(Action<T1, T2, T3> action) { return new CovariantAction<T1, T2, T3>(action); }
		public static implicit operator Action<T1, T2, T3>(CovariantAction<T1, T2, T3> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3> operator +(CovariantAction<T1, T2, T3> cf, Action<T1, T2, T3> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3> operator -(CovariantAction<T1, T2, T3> cf, Action<T1, T2, T3> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3> left, CovariantAction<T1, T2, T3> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3> left, CovariantAction<T1, T2, T3> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4> : CoContravariantDelegateBase<Action<T1, T2, T3, T4>> {
		public CovariantAction(Action<T1, T2, T3, T4> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action) { return new CovariantAction<T1, T2, T3, T4>(action); }
		public static implicit operator Action<T1, T2, T3, T4>(CovariantAction<T1, T2, T3, T4> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4> operator +(CovariantAction<T1, T2, T3, T4> cf, Action<T1, T2, T3, T4> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4> operator -(CovariantAction<T1, T2, T3, T4> cf, Action<T1, T2, T3, T4> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4> left, CovariantAction<T1, T2, T3, T4> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4> left, CovariantAction<T1, T2, T3, T4> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action) { return new CovariantAction<T1, T2, T3, T4, T5>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5>(CovariantAction<T1, T2, T3, T4, T5> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5> operator +(CovariantAction<T1, T2, T3, T4, T5> cf, Action<T1, T2, T3, T4, T5> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5> operator -(CovariantAction<T1, T2, T3, T4, T5> cf, Action<T1, T2, T3, T4, T5> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5> left, CovariantAction<T1, T2, T3, T4, T5> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5> left, CovariantAction<T1, T2, T3, T4, T5> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6>(CovariantAction<T1, T2, T3, T4, T5, T6> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6> operator +(CovariantAction<T1, T2, T3, T4, T5, T6> cf, Action<T1, T2, T3, T4, T5, T6> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6> operator -(CovariantAction<T1, T2, T3, T4, T5, T6> cf, Action<T1, T2, T3, T4, T5, T6> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6> left, CovariantAction<T1, T2, T3, T4, T5, T6> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6> left, CovariantAction<T1, T2, T3, T4, T5, T6> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6, T7> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6, T7>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7>(CovariantAction<T1, T2, T3, T4, T5, T6, T7> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7> operator +(CovariantAction<T1, T2, T3, T4, T5, T6, T7> cf, Action<T1, T2, T3, T4, T5, T6, T7> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7> operator -(CovariantAction<T1, T2, T3, T4, T5, T6, T7> cf, Action<T1, T2, T3, T4, T5, T6, T7> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6, T7> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6, T7> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> operator +(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> operator -(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> operator +(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> operator -(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> operator +(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> operator -(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> operator +(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> operator -(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> operator +(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> operator -(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> operator +(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> operator -(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> operator +(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> operator -(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> operator +(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> operator -(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

	public class CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : CoContravariantDelegateBase<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> {
		public CovariantAction(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) : base(action) {}
		public static implicit operator CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) { return new CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(action); }
		public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> caction) { return caction.Invoke; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> operator +(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) { cf.Add(action); return cf; }
		public static CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> operator -(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> cf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) { cf.Remove(action); return cf; }
		public static Boolean operator ==(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> right) => left?.GetInvocationList() == right?.GetInvocationList();
		public static Boolean operator !=(CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> left, CovariantAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> right) => left?.GetInvocationList() != right?.GetInvocationList();
		
		public Object Target => GetSingleOrNull()?.Target;

		public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
		}

		public override Object DynamicInvoke(params Object[] args) {
			var array = GetInvocationList();
			var result = default(Object);
			for (var i = 0; i < array.Length; i++)
				result = array[i].DynamicInvoke(args);
			return result;
		}
	}

}