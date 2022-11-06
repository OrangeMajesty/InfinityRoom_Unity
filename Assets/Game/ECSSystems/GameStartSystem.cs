using Game.Consts;
using Game.ECSComponents;
using Game.Models;
using Game.Pools;
using Game.Startup;
using Game.Utils;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    public class GameStartSystem: IEcsRunSystem
    {
        public const string Name = "GameStartSystem";
        //-------------------------------------------

        private EcsFilter<GameStartCmd> _gameStartCmd;
        private EcsFilter<GameStartCountDownCmd> _gameStartCountdownCmd;
        
        public void Run()
        {
            foreach (var idx in _gameStartCountdownCmd)
            {
                UIStartup.UICountDownPanel.Show();
                _gameStartCountdownCmd.GetEntity(idx).Destroy();
            }

            foreach (var idx in _gameStartCmd)
            {
                StartGame();
                _gameStartCmd.GetEntity(idx).Destroy();
            }
        }

        private void StartGame()
        {
            UIStartup.HideAll();
            Modeler.ModelWorld.WorldGameObject.transform.position = Vector3.zero;
            
            EcsUtil.Get<SpawnBallCmd>();
            EcsUtil.Get<GameStartEvent>();
            EcsUtil.Get<GamePlayingTag>();
        }
    }
}