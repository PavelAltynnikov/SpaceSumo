#nullable enable
using SpaceSumo.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceSumo.Presentation
{
    public class SettingsMenu : Menu
    {
        [SerializeField] private Button? _backButton;

        private void Awake()
        {
            this.CheckFieldValue(nameof(_backButton), _backButton);
        }

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