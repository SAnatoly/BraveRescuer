
    using System;
    
    public interface IAtomicVarible<T> : IAtomicValue<T>
    {
        event Action<T> ValueChanged;
        new T Value { get; set; }
    }
