using Game.Consts;
using Game.Datas;
using Game.Models;
using UnityEngine;

namespace Game.Startup
{
    public class GameStartup: MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private Data _data;
        [SerializeField]
        private Const _const;
        [SerializeField]
        private EcsStartup _ecsStartup;
        
        private void Start()
        {
            Modeler.Init();
            _const.Init();
            _data.Init();
            _ecsStartup.Init();
        }
    }
}