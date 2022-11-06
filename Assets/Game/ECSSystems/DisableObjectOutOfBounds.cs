using Game.Consts;
using Game.ECSComponents;
using Game.Startup;
using Leopotam.Ecs;

namespace Game.ECSSystems
{
    public class DisableObjectOutOfBounds: IEcsRunSystem
    {
        public const string Name = "DisableObjectOutOfBounds";
        //-------------------------------------------

        private EcsFilter<ObjectCheckBoundTag> _gameobjectTag;

        public void Run()
        {
            foreach (var gmIdx in _gameobjectTag)
            {
                ref var objectTag = ref _gameobjectTag.Get1(gmIdx);
                if (objectTag.gameObject.transform.position.x < -Const.Game.wallDistance.x)
                {
                    objectTag.gameObject.ReturnToPool();
                    
                    var objectEntityEvent = EcsStartup.World.NewEntity();
                    objectEntityEvent.Get<ObjectDestroyedEvent>();

                    if (_gameobjectTag.GetEntity(gmIdx).Has<WallTag>())
                        objectEntityEvent.Get<WallDestroyedEvent>();
                    
                    _gameobjectTag.GetEntity(gmIdx).Destroy();
                }
            }
        }
    }
}