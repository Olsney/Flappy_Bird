using DefaultNamespace;
using UnityEngine;

public class Bullet : SpawnableObject, IInteractable
{
    [field:SerializeField] public BulletType Type { get; private set; }
}