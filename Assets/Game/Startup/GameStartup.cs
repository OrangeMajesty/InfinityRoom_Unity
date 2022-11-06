using Game.Consts;
using Game.Datas;
using Game.Models;
using Game.Pools;
using UnityEngine;

namespace Game.Startup
{
    public class GameStartup: MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private PoolsObjects _pools;
        [SerializeField]
        private Data _data;
        [SerializeField]
        private Const _const;
        [SerializeField]
        private WorldStartup _worldStartup;
        [SerializeField]
        private EcsStartup _ecsStartup;
        
        private void Start()
        {
            _worldStartup.Init();
            _pools.Init();
            _const.Init();
            _data.Init();
            Modeler.Init();

            _ecsStartup.Init();
        }

        private void GameRestart()
        {
            // Modeler.Save();
        }
    }
}