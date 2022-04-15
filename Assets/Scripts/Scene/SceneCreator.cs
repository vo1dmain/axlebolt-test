
using System;

using Assets.Scripts.Finish;
using Assets.Scripts.Start;

using UnityEngine;

namespace Assets.Scripts.Scene
{
    public class SceneCreator : MonoBehaviour
    {
        [SerializeField]
        private Bounds.Bounds _bounds;

        [SerializeField]
        private SpawnPoint _spawnAsset;

        [SerializeField]
        private FinishPoint _finishAsset;

        

        public SpawnPoint CreateSpawn()
        {
            if (_spawnAsset is null) throw new NullReferenceException();

            var spawnX = _bounds.Left + (_spawnAsset.transform.localScale.x / 2);
            var spawnY = _bounds.Top - (_spawnAsset.transform.localScale.y / 2);
            var spawnPosition = new Vector3(spawnX, spawnY, 0f);
            return Instantiate(_spawnAsset, spawnPosition, Quaternion.identity);
        }


        public FinishPoint CreateFinish()
        {
            if (_finishAsset is null) throw new NullReferenceException();

            var finishX = _bounds.Right - (_finishAsset.transform.localScale.x / 2);
            var finishY = _bounds.Bottom + (_finishAsset.transform.localScale.y / 2);
            var finishPosition = new Vector3(finishX, finishY, 0f);
            return Instantiate(_finishAsset, finishPosition, Quaternion.identity);
        }
    }
}
