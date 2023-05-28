using System;
using UnityEngine;

public class MoveAbility : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Player _player;
    private Rigidbody _playerBody;
    private GameObject _focalPoint;

    public void Start()
    {
        _player = GetComponent<Player>();
        _playerBody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        if (_player.IsOnGround)
        {
            TryToMove();
        }
    }

    private void TryToMove()
    {
        if (_focalPoint == null)
        {
            throw new InvalidOperationException("Player can not move without focal point");
        }

        float verticalInput = Input.GetAxis("Vertical");
        _playerBody.AddForce(_focalPoint.transform.forward * verticalInput * _speed);
    }
}
