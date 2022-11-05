using UnityEngine;

namespace Game.Datas
{
    public class Data: MonoBehaviour
    {
        [SerializeField]
        private DataAssets data;
        public static DataAssets.Prefabs Prefabs => _assets._prefabs;
        private static DataAssets _assets;

        public void Init()
        {
            _assets = data;
        }
    }
}