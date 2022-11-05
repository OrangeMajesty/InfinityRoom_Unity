using Game.Datas;
using Game.ECSComponents;
using Game.Startup;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    public class SpawnBallSystem: IEcsInitSystem
    {
        private EcsFilter<SpawnBallCmd> _spawnBallCmd;
        
        public void Init()
        {
            GameObject ball = Object.Instantiate(Data.Prefabs.ball, Vector3.zero, Quaternion.identity);
            EcsEntity ballSpawnedEvent = EcsStartup.World.NewEntity();
            ballSpawnedEvent.Get<BallSpawnedEvent>();
            ballSpawnedEvent.Get<BallTag>().ball = ball;
        }
    }
}