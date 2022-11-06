using Game.ECSComponents;
using Game.Models;
using Game.Startup;
using Game.Types;
using Game.Utils;

namespace Game.UI
{
    /// <summary>
    /// Компонент отрисовки панели с выбором сложности.
    /// После выбора запускает игру.
    /// </summary>
    public class UIStartGamePanel: UIPopup
    {
        public void OnSelectedLowDifficultClick()
        {
            Modeler.ModelGame.difficult = GameDifficult.Low;
            GameStartup.GameRestart();
            EcsUtil.Get<GameStartCountDownCmd>();
            Hide();
        }
        
        public void OnSelectedNormalDifficultClick()
        {
            Modeler.ModelGame.difficult = GameDifficult.Normal;
            GameStartup.GameRestart();
            EcsUtil.Get<GameStartCountDownCmd>();
            Hide();
        }
        
        public void OnSelectedHardDifficultClick()
        {
            Modeler.ModelGame.difficult = GameDifficult.Hard;
            GameStartup.GameRestart();
            EcsUtil.Get<GameStartCountDownCmd>();
            Hide();
        }
    }
}