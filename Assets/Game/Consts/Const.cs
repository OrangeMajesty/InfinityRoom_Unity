using Game.Models;
using Game.Types;
using UnityEngine;

namespace Game.Consts
{
    public class Const: MonoBehaviour
    {
        [SerializeField, ArrayByEnum(typeof(GameDifficult))]
        private ConstAssets[] assets;
        
        public static ConstAssets.Game Game => _asset._game;

        private static ConstAssets _asset;

        public void Init()
        {
            _asset = assets[(int) Modeler.ModelGame.difficult];
        }
    }
}