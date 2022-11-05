using System;
using Game.Types;

namespace Game.Models
{
    [Serializable]
    public class ModelGame
    {
        public GameDifficult difficult;
        public int score;
        public float playingTime;
    }
}