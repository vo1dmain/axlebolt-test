using System;
using System.Collections.Generic;

using Assets.Scripts.Finish;
using Assets.Scripts.Start;

using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Scene
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private SceneCreator _creator;

        [SerializeField]
        private UnityEvent _sceneFinished;


        private SpawnPoint _spawnInstance;
        private FinishPoint _finishInstance;

        private State _state = State.Init;


        public void StartScene()
        {
            _finishInstance = _creator.CreateFinish();
            _finishInstance.Crossed += OnFinishCrossed;
            _sceneObjects.Add(_finishInstance.gameObject);

            _spawnInstance = _creator.CreateSpawn();
            _sceneObjects.Add(_spawnInstance.gameObject);

            var motionObject = _spawnInstance.Spawn();
            _sceneObjects.Add(motionObject);

            if (!motionObject.TryGetComponent(out IBeginable beginable)) throw new InvalidOperationException();

            beginable.Begin();

            _state = State.Playing;
        }

        public void ResetScene()
        {
            if (_state == State.Destroyed) return;
            if (_finishInstance is not null) _finishInstance.Crossed -= OnFinishCrossed;

            _finishInstance = null;
            _spawnInstance = null;

            foreach (var o in _sceneObjects)
            {
                Destroy(o);
            }

            _sceneObjects.Clear();

            _state = State.Destroyed;
        }

        public void RestartScene()
        {
            ResetScene();
            StartScene();
        }



        private void OnFinishCrossed(IFinishable finisher)
        {
            _state = State.Finished;
            _sceneFinished?.Invoke();
        }



        private readonly List<GameObject> _sceneObjects = new();



        public enum State : byte
        {
            Init,
            Playing,
            Finished,
            Destroyed
        }
    }
}