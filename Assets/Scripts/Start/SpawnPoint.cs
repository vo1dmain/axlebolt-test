using UnityEngine;

namespace Assets.Scripts.Start
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private GameObject _objectToSpawn;

        public GameObject Spawn()
        {
            return Instantiate(_objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}