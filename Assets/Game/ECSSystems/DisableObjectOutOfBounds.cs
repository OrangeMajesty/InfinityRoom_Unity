using Game.Consts;
using Game.ECSComponents;
using Game.Startup;
using Leopotam.Ecs;

namespace Game.ECSSystems
{
    /// <summary>
    /// Система проверки объектов на пересечение границ и возвращение их в пулл.
    /// </summary>
    public class DisableObjectOutOfBounds: IEcsRunSystem
    {
        public const string Name = "DisableObjectOutOfBounds";
        //-------------------------------------------

        /// <summary>
        /// Фильтр хранящий все проверяемые на пересечение объекты.
        /// </summary>
        private EcsFilter<ObjectCheckBoundTag> _gameobjectTag;

        public void Run()
        {
            foreach (var gmIdx in _gameobjectTag)
            {
                ref var objectTag = ref _gameobjectTag.Get1(gmIdx);
                // Проверяем пересечение текущего объекта границ Const.Game.wallDistance.
                if (objectTag.gameObject.transform.position.x < -Const.Game.wallDistance.x)
                {
                    // Возврящаем в пулл.
                    objectTag.gameObject.ReturnToPool();
                    
                    // Создаем событие удаления объекта.
                    var objectEntityEvent = EcsStartup.World.NewEntity();
                    objectEntityEvent.Get<ObjectDestroyedEvent>();
                    
                    // Создаем тег удаления стены, для генерации новой.
                    if (_gameobjectTag.GetEntity(gmIdx).Has<WallTag>())
                        objectEntityEvent.Get<WallDestroyedEvent>();
                    
                    // Удаляем ненужную сущность.
                    _gameobjectTag.GetEntity(gmIdx).Destroy();
                }
            }
        }
    }
}