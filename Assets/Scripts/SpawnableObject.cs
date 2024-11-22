using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class SpawnableObject : MonoBehaviour
    {
        [SerializeField] private CollisionHandler _handler;
        [SerializeField] private Mover _mover;

        public event Action<SpawnableObject> Collided;

        private void OnEnable()
        {
            _handler.CollisionDetected += OnTouched;
        }

        private void OnDisable()
        {
            _handler.CollisionDetected -= OnTouched;
        }

        protected virtual void OnTouched(IInteractable _)
        {
            Collided?.Invoke(this);
        }
    }
}