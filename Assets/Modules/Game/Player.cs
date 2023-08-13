using UnityEngine;

namespace SpaceSumo.Game
{
    public class Player : MonoBehaviour
    {
        private bool _isOnGround;

        public bool IsOnGround => _isOnGround;

        private void Start()
        {
            _isOnGround = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isOnGround = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isOnGround = false;
            }
        }
    }
}
