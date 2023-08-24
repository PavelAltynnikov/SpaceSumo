#nullable enable
using TMPro;

namespace SpaceSumo.Presentation
{
    internal class CounterView
    {
        private TextMeshProUGUI _counter;

        internal CounterView(TextMeshProUGUI counter)
        {
            _counter = counter;
        }

        internal void Update(int value)
        {
            _counter.text = value.ToString();
        }
    }
}