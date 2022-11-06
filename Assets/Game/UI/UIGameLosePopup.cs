using Game.ECSComponents;
using Game.Models;
using Game.Utils;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    /// <summary>
    /// Компонент вывода статистики последней игры.
    /// Умеет перезапускать игру.
    /// </summary>
    public class UIGameLosePopup: UIPopup
    {
        [SerializeField]
        private TextMeshProUGUI _maxPlayingTime;
        [SerializeField]
        private TextMeshProUGUI _playerPlayingTime;

        protected override void Showed()
        {
            base.Showed();
            
            _maxPlayingTime.text = $"Макс. рекорд: {Mathf.Round(Modeler.ModelPrefs.maxTimePlayed)} сек";
            _playerPlayingTime.text = $"Ваш. рекорд: {Mathf.Round(Modeler.ModelGame.playingTime)} сек";
        }

        protected void OnGameRestartClick()
        {
            EcsUtil.Get<GameStartCountDownCmd>();
            Hide();
        }
    }
}