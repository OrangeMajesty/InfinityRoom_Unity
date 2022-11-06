using Game.ECSSystems;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Startup
{
    public class EcsStartup: MonoBehaviour
    {
        public static EcsWorld   World;
        public static EcsSystems Systems;
        
        public void Init()
        {
            World = new EcsWorld();
            Systems = new EcsSystems(World);
            Systems
                .Add(new SpawnBallSystem())
                .Add(new GameLoseSystem(), GameLoseSystem.Name)
                .Add(new BallMoveSystem(), BallMoveSystem.Name)
                .Add(new WorldMoveSystem(), WorldMoveSystem.Name)
                .Add(new DisableObjectOutOfBounds(), DisableObjectOutOfBounds.Name)
                .Add(new SpawnWallSystem(), SpawnWallSystem.Name)
                .Add(new SpawnBordersSystems(), SpawnBordersSystems.Name)
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