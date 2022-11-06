using Game.Pools;

namespace Game.ECSComponents
{
    public struct ObjectOutsideBoundEvent {}
    public struct ObjectDestroyedEvent {};


    public struct ObjectCheckBoundTag
    {
        public PoolObject gameObject;
    }
    
}