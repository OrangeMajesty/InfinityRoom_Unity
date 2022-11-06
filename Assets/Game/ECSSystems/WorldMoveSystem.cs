using Game.Consts;
using Game.ECSComponents;
using Game.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    public class WorldMoveSystem: IEcsInitSystem, IEcsRunSystem
    {
        public const string Name = "WorldMoveSystem";
        //-------------------------------------------
        private EcsFilter<GamePlayingTag> _gamePlayingTag;
        private Transform _worldTransform;

        public void Init()
        {
            _worldTransform = Modeler.ModelWorld.WorldGameObject.transform;
        }
        
        public void Run()
        {
            if (_gamePlayingTag.IsEmpty())
                return;
            
            var addSpeed = Const.Game.accelerationBall *
                           (int) (Modeler.ModelGame.playingTime / Const.Game.accelerationAfterNSec);
            
            _worldTransform.Translate((addSpeed + Modeler.ModelWorld.SpeedMove) * Time.deltaTime * -1f, 0, 0);
        }
    }
}