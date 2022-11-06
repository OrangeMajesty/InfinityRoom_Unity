using Game.Startup;
using Leopotam.Ecs;

namespace Game.Utils
{
    /// <summary>
    /// Вспомогательный класс для работы с ECS.
    /// </summary>
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