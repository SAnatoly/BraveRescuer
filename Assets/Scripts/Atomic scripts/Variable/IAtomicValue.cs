
    using System;

    public interface IAtomicValue<T>
    {
        T Value { get; }
    }

    
    public class AtomicValue<T> : IAtomicValue<T>
    {
        public T Value => function.Invoke();

        private readonly Func<T> function;

        public AtomicValue(Func<T> _function)
        {
            function = _function;
        }
    }
