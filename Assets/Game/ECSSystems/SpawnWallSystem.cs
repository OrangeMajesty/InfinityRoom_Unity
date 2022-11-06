using Game.ECSComponents;
using Game.Pools;
using Game.Startup;
using Game.Types;
using Game.Utils;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    public class SpawnWallSystem: IEcsInitSystem, IEcsRunSystem
    {
        public const string Name = "SpawnWallSystem";
        //-------------------------------------------

        private EcsFilter<WallSpawnCmd> _wallSpawnCmd;
        private EcsFilter<WallDestroyedEvent> _wallDestroyedEvent;
        
        // Target spawn wall coordinate
        private float x, y;
        
        public void Init()
        {
            x = -Consts.Const.Game.wallDistance.x;
            y = Consts.Const.Game.wallDistance.y;
            
            // Цикл до конца карты
            while (x < Consts.Const.Game.wallDistance.x)
            {
                CreateWall();
            }
        }
        
        public void Run()
        {
            foreach (var cmd in _wallSpawnCmd)
            {
                ref var spawnComponent = ref _wallSpawnCmd.Get1(cmd);
                var wall = PoolsObjects.instance.GetObject(PoolObjectType.Wall);

                var wallEntity = EcsStartup.World.NewEntity();
                wallEntity.Get<WallTag>().wall = wall;

                wall.transform.localPosition = new Vector3(spawnComponent.x, spawnComponent.y, 0);
                _wallSpawnCmd.GetEntity(cmd).Del<WallSpawnCmd>();
            }

            foreach (var destroyedEventIdx in _wallDestroyedEvent)
            {
                CreateWall();
                _wallDestroyedEvent.GetEntity(destroyedEventIdx).Destroy();
            }
        }

        private void CreateWall(float x = 0, float y = 0)
        {
            EcsUtil.Get(new WallSpawnCmd
            {
                x = this.x,
                y = this.y
            });
            
            this.y = -this.y;
            if (this.y > 0)
                this.x+= 1;
        }
    }
}