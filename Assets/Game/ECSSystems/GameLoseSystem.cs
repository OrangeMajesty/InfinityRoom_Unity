using Game.ECSComponents;
using Game.Models;
using Game.Pools;
using Game.Startup;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    public class GameLoseSystem: IEcsRunSystem
    {
        public const string Name = "GameLoseSystem";
        //-------------------------------------------

        private EcsFilter<BallCollisionEvent> _ballColisionEvent;
        private EcsFilter<GamePlayingTag> _gamePlayingTag;
        private EcsFilter<BallTag> _ballTag;
        public void Run()
        {
            if (_gamePlayingTag.IsEmpty())
                return;
            
            if (!_ballColisionEvent.IsEmpty())
            {
                if (Modeler.ModelPrefs.maxTimePlayed < Modeler.ModelGame.playingTime)
                {
                    Modeler.ModelPrefs.maxTimePlayed = Modeler.ModelGame.playingTime;
                    Modeler.ModelPrefs.Save();
                }

                UIStartup.LosePopup.Show();
                PoolsObjects.instance.ReleaseAllObjects();

                foreach (var idx in _ballTag)
                {
                    _ballTag.GetEntity(idx).Destroy();
                }

                foreach (var idx in _gamePlayingTag)
                {
                    _gamePlayingTag.GetEntity(idx).Destroy();
                }
            }
        }
    }
}