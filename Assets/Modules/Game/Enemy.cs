using UnityEngine;

namespace SpaceSumo.Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] public Transform _target;

        private Rigidbody _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_target is null)
            {
                return;
            }

            Vector3 directionToTarget = _target.position - transform.position;

            _rigidBody.AddForce(directionToTarget.normalized * _speed);
        }
    }
}
