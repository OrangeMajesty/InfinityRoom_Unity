using Game.Models;
using UnityEngine;

namespace Game.Startup
{
    /// <summary>
    /// Компонент записывает в модель ссылку на свой go.
    /// </summary>
    public class WorldStartup: MonoBehaviour
    {
        public void Init()
        {
            Modeler.ModelWorld.WorldGameObject = gameObject;
        }
    }
}