﻿using UnityEngine;

namespace SpaceSumo.Powerups
{
    public class PushPowerup : MonoBehaviour
    {
        [SerializeField] private float _strength;
        [SerializeField] private float _actionTime;

        public float Strength => _strength;

        public float ActionTime => _actionTime;
    }
}
