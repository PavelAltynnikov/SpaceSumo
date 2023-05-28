using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyOnUnboundCommand : MonoBehaviour
    {
        [SerializeField] private float _horizontalUnbound;
        [SerializeField] private float _verticalUnbound;

        [SerializeField] private Game _game;

        public delegate void RemoveObjectDelegate(GameObject object_);

        public RemoveObjectDelegate RemoveObject;

        private void Start()
        {
            _game = FindObjectOfType<Game>();
        }

        private void Update()
        {
            if (transform.position.y < -_verticalUnbound
                || transform.position.x >= _horizontalUnbound
                || transform.position.x <= -_horizontalUnbound
                || transform.position.z >= _horizontalUnbound
                || transform.position.z <= -_horizontalUnbound)
            {
                if (CompareTag("Enemy"))
                {
                    var enemy = gameObject.GetComponent<Enemy>();
                    _game?.UpdateScore(enemy.Score);
                }

                Destroy(gameObject);
                RemoveObject?.Invoke(gameObject);
            }
        }
    }
}
