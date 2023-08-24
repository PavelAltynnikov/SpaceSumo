#nullable enable
using TMPro;

namespace SpaceSumo.UI
{
    internal class CounterView
    {
        private readonly TextMeshProUGUI _counter;

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