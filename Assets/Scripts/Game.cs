using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _startMenuUI;
    [SerializeField] private GameObject _gameMenuUI;
    [SerializeField] private GameObject _settingsMenuUI;
    [SerializeField] private GameObject _endMenuUI;

    [SerializeField] private Spawner _spawner;

    [SerializeField] private TextMeshProUGUI _waveLabel;
    [SerializeField] private TextMeshProUGUI _scoreLabel;

    private int _waveNumber = 0;
    private int _scoreAmount = 0;

    private bool _isGameStarted = false;

    private PowerupIndicator _player;
    private AudioSource _audioSource;

    private GameObject _previousMenu;

    private void Awake()
    {
        _previousMenu = _startMenuUI;

        _startMenuUI.SetActive(true);
        _settingsMenuUI.SetActive(false);
        _gameMenuUI.SetActive(false);
        _endMenuUI.SetActive(false);
    }

    public void InitializeGame()
    {
        _waveNumber++;
        _isGameStarted = true;

        _startMenuUI.SetActive(false);
        _gameMenuUI.SetActive(true);

        _player = _spawner.SpawnPlayer().GetComponent<PowerupIndicator>();
        _spawner.SpawnNewWave(_waveNumber);
        _spawner.SpawnRandomPowerup();

        _waveLabel.text = $"Waves: {_waveNumber}";
        _scoreLabel.text = $"Score: {_scoreAmount}";
    }

    public void OpenSettings()
    {
        _previousMenu.SetActive(false);
        _gameMenuUI.SetActive(false);
        _settingsMenuUI.SetActive(true);
    }

    public void BackFromSettings()
    {
        _previousMenu.SetActive(true);
        _settingsMenuUI.SetActive(false);
    }

    public void GameOver()
    {
        _isGameStarted = false;
        _waveNumber = 0;
        _scoreAmount = 0;
        _endMenuUI.SetActive(true);
        _previousMenu = _endMenuUI;
    }

    public void RestartGame()
    {
        _waveNumber = 1;
        _scoreAmount = 0;

        _waveLabel.text = $"Waves: {_waveNumber}";
        _scoreLabel.text = $"Score: {_scoreAmount}";

        _startMenuUI.SetActive(false);
        _gameMenuUI.SetActive(true);
        _endMenuUI.SetActive(false);

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

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();

        _startMenuUI.SetActive(true);
        _gameMenuUI.SetActive(false);
        _endMenuUI.SetActive(false);
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

        _scoreLabel.text = $"Score: {_scoreAmount}";

        if (IsWaveClear())
        {
            _waveNumber++;
            _waveLabel.text = $"Waves: {_waveNumber}";

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
