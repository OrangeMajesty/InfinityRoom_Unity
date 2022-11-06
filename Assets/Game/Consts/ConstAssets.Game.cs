using System;
using UnityEngine;

namespace Game.Consts
{
    public partial class ConstAssets
    {
        [Serializable]
        public class Game
        {
            [Header("Настройка уровня")]
            [Tooltip("Отдаленность стен от середины сцены")]
            public Vector2 wallDistance;
            [Tooltip("Спавн преграды каждые n клеток (1 клетка = 1 unit)")]
            public int distanceBorderSpawn;
            [Tooltip("Начальная скорость мяча по оси Y")]
            public float ballSpeedY;
            [Tooltip("Начальная скорость мяча по оси X")]
            public float ballSpeedX;
            
            [Tooltip("Ускорение мяча каждые n секунд")]
            public float accelerationAfterNSec;
            [Tooltip("Сила ускорение мяча")]
            public float accelerationBall;
        }
    }
}