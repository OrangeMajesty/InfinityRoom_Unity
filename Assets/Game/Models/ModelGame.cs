using System;
using Game.Types;

namespace Game.Models
{
    /// <summary>
    /// Игровая модель, хранит данные о текущем раунде.
    /// </summary>
    [Serializable]
    public class ModelGame
    {
        public GameDifficult difficult;
        public float playingTime;
    }
}