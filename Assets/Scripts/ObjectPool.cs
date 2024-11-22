using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private SpawnableObject _prefab;

    private Queue<SpawnableObject> _pool;
    
    private void Awake()
    {
        _pool = new Queue<SpawnableObject>();
    }

    public SpawnableObject GetObject()
    {
        if (_pool.Count == 0)
        {
            var obj = Instantiate(_prefab);
            obj.transform.parent = _container;
    
            return obj;
        }
    
        return _pool.Dequeue();
    }
    
    public void PutObject(SpawnableObject obj)
    {
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
    
    public void Reset()
    {
        _pool.Clear();
    }
}