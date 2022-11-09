using Game.Consts;
using Game.ECSComponents;
using Game.Models;
using Game.Pools;
using Game.Startup;
using Game.Types;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    /// <summary>
    /// Система спавна преград.
    /// </summary>
    public class SpawnBordersSystems: IEcsInitSystem, IEcsRunSystem
    {
        public const string Name = "SpawnBordersSystems";
        //-------------------------------------------
        
        private EcsFilter<GamePlayingTag> _gamePlayingTag;
        private Transform _worldTransform;
        private float _lastSpawnPositionX;

        public void Init()
        {
            _worldTransform = Modeler.ModelWorld.WorldGameObject.transform;
        }
        
        public void Run()
        {
            if (_gamePlayingTag.IsEmpty())
            {
                _lastSpawnPositionX = 0f;
                return;
            }

            // Пропускаем генерацию если последний сгенерированный блок слишком близко.
            if ((-_worldTransform.position.x + Const.Game.wallDistance.x) - _lastSpawnPositionX < 1)
                return;

            Debug.Log($"SpawnBordersSystems {-_worldTransform.position.x} {Const.Game.distanceBorderSpawn} {-_worldTransform.position.x % Const.Game.distanceBorderSpawn}");
            if (-_worldTransform.position.x % Const.Game.distanceBorderSpawn < 1f)
            {
                // Получение объекта.
                var border = PoolsObjects.instance.GetObject(PoolObjectType.Border);
                border.gameObject.SetActive(true);

                // Убираем наслаивание препятствий на стены.
                float borderDistanceY = Const.Game.wallDistance.y - 1;
                
                // Определяем координаты спавна.
                float targetSpawnX = -_worldTransform.position.x + Const.Game.wallDistance.x;
                float targetSpawnY = Random.Range(borderDistanceY, -borderDistanceY);
                Vector3 targetSpawn = new Vector3(targetSpawnX, targetSpawnY, 0);
                border.transform.localPosition = targetSpawn;
                
                // Вешаем тег проверки объекта на выход за границы игры.
                var wallEntity = EcsStartup.World.NewEntity();
                wallEntity.Get<ObjectCheckBoundTag>().gameObject = border;

                _lastSpawnPositionX = targetSpawnX;
            }
        }
    }
}