#nullable enable
using System;
using SpaceSumo.Utils;
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
        [SerializeField] private Button? _exitButton;

        public event Action? StartButtonPressed;

        private void Awake()
        {
            this.CheckFieldValue(nameof(_startMenu), _startMenu);
            this.CheckFieldValue(nameof(_gameMenu), _gameMenu);
            this.CheckFieldValue(nameof(_settingsMenu), _settingsMenu);
            this.CheckFieldValue(nameof(_startButton), _startButton);
            this.CheckFieldValue(nameof(_settingsButton), _settingsButton);
            this.CheckFieldValue(nameof(_exitButton), _exitButton);
        }

        private void OnEnable()
        {
            _startButton?.onClick.AddListener(StartGame);
            _settingsButton?.onClick.AddListener(OpenSettings);
            _exitButton?.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _startButton?.onClick.RemoveListener(StartGame);
            _settingsButton?.onClick.RemoveListener(OpenSettings);
            _exitButton?.onClick.RemoveListener(ExitGame);
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

        private void ExitGame()
        {
            ExitButtonPressed?.Invoke();
        }
    }
}