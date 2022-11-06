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
        
        private void Start()
        {
            _uiStartup.Init();
            _worldStartup.Init();
            _pools.Init();
            _const.Init();
            Modeler.Init();

            _ecsStartup.Init();
        }

        private void GameRestart()
        {
            // Modeler.Save();
        }
    }
}