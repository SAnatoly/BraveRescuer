using System.Collections.Generic;
using Fire_T;
using Unity.VisualScripting;
using UnityEngine;

namespace Pool
{
    public class PoolMechanics
    {
        private readonly GameObject _prefab;
        private readonly int _poolSize;

        private Queue<GameObject> _pool;

        public PoolMechanics(GameObject prefab, int poolSize)
        {
            _prefab = prefab;
            _poolSize = poolSize;

            _pool = new Queue<GameObject>();

            for (int i = 0; i < _poolSize; i++)
            {
                GameObject obj = Object.Instantiate(_prefab);
                obj.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public GameObject GetObject()
        {
            if (_pool.Count > 0)
            {
                GameObject obj = _pool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else
            {
                GameObject obj = Object.Instantiate(_prefab);
                return obj;
            }
        }

        public void ReturnObject(GameObject obj)
        {
           
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }

        public void ResetObject(GameObject obj)
        {
            ParticleSystem.ShapeModule objShape = obj.GetComponent<ParticleSystem.ShapeModule>();
            objShape.scale = _prefab.GetComponent<ParticleSystem.ShapeModule>().scale;
            //obj.GetComponent<Fire>(). = _prefab.GetComponent<ParticleSystem>().main.startSize;
        }
    }
}