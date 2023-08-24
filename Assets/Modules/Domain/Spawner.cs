using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SpaceSumo.Powerups;

namespace SpaceSumo.Domain
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemyPrefabs;
        [SerializeField] private Enemy[] _bossPrefabs;
        [SerializeField] private GameObject[] _powerupPrefabs;
        [SerializeField] private Player _playerPrefab;

        [SerializeField] private float _spawnRange = 9f;

        private List<Enemy> _enemiesOnScene = new List<Enemy>();
        private Player _player;

        public bool IsWaveClear => _enemiesOnScene.Any() == false;

        public Player SpawnPlayer()
        {
            _player = Instantiate(_playerPrefab, GenerateRandomPosition(), _playerPrefab.transform.rotation);
            return _player;
        }

        public void SpawnNewWave(int countOfEnemies)
        {
            for (int i = 0; i < countOfEnemies; i++)
            {
                Enemy enemyPrefab = GetRandomItem(_enemyPrefabs);
                Enemy enemy = Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
                enemy.GetComponent<Enemy>()._target = _player.transform;

                _enemiesOnScene.Add(enemy);
            }
        }

        public void SpawnRandomPowerup()
        {
            GameObject powerupPrefab = GetRandomItem(_powerupPrefabs);
            Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
        }

        public void RemoveEnemy(object sender, EnemyGoesOutOfBoundEventArgs e)
        {
            _enemiesOnScene.Remove(e.Enemy);
        }

        public void DestroyAllWaveObjects()
        {
            GameObject[] enemies = FindObjectsOfType<GameObject>();

            foreach (var enemy in enemies)
            {
                if (enemy.GetComponent<Enemy>() != null
                    || enemy.GetComponent<PushPowerup>() != null
                    || enemy.GetComponent<Rocket>() != null)
                {
                    Destroy(enemy);
                }
            }
        }

        private T GetRandomItem<T>(T[] prefabs)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            return prefabs[randomIndex];
        }

        private Vector3 GenerateRandomPosition()
        {
            float randomCoordinateX = Random.Range(-_spawnRange, _spawnRange);
            float randomCoordinateZ = Random.Range(-_spawnRange, _spawnRange);

            return new Vector3(randomCoordinateX, 0, randomCoordinateZ);
        }
    }
}
