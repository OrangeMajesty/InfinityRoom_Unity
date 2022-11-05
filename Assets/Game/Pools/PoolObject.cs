using System;
using UnityEngine;

namespace Game.Pools
{
    public class PoolObject: MonoBehaviour
    {
        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}