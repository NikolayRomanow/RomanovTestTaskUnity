using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UI
{
    [RequireComponent(typeof(Canvas))]
    public class UIContainer : MonoBehaviour
    {
        private Canvas _generalCanvas;
        private PopupScreen.Factory _screenFactory;
        private PopupScreen _popupScreen;

        private void Awake()
        {
            _generalCanvas = GetComponent<Canvas>();
        }

        [Inject]
        public void Construct(PopupScreen.Factory screenFactory)
        {
            _screenFactory = screenFactory;
        }

        public Canvas GetGeneralCanvas()
        {
            return _generalCanvas;
        }

        public void CreateNewPopup(string mainText, string popupText)
        {
            if (_popupScreen != null)
            {
                DestroyPopup();
            }

            _popupScreen = _screenFactory.Create();
            _popupScreen.transform.SetParent(_generalCanvas.transform);
            _popupScreen.SetText(mainText, popupText);
        }

        public void DestroyPopup()
        {
            if (_popupScreen != null)
            {
                Destroy(_popupScreen.gameObject);
                _popupScreen = null;
            }
        }
    }

    public class UIFactory<T> : PlaceholderFactory<T> where T : Component
    {
        [Inject]
        private UIContainer _uIContainer;

        public override T Create()
        {
            var instance = base.Create();
                instance.transform.SetParent(_uIContainer.GetGeneralCanvas().transform, false);

            return instance;
        }
    }
}
