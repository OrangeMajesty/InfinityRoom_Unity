using Game.Models;
using UnityEngine;

namespace Game.Startup
{
    public class WorldStartup: MonoBehaviour
    {
        public void Init()
        {
            Modeler.ModelWorld.WorldGameObject = gameObject;
        }
    }
}