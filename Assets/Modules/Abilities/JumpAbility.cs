using System;
using UnityEngine;
using SpaceSumo.Game;

namespace SpaceSumo.Abilities
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(Rigidbody))]
    public class JumpAbility : MonoBehaviour
    {
        [SerializeField] private float _force;

        private Player _player;
        private Rigidbody _playerBody;

        # region Implement MonoBehaviour Methods
            private void Start()
            {
            _player = GetComponent<Player>();
            _playerBody = GetComponent<Rigidbody>();
            }
            
            private void Update()
            {
                TryToJump();
            }
            # endregion

        private void TryToJump()
        {
            if (!_player.IsOnGround)
            {
                return;
            }

            float jumpInput = Input.GetAxis("Jump");

            if (jumpInput <= 0.01)
            {
                return;
            }

            Jump();
        }

        private void Jump()
        {
            if (_force == 0)
            {
                Debug.LogError(
                    $"Чтобы прыгнуть параметр силы \"{nameof(_force)}\" не может быть равен нулю.",
                    this
                );
                return;
            }

            _playerBody.AddForce(Vector3.up * _force, ForceMode.Impulse);
        }
    }
}
