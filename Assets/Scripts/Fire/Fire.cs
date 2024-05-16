
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fire_T
{
    public class Fire: MonoBehaviour
    { 
        [SerializeField] private AtomicVarible<ParticleSystem> _firePS;
        [SerializeField] private AtomicVarible<float> _emitFire;
        [SerializeField] private AtomicVarible<float> _spreadValue;
        [SerializeField] private Fire _prefabReference;
        private SpreadMechanic _spreadMechanic;
        
        private void Awake()
        {
            
            
        }

        public void OnEnable()
        {
            Reset();
            ParticleSystem fire = _firePS.Value.transform.parent.GetComponent<ParticleSystem>();
            fire.Play();
            _spreadMechanic = new SpreadMechanic(_emitFire, _firePS, _spreadValue);
            
        }

        public void Update()
        {
            if (_spreadMechanic._fireShape.scale.x <= 0.5f)
            {
               
                Kill();
        
            }
        }

        public void Spread()
        {
            _spreadMechanic.Spread();
        }

        public void Kill()
        {
            
            ParticleSystem fire = _firePS.Value.transform.parent.GetComponent<ParticleSystem>();
            fire.Stop();
            EventSystem.EventSystem._instance.onFireDead.Invoke(fire.gameObject);
            
        }

        public void Reset()
        {
            ParticleSystem.ShapeModule shape = _firePS.Value.shape;
            shape.scale = _prefabReference._firePS.Value.shape.scale;

            ParticleSystem.MainModule main = _firePS.Value.main;
            main.startSize = _prefabReference._firePS.Value.main.startSize;

            _emitFire = _prefabReference._emitFire;
        }
    }
}