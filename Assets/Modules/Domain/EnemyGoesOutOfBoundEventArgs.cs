#nullable enable
using System;

namespace SpaceSumo.Domain
{
    public class EnemyGoesOutOfBoundEventArgs : EventArgs
    {
        public Enemy Enemy { get; }

        public EnemyGoesOutOfBoundEventArgs(Enemy enemy)
        {
            Enemy = enemy;
        }
    }
}