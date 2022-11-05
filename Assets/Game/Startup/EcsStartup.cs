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
                .Add(new SpawnWallSystem())
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