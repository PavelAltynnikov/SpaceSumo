#nullable enable
using System;
using TMPro;
using UnityEngine;

namespace SpaceSumo.Presentation
{
    public class GameMenu : Menu
    {
        [SerializeField] private TextMeshProUGUI _wavesText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _pushAbilityText;
        [SerializeField] private TextMeshProUGUI _smashAbilityText;
        [SerializeField] private TextMeshProUGUI _rocketAbilityText;

        private CounterView _wavesCounter;
        private CounterView _scoreCounter;
        private CounterView _pushCounter;
        private CounterView _smashCounter;
        private CounterView _rocketCounter;

        private void Awake()
        {
            _wavesCounter = new CounterView(_wavesText);
            _scoreCounter = new CounterView(_scoreText);
            _pushCounter = new CounterView(_pushAbilityText);
            _smashCounter = new CounterView(_smashAbilityText);
            _rocketCounter = new CounterView(_rocketAbilityText);
        }

        public void UpdateWaves(int value)
        {
            _wavesCounter.Update(value);
        }

        public void UpdateScore(int value)
        {
            _scoreCounter.Update(value);
        }

        public void UpdatePush(int value)
        {
            _pushCounter.Update(value);
        }

        public void UpdateSmash(int value)
        {
            _smashCounter.Update(value);
        }

        public void UpdateRocket(int value)
        {
            _rocketCounter.Update(value);
        }
    }
}