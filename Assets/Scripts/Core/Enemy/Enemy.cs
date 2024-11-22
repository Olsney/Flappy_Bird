using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class Enemy : SpawnableObject, IInteractable
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private Transform _bulletSpawnPoint;
    
    private ScoreModel _scoreModel;
    private BulletSpawner _bulletSpawner;
    
    public void Init(ScoreModel scoreModel, BulletSpawner bulletSpawner)
    {
        _scoreModel = scoreModel;
        _bulletSpawner = bulletSpawner;
    }
    
    public void Shoot()
    {
        StartCoroutine(Attacking());
    }
    
    private IEnumerator Attacking()
    {
        var wait = new WaitForSeconds(_attackDelay);

        while (enabled) 
        {
            _bulletSpawner.Spawn(_bulletSpawnPoint.position);
            
            yield return wait;
        }
    }
    
    protected override void OnTouched(IInteractable obj)
    {
        base.OnTouched(obj);
        
        if (obj is Bullet)
            _scoreModel.Increase();
    }
}