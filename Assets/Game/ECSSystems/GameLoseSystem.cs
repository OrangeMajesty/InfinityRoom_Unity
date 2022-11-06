using Game.ECSComponents;
using Game.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    public class GameLoseSystem: IEcsRunSystem
    {
        public const string Name = "GameLoseSystem";
        //-------------------------------------------

        private EcsFilter<BallCollisionEvent> _ballColisionEvent;
        public void Run()
        {
            if (!_ballColisionEvent.IsEmpty())
            {
                Debug.Log($"Game end. MaxTime {Modeler.ModelGame.playingTime}");
                Modeler.ModelPrefs.maxTimePlayed = Modeler.ModelGame.playingTime;
            }
        }
    }
}