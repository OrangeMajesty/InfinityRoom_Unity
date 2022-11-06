using Game.ECSComponents;
using Game.Startup;
using Leopotam.Ecs;

namespace Game.ECSSystems
{
    public class GameStartSystem: IEcsInitSystem
    {
        public const string Name = "GameLoseSystem";
        //-------------------------------------------
        public void Run()
        {
            // throw new System.NotImplementedException();
        }

        public void Init()
        {
            var entity = EcsStartup.World.NewEntity();
            entity.Get<GameStartEvent>();
            
            var entityPlayingTag = EcsStartup.World.NewEntity();
            entityPlayingTag.Get<GamePlayingTag>();
        }
    }
}