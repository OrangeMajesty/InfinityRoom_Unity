using Game.Consts;
using Game.ECSComponents;
using Game.Startup;
using Leopotam.Ecs;

namespace Game.ECSSystems
{
    public class DestroyerWallSystem: IEcsRunSystem
    {
        public const string Name = "DestroyerWallSystem";
        //-------------------------------------------

        private EcsFilter<WallTag> _wallTag;

        public void Run()
        {
            foreach (var wallIdx in _wallTag)
            {
                ref var wallTag = ref _wallTag.Get1(wallIdx);
                if (wallTag.wall.transform.position.x < -Const.Game.wallDistance.x)
                {
                    wallTag.wall.ReturnToPool();
                    _wallTag.GetEntity(wallIdx).Destroy();

                    var wallEntityEvent = EcsStartup.World.NewEntity();
                    wallEntityEvent.Get<WallDestroyedEvent>();
                }
            }
        }
    }
}