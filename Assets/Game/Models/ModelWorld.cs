using System;
using Game.Consts;
using UnityEngine;

namespace Game.Models
{
    /// <summary>
    /// Модель мира.
    /// Хранит скорость и ссылку на объект.
    /// </summary>
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