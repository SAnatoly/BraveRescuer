using UnityEngine;

namespace Player
{
    public class Movement
    {
        private readonly IAtomicValue<float> _speed;
        private readonly AtomicVarible<Vector3> _moveDiraction;
        private readonly Transform _target;

        public Movement(IAtomicValue<float> speed, AtomicVarible<Vector3> moveDiraction, Transform target)
        {
            _speed = speed;
            _moveDiraction = moveDiraction;
            _target = target;
        }

        public void Update()
        {
            _target.Translate(_moveDiraction.Value * _speed.Value * Time.deltaTime); 
        }
    }
}