using UnityEngine;

namespace SpaceSumo.Game
{
    public class Enemy : MonoBehaviour
    {
        public GameObject target;

        [SerializeField] private float _speed;
        [SerializeField] private int _score;

        private Rigidbody _rigidBody;

        public int Score => _score;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (target == null)
            {
                return;
            }

            Vector3 directionToTarget = target.transform.position - transform.position;

            _rigidBody.AddForce(directionToTarget.normalized * _speed);
        }
    }
}
