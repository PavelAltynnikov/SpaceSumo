using SpaceSumo.Powerups;
using SpaceSumo.Presentation;
using UnityEngine;

namespace SpaceSumo.Game
{
    public class GameRoot : MonoBehaviour
    {
        [SerializeField] private StartMenu _startMenuUI;
        [SerializeField] private GameMenu _gameMenuUI;
        [SerializeField] private SettingsMenu _settingsMenuUI;
        [SerializeField] private EndMenu _endMenuUI;

        [SerializeField] private Spawner _spawner;
        [SerializeField] private AudioSource _audioSource;

        private int _waveNumber = 0;
        private int _scoreAmount = 0;

        private bool _isGameStarted = false;

        private PowerupIndicator _player;

        private void OnEnable()
        {
            _audioSource.Play();
            _startMenuUI.Show();

            _startMenuUI.StartButtonPressed += StartGame;
        }

        private void OnDisable()
        {
            _audioSource.Stop();

            _startMenuUI.StartButtonPressed -= StartGame;
        }

        private void StartGame()
        {
            // TODO перенести в Game
            _waveNumber++;
            _isGameStarted = true;

            _player = _spawner.SpawnPlayer().GetComponent<PowerupIndicator>();
            _spawner.SpawnNewWave(_waveNumber);
            _spawner.SpawnRandomPowerup();
        }

        public void GameOver()
        {
            _isGameStarted = false;
            _waveNumber = 0;
            _scoreAmount = 0;
            _endMenuUI.Show(_gameMenuUI);
        }

        public void RestartGame()
        {
            _waveNumber = 1;
            _scoreAmount = 0;

            _gameMenuUI.Show(_endMenuUI);
            _spawner.DestoryAllWaveObjects();

            _player = _spawner.SpawnPlayer().GetComponent<PowerupIndicator>();
            _spawner.SpawnNewWave(_waveNumber);
            _spawner.SpawnRandomPowerup();

            _isGameStarted = true;
        }

        public void UpdateScore(int value)
        {
            _scoreAmount += value;
        }

        private void Update()
        {
            if (!_isGameStarted)
            {
                return;
            }

            if (IsPlayerDeath())
            {
                GameOver();
                return;
            }

            if (IsWaveClear())
            {
                _waveNumber++;

                _spawner.SpawnNewWave(_waveNumber);
                _spawner.SpawnRandomPowerup();
            }
        }

        private bool IsWaveClear()
        {
            int countOfEnemies = FindObjectsOfType<Enemy>().Length;
            return countOfEnemies == 0;
        }

        private bool IsPlayerDeath()
        {
            return _player == null;
        }
    }
}
