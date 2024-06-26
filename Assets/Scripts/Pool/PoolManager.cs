﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

namespace Pool
{
    public class PoolManager: MonoBehaviour
    {
        private PoolMechanics _poolMechanics;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _poolSize;

        public void Awake()
        {
            _poolMechanics = new PoolMechanics(_prefab, _poolSize);
        }

        public void Start()
        {
            EventSystem.EventSystem._instance.onFireDead.Subscribe(ObjectDead);

            StartCoroutine(InstantiateObjectsWithDelay());
        }

        private IEnumerator InstantiateObjectsWithDelay()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                InstatiateObject();
                yield return new WaitForSeconds(Random.Range(1, 3f)); // Задержка между созданием объектов
            }
        }

        
        public void InstatiateObject()
        {
            GameObject obj = _poolMechanics.GetObject();
            obj.transform.position = GetRandomPosition();
        }

        public Vector3 GetRandomPosition()
        {
            return new Vector3(Random.Range(-3.5f, 3.5f), 0, Random.Range(-5f, 6f));
        }

        public void ObjectDead(GameObject gameObject)
        {
            _poolMechanics.ReturnObject(gameObject);
            InstatiateObject();
        }
    }
}