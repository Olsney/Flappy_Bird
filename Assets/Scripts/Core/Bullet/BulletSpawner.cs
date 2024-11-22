using UnityEngine;

namespace DefaultNamespace
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPool _pool;
        
        public void Spawn(Vector3 position)
        {
            var spawnableObject = _pool.GetObject();

            spawnableObject.Collided += OnCollided;

            spawnableObject.gameObject.SetActive(true);
            spawnableObject.transform.position = position;
        }

        private void OnCollided(SpawnableObject obj)
        {
            _pool.PutObject(obj);
        
            obj.Collided -= OnCollided;
        }
    }
}