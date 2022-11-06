using Game.Consts;
using Game.ECSComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    /// <summary>
    /// Система перемещения мяча.
    /// Управляет только вертикальным перемещением.
    /// </summary>
    public class BallMoveSystem: IEcsInitSystem, IEcsRunSystem
    {
        public const string Name = "BallMoveSystem";
        //-------------------------------------------

        private EcsFilter<GamePlayingTag> _gamePlayingTag;
        private EcsFilter<BallTag> _ballFilter;
        private float _directionY;
        private float _speedY;

        public void Init()
        {
            _speedY = Const.Game.ballSpeedY;
        }
        public void Run()
        {
            if (_gamePlayingTag.IsEmpty())
                return;
            
            foreach (var idx in _ballFilter)
            {
                // Определение направления движения (вверх, вниз)
                _directionY = Input.GetKey(KeyCode.UpArrow) ? 1 : -1;
                // Перемещение мяча по вертикали
                _ballFilter.Get1(idx).ball.transform.Translate(0, _speedY * _directionY * Time.deltaTime, 0);
            }
        }
    }
}