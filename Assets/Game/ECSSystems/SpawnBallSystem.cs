using Game.ECSComponents;
using Game.Pools;
using Game.Startup;
using Game.Types;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    /// <summary>
    /// Система спавна мяча.
    /// </summary>
    public class SpawnBallSystem: IEcsRunSystem
    {
        public const string Name = "SpawnBallSystem";
        //-------------------------------------------
        
        private EcsFilter<SpawnBallCmd> _spawnBallCmd;
        
        public void Run()
        {
            if (_spawnBallCmd.IsEmpty())
                return;
            
            // Получение объекта из пулла.
            GameObject ball = PoolsObjects.instance.GetObject(PoolObjectType.Ball).gameObject;
            EcsEntity ballSpawnedEvent = EcsStartup.World.NewEntity();
            ballSpawnedEvent.Get<BallTag>().ball = ball;
        }
    }
}