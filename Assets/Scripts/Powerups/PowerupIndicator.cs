using System.Collections;
using UnityEngine;

public class PowerupIndicator : MonoBehaviour
{
    private bool _isActive;
    private string _indicatorObjectName;
    private GameObject _indicator;

    private void Start()
    {
        _isActive = false;
        _indicatorObjectName = "Powerup Indicator";
        _indicator = FindChildPowerupIndicatorObject();
    }

    public bool IsActive => _isActive;

    public void Activate()
    {
        _isActive = true;
        _indicator.SetActive(_isActive);
    }

    public void ActivateTimerToDeactivate(float actionTime)
    {
        _ = StartCoroutine(PowerupCountDownRoutine(actionTime));
    }

    private GameObject FindChildPowerupIndicatorObject()
    {
        Transform powerupTransform = transform.Find(_indicatorObjectName);

        if (powerupTransform != null)
        {
            return powerupTransform.gameObject;
        }

        return null;
    }

    private IEnumerator PowerupCountDownRoutine(float actionTime)
    {
        yield return new WaitForSeconds(actionTime);
        _isActive = false;
        _indicator.SetActive(_isActive);
    }
}
