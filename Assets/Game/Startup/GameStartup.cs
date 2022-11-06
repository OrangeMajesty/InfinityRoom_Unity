using Game.Consts;
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
        private Const _const;
        [SerializeField]
        private WorldStartup _worldStartup;
        [SerializeField]
        private EcsStartup _ecsStartup;
        [SerializeField]
        private UIStartup _uiStartup;

        private static GameStartup _instance;
        
        private void Awake()
        {
            _instance = this;
            GameRestart();
        }

        public static void GameRestart()
        {
            _instance._uiStartup.Init();
            _instance._worldStartup.Init();
            _instance._pools.Init();
            _instance._const.Init();
            Modeler.Init();

            _instance._ecsStartup.Init();
        }
    }
}