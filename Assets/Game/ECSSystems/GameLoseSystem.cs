using Game.ECSComponents;
using Game.Models;
using Leopotam.Ecs;

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
                Modeler.ModelPrefs.maxTimePlayed = Modeler.ModelGame.playingTime;
            }
        }
    }
}