using TMPro;
using UnityEngine;

public class PushAbility : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _labelUI;
    [SerializeField] private int _attemptsAmount;

    private PowerupIndicator _powerupIndicator;
    private PushPowerup _powerup;

    private void Start()
    {
        _attemptsAmount = 0;
        _labelUI = GameObject.Find("Push Label").GetComponent<TextMeshProUGUI>();
        _powerupIndicator = gameObject.GetComponent<PowerupIndicator>();
    }

    private void Update()
    {
        if (_labelUI != null)
        {
            _labelUI.text = $"Push: {_attemptsAmount}";
        }

        TryToActivatePushAbility();
    }

    private void TryToActivatePushAbility()
    {
        if (_attemptsAmount == 0
            || !Input.GetKeyDown(KeyCode.Q))
        {
            return;
        }

        _powerupIndicator.Activate();
        _powerupIndicator.ActivateTimerToDeactivate(_powerup.ActionTime);

        _attemptsAmount--;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Powerup")
            || !collider.gameObject.name.Contains("Gem Push"))
        {
            return;
        }

        _attemptsAmount++;
        _powerup = collider.GetComponent<PushPowerup>();
        Destroy(collider.gameObject);
    }

    private void OnCollisionEnter(Collision enemy)
    {
        if (!_powerupIndicator.IsActive)
        {
            if (_powerup != null)
            {
                _powerup = null;
            }

            return;
        }

        if (enemy.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = enemy.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = enemy.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * _powerup.Strength, ForceMode.Impulse);
        }
    }
}
