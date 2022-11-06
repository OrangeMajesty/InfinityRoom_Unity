using Game.ECSComponents;
using Game.ECSSystems;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Startup
{
    /// <summary>
    /// Компонент управляющий миром ECS.
    /// </summary>
    public class EcsStartup: MonoBehaviour
    {
        public static EcsWorld World { get; private set; }
        public static EcsSystems Systems { get; private set; }
        
        public void Init()
        {
            World = new EcsWorld();
            Systems = new EcsSystems(World);
            Systems
                .Add(new GameStartSystem(), GameStartSystem.Name)
                .Add(new GameLoseSystem(), GameLoseSystem.Name)
                .Add(new PlayingTimeSystem(), PlayingTimeSystem.Name)
                .Add(new BallMoveSystem(), BallMoveSystem.Name)
                .Add(new WorldMoveSystem(), WorldMoveSystem.Name)
                .Add(new DisableObjectOutOfBounds(), DisableObjectOutOfBounds.Name)
                .Add(new SpawnBallSystem(), SpawnBallSystem.Name)
                .Add(new SpawnWallSystem(), SpawnWallSystem.Name)
                .Add(new SpawnBordersSystems(), SpawnBordersSystems.Name)
                .OneFrame<GameStartEvent>()
                .OneFrame<BallCollisionEvent>()
                .OneFrame<SpawnBallCmd>()
                .Init();
        }
        
        private void Update()
        {
            Systems?.Run();
        }

        private void OnDestroy()
        {
            Systems?.Destroy();
            Systems = null;
            World?.Destroy();
            World = null;
        }
    }
}