using Game.Types;
using UnityEngine;

namespace Game.Consts
{
    public class Const: MonoBehaviour
    {
        [SerializeField, ArrayByEnum(typeof(GameDifficult))]
        private ConstAssets[] assets;
        
        public static ConstAssets.Game Game => _assets._game;

        private static ConstAssets _assets;

        public void Init()
        {
            
        }
    }
}