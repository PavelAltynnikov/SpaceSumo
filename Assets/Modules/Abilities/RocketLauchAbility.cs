using System.Collections.Generic;
using SpaceSumo.Domain;
using TMPro;
using UnityEngine;

public class RocketLauchAbility : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _labelUI;
    [SerializeField] private GameObject _rocket;
    [SerializeField] private int _attemptsAmount;

    public void LauchRockets(IEnumerable<GameObject> targets)
    {
        foreach (GameObject target in targets)
        {
            // TODO надо поменять позицию спавна рокеты.
            // Она должна спавнится не внутри игрока, а рядом с ним по направлению к цели.
            // transform.position + Vector3
            GameObject bulletPrefab = Instantiate(_rocket, transform.position, _rocket.transform.rotation);
            Rocket bullet = bulletPrefab.GetComponent<Rocket>();
            bullet.target = target;
        }
    }

    private void Awake()
    {
        _attemptsAmount = 0;
        _labelUI = GameObject.Find("Rocket Label").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (_labelUI != null)
        {
            _labelUI.text = $"Rockets: {_attemptsAmount}";
        }

        TryToActivatePushAbility();
    }

    private void TryToActivatePushAbility()
    {
        if (_attemptsAmount == 0
            || !Input.GetKeyDown(KeyCode.E))
        {
            return;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        LauchRockets(enemies);
        _attemptsAmount--;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Powerup")
            || !collider.gameObject.name.Contains("Gem Rocket"))
        {
            return;
        }

        _attemptsAmount++;
        Destroy(collider.gameObject);
    }
}
