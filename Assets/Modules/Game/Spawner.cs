using System.Collections.Generic;
using UnityEngine;
using SpaceSumo.Powerups;

namespace SpaceSumo.Game
{
    public class Spawner : MonoBehaviour
    {
        private List<GameObject> _enemiesOnScene = new List<GameObject>();
        private GameObject _player;

        [SerializeField] private float _spawnRange = 9f;

        [SerializeField] private GameObject[] _enemyPrefabs;
        [SerializeField] private GameObject[] _bossPrefabs;
        [SerializeField] private GameObject[] _powerupPrefabs;
        [SerializeField] private GameObject _playerPrefab;

        public List<GameObject> EnemiesOnScene => _enemiesOnScene;

        public GameObject SpawnPlayer()
        {
            _player = Instantiate(_playerPrefab, GenerateRandomPosition(), _playerPrefab.transform.rotation);
            return _player;
        }

        public void SpawnNewWave(int countOfEnemies)
        {
            for (int i = 0; i < countOfEnemies; i++)
            {
                GameObject enemyPrefab = GetRandomPrefab(_enemyPrefabs);
                GameObject enemy = Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
                enemy.GetComponent<Enemy>().target = _player;

                var destroyOnUnbound = enemy.GetComponent<DestroyOnUnboundCommand>();
                destroyOnUnbound.RemoveObject += RemoveEnemey;

                _enemiesOnScene.Add(enemy);
            }
        }

        public void SpawnBoss()
        {
            GameObject bossPrefab = GetRandomPrefab(_bossPrefabs);
            GameObject boss = Instantiate(bossPrefab, GenerateRandomPosition(), bossPrefab.transform.rotation);
            boss.GetComponent<Enemy>().target = _player;

            var destroyOnUnbound = boss.GetComponent<DestroyOnUnboundCommand>();
            destroyOnUnbound.RemoveObject += RemoveEnemey;

            _enemiesOnScene.Add(boss);
        }

        public void SpawnRandomPowerup()
        {
            GameObject powerupPrefab = GetRandomPrefab(_powerupPrefabs);
            Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
        }

        public void DestoryAllWaveObjects()
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

        private GameObject GetRandomPrefab(GameObject[] prefabs)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            return prefabs[randomIndex];
        }

        private void RemoveEnemey(GameObject enemy)
        {
            _enemiesOnScene.Remove(enemy);
        }

        private Vector3 GenerateRandomPosition()
        {
            float randomCoordinateX = Random.Range(-_spawnRange, _spawnRange);
            float randomCoordinateZ = Random.Range(-_spawnRange, _spawnRange);

            return new Vector3(randomCoordinateX, 0, randomCoordinateZ);
        }
    }
}
