using UnityEngine;

namespace SpaceSumo.Presentation
{
    public class StartMenu : Menu
    {
        [SerializeField] private GameObject _startMenuUI;
        [SerializeField] private GameObject _gameMenuUI;
        [SerializeField] private GameObject _settingsMenuUI;
        [SerializeField] private GameObject _endMenuUI;

        private AudioSource _audioSource;
        private GameObject _previousMenu;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();

            _startMenuUI.SetActive(true);
            _gameMenuUI.SetActive(false);
            _endMenuUI.SetActive(false);
        }

        public void OpenSettings()
        {
            _previousMenu.SetActive(false);
            _gameMenuUI.SetActive(false);
            _settingsMenuUI.SetActive(true);
        }
    }
}