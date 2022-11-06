using Game.Pools;

namespace Game.ECSComponents
{
    /// <summary>
    /// Событие уничтожение объекта.
    /// Вызывается при пересечении объектом определенной границы.
    /// </summary>
    public struct ObjectDestroyedEvent {}
    
    /// <summary>
    /// Тег объекта, праверяемого на пересечение границы.
    /// </summary>
    public struct ObjectCheckBoundTag
    {
        public PoolObject gameObject;
    }
}