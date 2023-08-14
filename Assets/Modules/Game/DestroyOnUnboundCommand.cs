using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceSumo.Game
{
    public class DestroyOnUnboundCommand : MonoBehaviour
    {
        [SerializeField] private float _horizontalUnbound;
        [SerializeField] private float _verticalUnbound;

        [FormerlySerializedAs("_game")] [SerializeField] private GameRoot _gameRoot;

        public delegate void RemoveObjectDelegate(GameObject object_);

        public RemoveObjectDelegate RemoveObject;

        private void Start()
        {
            _gameRoot = FindObjectOfType<GameRoot>();
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
                    _gameRoot?.UpdateScore(enemy.Score);
                }

                Destroy(gameObject);
                RemoveObject?.Invoke(gameObject);
            }
        }
    }
}
