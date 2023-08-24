#nullable enable
using System;
using SpaceSumo.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceSumo.Presentation
{
    public class EndMenu : Menu
    {
        [SerializeField] private Menu? _gameMenu;
        [SerializeField] private Menu? _settingsMenu;

        [SerializeField] private Button? _restartButton;
        [SerializeField] private Button? _settingsButton;
        [SerializeField] private Button? _exitButton;

        public event Action? RestartButtonPressed;

        private void Awake()
        {
            this.CheckFieldValue(nameof(_gameMenu), _gameMenu);
            this.CheckFieldValue(nameof(_settingsMenu), _settingsMenu);
            this.CheckFieldValue(nameof(_restartButton), _restartButton);
            this.CheckFieldValue(nameof(_settingsButton), _settingsButton);
            this.CheckFieldValue(nameof(_exitButton), _exitButton);
        }

        private void OnEnable()
        {
            _restartButton?.onClick.AddListener(RestartGame);
            _settingsButton?.onClick.AddListener(OpenSettings);
            _exitButton?.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _restartButton?.onClick.RemoveListener(RestartGame);
            _settingsButton?.onClick.RemoveListener(OpenSettings);
            _exitButton?.onClick.RemoveListener(ExitGame);
        }

        private void RestartGame()
        {
            _gameMenu?.Show();
        }

        private void OpenSettings()
        {
            _settingsMenu?.Show(this);
        }

        private void ExitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit(); 
            #endif
        }
    }
}