using UnityEngine;

namespace SpaceSumo.Domain
{
    public class RotateCamera : MonoBehaviour
    {
        [SerializeField] private int _rotationSpeed;

        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * _rotationSpeed * horizontalInput * Time.deltaTime);
        }
    }
}