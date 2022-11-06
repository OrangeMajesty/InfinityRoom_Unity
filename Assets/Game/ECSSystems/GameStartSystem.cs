using Game.ECSComponents;
using Game.Models;
using Game.Startup;
using Game.Utils;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    /// <summary>
    /// Система запуска игры.
    /// </summary>
    public class GameStartSystem: IEcsRunSystem
    {
        public const string Name = "GameStartSystem";
        //-------------------------------------------

        private EcsFilter<GameStartCmd> _gameStartCmd;
        private EcsFilter<GameStartCountDownCmd> _gameStartCountdownCmd;
        
        public void Run()
        {
            // Обработка команды запуска отсчета перед запуском игры.
            foreach (var idx in _gameStartCountdownCmd)
            {
                UIStartup.UICountDownPanel.Show();
                _gameStartCountdownCmd.GetEntity(idx).Destroy();
            }
            
            // Обработка комманды запуска игры. 
            foreach (var idx in _gameStartCmd)
            {
                StartGame();
                _gameStartCmd.GetEntity(idx).Destroy();
            }
        }
        
        private void StartGame()
        {
            // Скрываем все окна.
            UIStartup.HideAll();
            
            // Возвращаем позицию игрового мира в начальную позици.
            // Позиция смещается по горизонтали перемещая дочерние стены и преграды.
            Modeler.ModelWorld.WorldGameObject.transform.position = Vector3.zero;
            
            // Отправка команд на генерацию и изменение состояни игры.
            EcsUtil.Get<SpawnBallCmd>();
            EcsUtil.Get<GameStartEvent>();
            EcsUtil.Get<GamePlayingTag>();
        }
    }
}