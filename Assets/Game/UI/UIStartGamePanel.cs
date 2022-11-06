using System;
using Game.ECSComponents;
using Game.Models;
using Game.Startup;
using Game.Types;
using Game.Utils;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    /// <summary>
    /// Компонент отрисовки панели с выбором сложности и кнопкой запуска.
    /// </summary>
    public class UIStartGamePanel: UIPopup
    {
        [SerializeField]
        private TextMeshProUGUI _difficult;

        private void Start()
        {
            UpdateDifficultUI();
        }

        public void OnSelectedLowDifficultClick()
        {
            Modeler.ModelGame.difficult = GameDifficult.Low;
            UpdateDifficultUI();
        }
        
        public void OnSelectedNormalDifficultClick()
        {
            Modeler.ModelGame.difficult = GameDifficult.Normal;
            UpdateDifficultUI();
        }
        
        public void OnSelectedHardDifficultClick()
        {
            Modeler.ModelGame.difficult = GameDifficult.Hard;
            UpdateDifficultUI();
        }

        public void OnClickedStartGame()
        {
            GameStartup.GameRestart();
            EcsUtil.Get<GameStartCountDownCmd>();
            Hide();
        }

        protected override void Showed()
        {
            base.Showed();
            UpdateDifficultUI();
        }

        private void UpdateDifficultUI()
        {
            string[] difficultArr = {"Легкая", "Нормальная", "Сложная"};
            _difficult.text = difficultArr[(int) Modeler.ModelGame.difficult];
        }
    }
}