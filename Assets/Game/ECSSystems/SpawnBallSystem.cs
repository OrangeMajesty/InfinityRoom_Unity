using Game.ECSComponents;
using Game.Pools;
using Game.Startup;
using Game.Types;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    public class SpawnBallSystem: IEcsRunSystem
    {
        public const string Name = "SpawnBallSystem";
        //-------------------------------------------
        
        private EcsFilter<SpawnBallCmd> _spawnBallCmd;
        
        public void Run()
        {
            if (_spawnBallCmd.IsEmpty())
                return;
            
            GameObject ball = PoolsObjects.instance.GetObject(PoolObjectType.Ball).gameObject;
            EcsEntity ballSpawnedEvent = EcsStartup.World.NewEntity();
            ballSpawnedEvent.Get<BallSpawnedEvent>();
            ballSpawnedEvent.Get<BallTag>().ball = ball;
        }
    }
}