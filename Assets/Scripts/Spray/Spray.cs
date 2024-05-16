using System;
using System.Collections.Generic;
using Fire_T;
using UnityEngine;

namespace Spray
{
    public class Spray: MonoBehaviour
    {

        [SerializeField] private AtomicVarible<ParticleSystem> _spray;
        private ParticleSystem.Particle[] particles;

        public void ActivateSpray()
        {
            if(!_spray.Value.isPlaying)
            _spray.Value.Play();
        }

        public void DiactivateSpray()
        {
            if(!_spray.Value.isStopped)
            _spray.Value.Stop();
        }
        
        private void OnParticleCollision(GameObject other)
        {
            other.GetComponentInParent<Fire>().Spread();
        }
    }
}