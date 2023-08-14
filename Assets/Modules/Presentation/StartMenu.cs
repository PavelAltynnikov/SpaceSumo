#nullable enable
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceSumo.Presentation
{
    public class StartMenu : Menu
    {
        [SerializeField] private Menu _startMenu;
        [SerializeField] private Menu _gameMenu;
        [SerializeField] private Menu _settingsMenu;

        [SerializeField] private Button? _startButton;
        [SerializeField] private Button? _settingsButton;
        // [SerializeField] private Button? _ExitButton;

        public event Action? StartButtonPressed;

        private void OnEnable()
        {
            _startButton?.onClick.AddListener(StartGame);
            _settingsButton?.onClick.AddListener(OpenSettings);
        }

        private void OnDisable()
        {
            _startButton?.onClick.RemoveListener(StartGame);
            _settingsButton?.onClick.RemoveListener(OpenSettings);
        }

        private void StartGame()
        {
            _gameMenu.Show(_startMenu);
            StartButtonPressed?.Invoke();
        }

        private void OpenSettings()
        {
            _startMenu.Hide();
            _settingsMenu.Show(this);
        }
    }
}