using System.Collections.Generic;
using DefaultNamespace.Listeners;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.GameManager
{
    public class GameManager: MonoBehaviour
    {
        [SerializeField, ReadOnly] private GameState _gameState;

        private List<IGameListener> _listeners = new();
        private List<IGameUpdateListener> _updateListener = new();
        private List<IGameLateUpdateListener> _lateUpdateListeners = new();
        private List<IGameFixedUpdateListener> _fixedUpdateListeners = new();


        public void AddListener(IGameListener listener)
        {
            _listeners.Add(listener);

            if (listener is IGameUpdateListener updateListeners)
            {
                _updateListener.Add(updateListeners);
            }
            
              if (listener is IGameLateUpdateListener lateUpdateListener)
            {
                _lateUpdateListeners.Add(lateUpdateListener);
            }

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                _fixedUpdateListeners.Add(fixedUpdateListener);
            }
        }

        public void AddListeners(GameObject parent)
        {
            IGameListener[] listeners = parent.GetComponentsInChildren<IGameListener>();

            foreach (var gameListener in listeners)
            {
                AddListener(gameListener);
            }
        }
        
        public void RemoveListener(IGameListener listener)
        {
            _listeners.Remove(listener);
            if (listener is IGameUpdateListener updateListener)
            {
                _updateListener.Remove(updateListener);
            }

            if (listener is IGameLateUpdateListener lateUpdateListener)
            {
                _lateUpdateListeners.Remove(lateUpdateListener);
            }

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                _fixedUpdateListeners.Remove(fixedUpdateListener);
            }
        }
        
        public void StartGame()
        {

            if (_gameState != GameState.None)
                return;
            
            foreach(var gameListeners in _listeners)
            {
                if(gameListeners is IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }
            _gameState = GameState.Start;
        }

        public void PauseGame()
        {
            if(_gameState != GameState.Playing)
                return;
            
            foreach (var gameListeners in _listeners)
            {
                if (gameListeners is IGamePauseListener startListener)
                {
                    startListener.OnPause();
                }
            }
            _gameState = GameState.Pause;
        }

        public void PlayingGame()
        {
            Debug.Log("Playing");
            if(_gameState != GameState.Pause && _gameState != GameState.Start)
                return;
            
            foreach (var gameListeners in _listeners)
            {
                if (gameListeners is IGamePlayingListener startListener)
                {
                    startListener.OnPlaying();
                }
            }
            _gameState = GameState.Playing;
        }

        public void FinishGame()
        {
            if(_gameState is GameState.None or GameState.Finish)
                return;
            
            foreach (var gameListeners in _listeners)
            {
                if (gameListeners is IGameFinishListener startListener)
                {
                    startListener.OnFinish();
                }
            }
            _gameState = GameState.Finish;
            Time.timeScale = 0;
        }

        public void Update()
        {
            if(_gameState != GameState.Playing)
                return;
            Debug.Log("Update");
            for (int i = 0; i < _updateListener.Count; i++)
            {
                _updateListener[i].OnUpdate(Time.deltaTime);
            }
        }

        public void LateUpdate()
        {
            if(_gameState != GameState.Playing)
                return;
            
            for (int i = 0; i < _lateUpdateListeners.Count; i++)
            {
                _lateUpdateListeners[i].OnLateUpdate(Time.deltaTime);
            }
        }

        public void FixedUpdate()
        {
            if(_gameState != GameState.Playing)
                return;
            
            for (int i = 0; i < _fixedUpdateListeners.Count; i++)
            {
                _fixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }
    }
}