#nullable enable
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceSumo.Presentation
{
    public class EndMenu : Menu
    {
        [SerializeField] private Menu _gameMenu;
        [SerializeField] private Menu _settingsMenu;

        [SerializeField] private Button? _restartButton;
        [SerializeField] private Button? _settingsButton;
        [SerializeField] private Button? _exitButton;

        public event Action? ExitButtonPressed;

        private void OnEnable()
        {
            _restartButton?.onClick.AddListener(StartGame);
            _settingsButton?.onClick.AddListener(OpenSettings);
            _exitButton?.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _restartButton?.onClick.RemoveListener(StartGame);
            _settingsButton?.onClick.RemoveListener(OpenSettings);
            _exitButton?.onClick.RemoveListener(ExitGame);
        }

        private void StartGame()
        {
            _gameMenu.Show();
        }

        private void OpenSettings()
        {
            _settingsMenu.Show(this);
        }

        private void ExitGame()
        {
            ExitButtonPressed?.Invoke();
        }
    }
}