using Game.Pools;

namespace Game.ECSComponents
{
    public struct WallSpawnCmd
    {
        public float x, y;
    }

    public struct WallDestroyedEvent {};

    public struct WallTag
    {
        public PoolObject wall;
    }
}