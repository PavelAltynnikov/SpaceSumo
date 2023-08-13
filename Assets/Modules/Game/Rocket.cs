using System.Collections;
using UnityEngine;

namespace SpaceSumo.Game
{
    public class Rocket : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        [SerializeField] private float _strength;
        [SerializeField] private float _speed;
        [SerializeField] private ParticleSystem _explosionParticles;
        [SerializeField] private AudioSource _explosionSound;

        public GameObject target;

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

            transform.LookAt(target.transform);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                PushTarget(collision);
                StartCoroutine(DestoryAfterPlay());
                Destroy(gameObject);
            }
        }

        private void PushTarget(Collision collision)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * _strength, ForceMode.Impulse);
        }

        private IEnumerator DestoryAfterPlay()
        {
            ParticleSystem explosionParticles = Instantiate(
                _explosionParticles, transform.position, transform.rotation
            );
            AudioSource explosionSound = Instantiate(
                _explosionSound, transform.position, transform.rotation
            );

            explosionParticles.Play();

            explosionSound.volume = 0.3f;
            explosionSound.Play();

            while (explosionParticles.isPlaying || explosionSound.isPlaying)
            {
                yield return 1;
            }

            Destroy(explosionParticles.gameObject);
            Destroy(explosionSound.gameObject);
        }
    }
}
