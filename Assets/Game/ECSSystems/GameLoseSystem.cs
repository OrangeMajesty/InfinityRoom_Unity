using Game.ECSComponents;
using Game.Models;
using Game.Pools;
using Game.Startup;
using Leopotam.Ecs;

namespace Game.ECSSystems
{
    /// <summary>
    /// Система обрабатывает проигрыш игрока.
    /// Работает по событию колизии мяча.
    /// </summary>
    public class GameLoseSystem: IEcsRunSystem
    {
        public const string Name = "GameLoseSystem";
        //-------------------------------------------

        /// <summary>
        /// Событие колизии.
        /// </summary>
        private EcsFilter<BallCollisionEvent> _ballColisionEvent;
        private EcsFilter<GamePlayingTag> _gamePlayingTag;
        private EcsFilter<BallTag> _ballTag;
        public void Run()
        {
            // Проверка состояния игры.
            if (_gamePlayingTag.IsEmpty())
                return;
            
            if (!_ballColisionEvent.IsEmpty())
            {
                // Сохранение максимального рекорда.
                if (Modeler.ModelPrefs.maxTimePlayed < Modeler.ModelGame.playingTime)
                    Modeler.ModelPrefs.maxTimePlayed = Modeler.ModelGame.playingTime;

                Modeler.ModelPrefs.gameCount++;
                Modeler.ModelPrefs.Save();

                // Показ окна проигрыша.
                UIStartup.LosePopup.Show();
                
                Modeler.ModelGame.playingTime = 0;

                // Возвращение всех объектов в пулл.
                PoolsObjects.instance.ReleaseAllObjects();

                // Удаление тега мяча.
                // Необходимо для предотвращения многократного ускорения мяча.
                foreach (var idx in _ballTag)
                    _ballTag.GetEntity(idx).Destroy();

                // Смена состояние игры на не игровое.
                foreach (var idx in _gamePlayingTag)
                    _gamePlayingTag.GetEntity(idx).Destroy();
            }
        }
    }
}