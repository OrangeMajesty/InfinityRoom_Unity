using Game.Startup;
using Leopotam.Ecs;

namespace Game.Utils
{
    public static class EcsUtil
    {
        public static T Get<T>() where T : struct
        {
            var entity = EcsStartup.World.NewEntity();
            return entity.Get<T>();
        }
        
        public static void Get<T>(T component) where T : struct
        {
            var entity = EcsStartup.World.NewEntity();
            entity.Replace(component);
        }
    }
}