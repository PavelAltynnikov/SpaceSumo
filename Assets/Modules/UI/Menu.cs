﻿#nullable enable
using UnityEngine;

namespace SpaceSumo.UI
{
    public class Menu : MonoBehaviour
    {
        private Menu? _previousMenu;

        public void Show(Menu? previousMenu = null)
        {
            _previousMenu = previousMenu;
            _previousMenu?.Hide();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Back()
        {
            Hide();
            _previousMenu?.Show(this);
        }
    }
}