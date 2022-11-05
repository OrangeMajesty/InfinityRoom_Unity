using UnityEngine;

namespace Game.Datas
{
    [CreateAssetMenu(menuName = "Create game data")]
    public partial class DataAssets: ScriptableObject
    {
        public Prefabs _prefabs;
    }
}