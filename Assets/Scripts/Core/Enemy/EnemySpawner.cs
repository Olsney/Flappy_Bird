using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private float _lowerBound;
        [SerializeField] private float _upperBound;
        [SerializeField] private ObjectPool _pool;
        [SerializeField] private ScoreModel _scoreModel;
        [SerializeField] private BulletSpawner _bulletSpawner;

        private void Start()
        {
            StartCoroutine(Generate());
        }
    
        private IEnumerator Generate()
        {
            var wait = new WaitForSeconds(_delay);

            while (true) 
            {
                Spawn();
                yield return wait;
            }
        }

        private void Spawn()
        {
            float spawnPositionY = Random.Range(_upperBound, _lowerBound);
            Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

            var enemy = _pool.GetObject() as Enemy;

            if (enemy == null)
                return;
            
            enemy.Collided += OnCollided;
            
            enemy.Init(_scoreModel, _bulletSpawner);

            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPoint;
            
            enemy.Shoot();
        }

        private void OnCollided(SpawnableObject obj)
        {
            _pool.PutObject(obj);
        
            obj.Collided -= OnCollided;
        }
    }
}