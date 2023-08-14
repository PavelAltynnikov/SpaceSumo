using SpaceSumo.Powerups;
using SpaceSumo.Presentation;
using UnityEngine;

namespace SpaceSumo.Game
{
    public class Game
    {
        private int _waveNumber = 0;
        private int _score = 0;

        private bool _isGameStarted = false;

        private readonly Spawner _spawner;

        public Game(Spawner spawner)
        {
            _spawner = spawner;
        }

        public void Start()
        {
            _waveNumber++;
            _isGameStarted = true;

            _spawner.SpawnPlayer();
            _spawner.SpawnNewWave(_waveNumber);
            _spawner.SpawnRandomPowerup();
        }

        public void GameOver()
        {
            Debug.Log("потрачено!");
        }

        public void AddScore(object sender, EnemyGoesOutOfBoundEventArgs e)
        {
            _score++;
            Debug.Log(_score);
        }

        public void TryToStartNewWave(object sender, EnemyGoesOutOfBoundEventArgs e)
        {
            if (_spawner.IsWaveClear == false)
            {
                return;
            }

            _waveNumber++;
            _spawner.SpawnNewWave(_waveNumber);
        }
    }
}
