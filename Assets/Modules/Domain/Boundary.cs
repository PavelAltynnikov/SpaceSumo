#nullable enable
using System;
using UnityEngine;

namespace SpaceSumo.Domain
{
    public class Boundary : MonoBehaviour
    {
        public event Action? PlayerGoesOutOfBounds;
        public event EventHandler<EnemyGoesOutOfBoundEventArgs>? EnemyGoesOutOfBounds;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(typeof(Player), out Component player))
            {
                PlayerGoesOutOfBounds?.Invoke();
            }

            if (other.TryGetComponent(typeof(Enemy), out Component enemy))
            {
                EnemyGoesOutOfBounds?.Invoke(this, new EnemyGoesOutOfBoundEventArgs(enemy as Enemy));
            }
        }
    }
}