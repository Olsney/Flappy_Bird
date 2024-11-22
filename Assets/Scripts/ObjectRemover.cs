using DefaultNamespace;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _enemyPool;
    [SerializeField] private ObjectPool _enemyBulletPool;
    [SerializeField] private ObjectPool _playerBulletPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out SpawnableObject obj))
        {
            if (obj is Bullet bullet)
            {
                if (bullet.Type == BulletType.EnemyBullet)
                {
                    _enemyBulletPool.PutObject(obj);

                    return;
                }

                if (bullet.Type == BulletType.PlayerBullet)
                {
                    _playerBulletPool.PutObject(obj);

                    return;
                }
            }

            if (obj is Enemy)
            {
                _enemyPool.PutObject(obj);

                return;
            }
        }
    }
}