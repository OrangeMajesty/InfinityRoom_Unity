using System;
using UnityEngine;

namespace Game.Datas
{
    public partial class DataAssets
    {
        [Serializable]
        public class Prefabs
        {
            [Header("Игровые объекты")]
            [Tooltip("Мяч")]
            public GameObject ball;
            [Tooltip("Стена")]
            public GameObject wall;
            [Tooltip("Препятствие")]
            public GameObject border;
            
        }
    }
}