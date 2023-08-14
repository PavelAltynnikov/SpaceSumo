#nullable enable
using System;

namespace SpaceSumo.Game
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