using System;

namespace CoContra {
	public class CovariantEventHandler : CoContravariantDelegateBase<EventHandler> {
		public CovariantEventHandler(EventHandler eventHandler) : base(eventHandler) { }
		public static implicit operator CovariantEventHandler(EventHandler action) { return new CovariantEventHandler(action); }
		public static implicit operator EventHandler(CovariantEventHandler caction) { return caction.Invoke; }
		public static CovariantEventHandler operator +(CovariantEventHandler ceh, EventHandler action) { ceh.Add(action); return ceh; }
		public static CovariantEventHandler operator -(CovariantEventHandler ceh, EventHandler action) { ceh.Remove(action); return ceh; }

		public void Invoke(Object sender, EventArgs eventArgs) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(sender, eventArgs);
		}
	}
#if !NET4
	public class CovariantEventHandler<TEventArgs> : CoContravariantDelegateBase<EventHandler<TEventArgs>> {
		public CovariantEventHandler(EventHandler<TEventArgs> eventHandler) : base(eventHandler) { }
		public static implicit operator CovariantEventHandler<TEventArgs>(EventHandler<TEventArgs> eventHandler) { return new CovariantEventHandler<TEventArgs>(eventHandler); }
		public static implicit operator EventHandler<TEventArgs>(CovariantEventHandler<TEventArgs> ceventHandler) { return ceventHandler.Invoke; }
		public static CovariantEventHandler<TEventArgs> operator +(CovariantEventHandler<TEventArgs> ceh, EventHandler<TEventArgs> action) { ceh.Add(action); return ceh; }
		public static CovariantEventHandler<TEventArgs> operator -(CovariantEventHandler<TEventArgs> ceh, EventHandler<TEventArgs> action) { ceh.Remove(action); return ceh; }

		public void Invoke(Object sender, TEventArgs eventArgs) {
			var array = GetInvocationList();
			for (var i = 0; i < array.Length; i++)
				array[i].Invoke(sender, eventArgs);
		}
	}
#endif
}
