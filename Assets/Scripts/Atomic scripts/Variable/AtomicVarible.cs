﻿
    using System;
    using UnityEngine;

    [Serializable]
    public class AtomicVarible<T> : IAtomicVarible<T>
    {
        
        [SerializeField]
        private T _value;

        public event Action<T> ValueChanged;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                this.ValueChanged?.Invoke(value);
            }
        }
    }
