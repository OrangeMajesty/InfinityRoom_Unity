using UnityEngine;

namespace Game.UI
{
    public class UIPopup: MonoBehaviour
    {
        [SerializeField]
        protected Canvas _canvas;

        protected virtual void Showed() {}
        protected virtual void Hidden() {}
        
        public void Show()
        {
            _canvas.gameObject.SetActive(true);
            Showed();
        }

        public void Hide()
        {
            _canvas.gameObject.SetActive(false);
            Hidden();
        }
    }
}