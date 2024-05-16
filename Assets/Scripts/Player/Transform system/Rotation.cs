using UnityEngine;

namespace Player
{
    public class Rotation
    {
        private readonly IAtomicVarible<Vector3> _rotationDiraction;
        private readonly IAtomicValue<float> _speedRotationRotation;
        private readonly Transform _target;

        public Rotation(IAtomicVarible<Vector3> rotationDiraction, IAtomicValue<float> speedRotation,
            Transform target)
        {
            _rotationDiraction = rotationDiraction;
            _speedRotationRotation = speedRotation;
            _target = target;
        }

        public void Update()
        {
            _target.Rotate(_rotationDiraction.Value * _speedRotationRotation.Value * Time.deltaTime);
        }
    }
}