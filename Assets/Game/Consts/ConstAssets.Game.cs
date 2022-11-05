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
            [Tooltip("Скорость мяча по оси x")]
            public float ballSpeedX;
        }
    }
}