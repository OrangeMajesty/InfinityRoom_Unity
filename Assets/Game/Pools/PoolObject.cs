using UnityEngine;

namespace Game.Pools
{
    /// <summary>
    /// Объект пулла.
    /// Базовый класс.
    /// </summary>
    public class PoolObject: MonoBehaviour
    {
        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}