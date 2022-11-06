using System;
using Game.Consts;
using UnityEngine;

namespace Game.Models
{
    [Serializable]
    public class ModelWorld
    {
        public void Init()
        {
            SpeedMove = Const.Game.ballSpeedX;
        }
        
        public GameObject WorldGameObject;
        public float SpeedMove;
    }
}