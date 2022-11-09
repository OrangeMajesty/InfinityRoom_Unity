using System;
using Game.Consts;
using Game.Models;
using Game.Pools;
using Game.Services.Metrics;
using UnityEngine;

namespace Game.Startup
{
    /// <summary>
    /// Точка входа в игру.
    /// Компонент управляет игрой.
    /// </summary>
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
        [SerializeField]
        private MetricStartup _metricStartup;

        private static GameStartup _instance;
        
        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            _instance._metricStartup.OnceInit();
            _instance._worldStartup.OnceInit();
            _instance._pools.OnceInit();
            
            GameRestart();
        }

        public static void GameRestart()
        {
            _instance._uiStartup.Init();
            _instance._const.Init();
            Modeler.Init();

            _instance._ecsStartup.Init();
        }
    }
}