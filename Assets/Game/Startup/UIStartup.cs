using Game.UI;
using UnityEngine;

namespace Game.Startup
{
    /// <summary>
    /// Компонент хранит ссылки на UI окна.
    /// </summary>
    public class UIStartup: MonoBehaviour
    {
        [SerializeField]
        private UIGameLosePopup _losePopup;
        public static UIGameLosePopup LosePopup => _instance._losePopup;
        
        [SerializeField]
        private UICountDownPanel _countdownPanel;
        public static UICountDownPanel UICountDownPanel => _instance._countdownPanel;        
        
        [SerializeField]
        private UIStartGamePanel _startPanel;
        public static UIStartGamePanel UIStartGamePanel => _instance._startPanel;
        
        private static UIStartup _instance;

        public void Init()
        {
            _instance = this;
        }

        public static void HideAll()
        {
            LosePopup.Hide();
            UICountDownPanel.Hide();
            UIStartGamePanel.Hide();
        }
    }
}