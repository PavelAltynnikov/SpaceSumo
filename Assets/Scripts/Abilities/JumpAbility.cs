using UnityEngine;

public class JumpAbility : MonoBehaviour
{
    [SerializeField] private float _force;

    private Player _player;
    private Rigidbody _playerBody;

    private void Start()
    {
        _player = GetComponent<Player>();
        _playerBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        TryToJump();
    }

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

        _playerBody.AddForce(Vector3.up * _force, ForceMode.Impulse);
    }
}
