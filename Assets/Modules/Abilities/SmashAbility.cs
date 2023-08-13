using System.Collections.Generic;
using SpaceSumo.Game;
using TMPro;
using UnityEngine;

public class SmashAbility : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private int _attemptsAmount;
    [SerializeField] private TextMeshProUGUI _labelUI;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private AudioSource _sound;

    private bool _isActivateSmash;
    private Player _player;
    private Rigidbody _playerBody;

    private void Start()
    {
        _attemptsAmount = 0;
        _isActivateSmash = false;
        _labelUI = GameObject.Find("Smash Label").GetComponent<TextMeshProUGUI>();
        _player = GetComponent<Player>();
        _playerBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_labelUI != null)
        {
            _labelUI.text = $"Smash: {_attemptsAmount}";
        }

        TryToSmash();
    }

    private void TryToSmash()
    {
        if (_attemptsAmount == 0
            || _player.IsOnGround
            || !Input.GetKeyDown(KeyCode.W))
        {
            return;
        }

        _isActivateSmash = true;
        _playerBody.AddForce(Vector3.down * _force, ForceMode.Impulse);
        _attemptsAmount--;
    }

    private void PushEnemies(IEnumerable<GameObject> targets)
    {
        foreach (GameObject target in targets)
        {
            var targetRb = target.GetComponent<Rigidbody>();

            Vector3 directionToTarget = target.transform.position - transform.position;
            float distance = Vector3.Distance(target.transform.position, transform.position);

            targetRb.AddForce(directionToTarget.normalized * _force / distance, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Powerup")
            || !collider.gameObject.name.Contains("Gem Smash"))
        {
            return;
        }

        _attemptsAmount++;

        Destroy(collider.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground")
            || !_isActivateSmash)
        {
            return;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        PushEnemies(enemies);
        _isActivateSmash = false;
        _particles.Play();

        _sound.volume = 0.3f;
        _sound.Play();
    }
}
