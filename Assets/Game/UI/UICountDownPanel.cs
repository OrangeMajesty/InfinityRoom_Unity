using System.Collections;
using Game.ECSComponents;
using Game.Startup;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    /// <summary>
    /// Компонент панели обратного отсчета перед стартом.
    /// </summary>
    public class UICountDownPanel: UIPopup
    {
        [SerializeField]
        private int WaitSeconds = 3;
        [SerializeField]
        private TextMeshProUGUI _text;
        
        private int _currentDuration;
        protected override void Showed()
        {
            base.Showed();
            _currentDuration = WaitSeconds;

            StartCoroutine(CountDown());
        }

        protected override void Hidden()
        {
            base.Hidden();
            StopAllCoroutines();
        }

        private IEnumerator CountDown()
        {
            for (int i = 0; i < WaitSeconds; i++)
            {
                _currentDuration--;
                _text.text = _currentDuration.ToString();
                yield return new WaitForSeconds(1);
            }

            var entity = EcsStartup.World.NewEntity();
            entity.Get<GameStartCmd>();
        }
        
    }
}