using UnityEngine;

namespace Game.Consts
{
    /// <summary>
    /// Ассет с игровыми данными.
    /// </summary>
    [CreateAssetMenu(menuName = "Create Game Difficult")]
    public partial class ConstAssets: ScriptableObject
    {
        public Game _game;
    }
}