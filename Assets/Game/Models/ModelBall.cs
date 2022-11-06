using System;
using Game.Consts;

namespace Game.Models
{
    [Serializable]
    public class ModelBall
    {
        public float speed;

        public void Init()
        {
            speed = Const.Game.ballSpeedY;
        }
    }
}