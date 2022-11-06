using Game.ECSComponents;
using Game.Pools;
using Game.Startup;
using Game.Types;
using Game.Utils;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    /// <summary>
    /// Система спавна стен.
    /// </summary>
    public class SpawnWallSystem: IEcsRunSystem
    {
        public const string Name = "SpawnWallSystem";
        //-------------------------------------------

        private EcsFilter<WallSpawnCmd> _wallSpawnCmd;
        private EcsFilter<GameStartEvent> _gameStartEvent;
        private EcsFilter<WallDestroyedEvent> _wallDestroyedEvent;
        
        // Координаты следующего спавна
        private float x, y;
        
        public void Run()
        {
            if (!_gameStartEvent.IsEmpty())
            {
                // Определение координату первой стены.
                x = -Consts.Const.Game.wallDistance.x;
                y = Consts.Const.Game.wallDistance.y;
            
                // Цикл создания стен до границ.
                while (x < Consts.Const.Game.wallDistance.x)
                    CreateWall();
            }

            foreach (var cmd in _wallSpawnCmd)
            {
                ref var spawnComponent = ref _wallSpawnCmd.Get1(cmd);
                
                // Получение объекта из пулла.
                var wall = PoolsObjects.instance.GetObject(PoolObjectType.Wall);

                // Создание тега проверки границ у объекта.
                var wallEntity = EcsStartup.World.NewEntity();
                wallEntity.Get<ObjectCheckBoundTag>().gameObject = wall;
                wallEntity.Get<WallTag>();

                // Установка локальной позиции в объекте мира.
                wall.transform.localPosition = new Vector3(spawnComponent.x, spawnComponent.y, 0);
                _wallSpawnCmd.GetEntity(cmd).Del<WallSpawnCmd>();
            }

            // Пересоздание стен вышедших за границу.
            foreach (var destroyedEventIdx in _wallDestroyedEvent)
            {
                CreateWall();
                _wallDestroyedEvent.GetEntity(destroyedEventIdx).Destroy();
            }
        }

        /// <summary>
        /// Метод вызова комманды на создание стены.
        /// По оси Y должно быть создано 2 стены (верхняя и нижняя).
        /// При создании верхней стены сдвигается координата X.
        /// </summary>
        private void CreateWall()
        {
            EcsUtil.Get(new WallSpawnCmd
            {
                x = x,
                y = y
            });
            
            y = -y;
            if (y > 0)
                x++;
        }
    }
}