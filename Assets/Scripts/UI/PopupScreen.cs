using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class PopupScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI mainLabel;
        [SerializeField] private TextMeshProUGUI popupLabel;

        public void SetText(string mainText, string popupText)
        {
            mainLabel.text = $"Name: {mainText}";
            popupLabel.text = $"Hash code: {popupText}";
        }

        public class Factory : PlaceholderFactory<PopupScreen> { }
    }
}
