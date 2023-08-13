#nullable enable
using UnityEngine;
using UnityEngine.UI;

namespace SpaceSumo.Presentation
{
    public class SettingsMenu : Menu
    {
        [SerializeField] private Button? _backButton;

        private void OnEnable()
        {
            _backButton?.onClick.AddListener(Back);
        }

        private void OnDisable()
        {
            _backButton?.onClick.RemoveListener(Back);
        }
    }
}