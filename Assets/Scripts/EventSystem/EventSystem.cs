using System;
using UnityEngine;

namespace EventSystem
{
    public class EventSystem: MonoBehaviour
    {
        public static EventSystem _instance;

        public AtomicEvent<GameObject> onFireDead;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        
    }
}