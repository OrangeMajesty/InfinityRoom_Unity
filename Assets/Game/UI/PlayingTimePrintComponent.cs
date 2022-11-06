using Game.Models;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    /// <summary>
    /// Компонент отрисовывает текущее время на игровой сцене во время игры.
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PlayingTimePrintComponent: MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        private void FixedUpdate()
        {
            float sec = Mathf.Round(Modeler.ModelGame.playingTime);
            _text.text = $"Время игры: {sec} сек";
        }
    }
}