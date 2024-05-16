using System;

[Serializable]
public sealed class AtomicEvent<T> : IAtomicEvent<T>
{
   private event Action<T> onEvent;

   public void Invoke(T value)
   {
      this.onEvent?.Invoke(value);
   }

   public void Subscribe(Action<T> action)
   {
      this.onEvent += action;
   }

   public void Unsubscribe(Action<T> action)
   {
      this.onEvent -= action;
   }
}

[Serializable]
public sealed class AtomicEvent : IAtomicEvent
{
   private event Action onEvent;

   public void Subscribe(Action action)
   {
      onEvent += action;
   }

   public void Unsubscribe(Action action)
   {
      onEvent -= action;
   }

   public void Invoke()
   {
      onEvent?.Invoke();
   }
}
