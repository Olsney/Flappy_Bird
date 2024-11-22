using UnityEngine;

namespace DefaultNamespace
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _horizontalDirection;

        private Vector3 _direction;

        private void OnEnable()
        {
            _direction = new Vector3(_horizontalDirection, 0, 0);
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(
                transform.position, transform.position + _direction,
                _speed * Time.deltaTime);
        }
    }
}