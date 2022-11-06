using UnityEngine;

namespace Game.ECSComponents
{
    /// <summary>
    /// Команда спавна мяча.
    /// </summary>
    public struct SpawnBallCmd {}
    
    /// <summary>
    /// Тег мяча. Используется для поиска объекта.
    /// </summary>
    public struct BallTag
    {
        public GameObject ball;
    }
    
    /// <summary>
    /// Событие столкновения мяча с любой преградой.
    /// </summary>
    public struct BallCollisionEvent {}
}