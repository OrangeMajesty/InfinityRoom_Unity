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
            // Пропускаем генерацию если уже сгенерирован 1 блок на дистанции
            if ((-_worldTransform.position.x + Const.Game.wallDistance.x) - _lastSpawnPositionX < 1)
                return;
            
            if (-_worldTransform.position.x % Const.Game.distanceBorderSpawn < 0.05f)
            {
                var border = PoolsObjects.instance.GetObject(PoolObjectType.Border);
                border.gameObject.SetActive(true);

                // Убираем наслаивание препятствий на стены
                float borderDistanceY = Const.Game.wallDistance.y - 1;
                float targetSpawnX = -_worldTransform.position.x + Const.Game.wallDistance.x;
                float targetSpawnY = Random.Range(borderDistanceY, -borderDistanceY);
                Vector3 targetSpawn = new Vector3(targetSpawnX, targetSpawnY, 0);
                border.transform.localPosition = targetSpawn;
                
                var wallEntity = EcsStartup.World.NewEntity();
                wallEntity.Get<ObjectCheckBoundTag>().gameObject = border;
                wallEntity.Get<BorderTag>().border = border;

                _lastSpawnPositionX = targetSpawnX;
            }
        }
    }
}