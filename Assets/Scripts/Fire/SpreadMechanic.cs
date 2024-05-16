using UnityEngine;

namespace Fire_T
{
    public class SpreadMechanic
    {
        private readonly AtomicVarible<float> _emitFire;
        private readonly AtomicVarible<ParticleSystem> _firePS;
        private readonly AtomicVarible<float> _spreadValue;
        public float indexScaleFire = -1;
        
        public ParticleSystem.ShapeModule _fireShape;
        
        public SpreadMechanic(AtomicVarible<float> emitFire, AtomicVarible<ParticleSystem> firePS, AtomicVarible<float> spreadValue)
        {
            _emitFire = emitFire;
            _firePS = firePS;
            _spreadValue = spreadValue;
            _fireShape = _firePS.Value.shape;
        }
        
        public void Spread()
        { 
            _emitFire.Value -= .5f;
            var fireRate = _firePS.Value.emission;
            fireRate.rateOverTime = _emitFire.Value;
            _firePS.Value.startSize += (indexScaleFire / 100) * Time.deltaTime;
            _fireShape.scale += new Vector3((_spreadValue.Value) * Time.deltaTime, (_spreadValue.Value) * Time.deltaTime, 0);
        }

    }
}