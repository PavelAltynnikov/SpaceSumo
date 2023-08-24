#nullable enable
using TMPro;
using UnityEngine;

namespace SpaceSumo.UI
{
    public class GameMenu : Menu
    {
        [SerializeField] private TextMeshProUGUI? _wavesText;
        [SerializeField] private TextMeshProUGUI? _scoreText;
        [SerializeField] private TextMeshProUGUI? _pushAbilityText;
        [SerializeField] private TextMeshProUGUI? _smashAbilityText;
        [SerializeField] private TextMeshProUGUI? _rocketAbilityText;

        private CounterView? _wavesCounter;
        private CounterView? _scoreCounter;
        private CounterView? _pushCounter;
        private CounterView? _smashCounter;
        private CounterView? _rocketCounter;

        private void Awake()
        {
            _wavesCounter = CreateCounterView(_wavesText, nameof(_wavesText));
            _scoreCounter = CreateCounterView(_scoreText, nameof(_scoreText));
            _pushCounter = CreateCounterView(_pushAbilityText, nameof(_pushAbilityText));
            _smashCounter = CreateCounterView(_smashAbilityText, nameof(_smashAbilityText));
            _rocketCounter = CreateCounterView(_rocketAbilityText, nameof(_rocketAbilityText));
        }

        public void UpdateWaves(int value)
        {
            _wavesCounter?.Update(value);
        }

        public void UpdateScore(int value)
        {
            _scoreCounter?.Update(value);
        }

        public void UpdatePush(int value)
        {
            _pushCounter?.Update(value);
        }

        public void UpdateSmash(int value)
        {
            _smashCounter?.Update(value);
        }

        public void UpdateRocket(int value)
        {
            _rocketCounter?.Update(value);
        }

        private CounterView? CreateCounterView(TextMeshProUGUI? counter, string fieldName)
        {
            if (counter is null)
            {
                Debug.LogError($"У объекта {gameObject.name} поле {fieldName} не было заполнено в инспекторе.");
                return null;
            }

            return new CounterView(counter);
        }
    }
}