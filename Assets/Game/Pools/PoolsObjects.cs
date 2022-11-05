using System.Collections.Generic;
using Game.Types;
using UnityEngine;

namespace Game.Pools
{
    public class PoolsObjects: MonoBehaviour
    {
        public static PoolsObjects instance;
        private Dictionary<PoolObjectType, List<PoolObject>> _objects;

        [SerializeField, ArrayByEnum(typeof(PoolObjectType))]
        private PoolPrefabs[] _prefabs;

        public void Init()
        {
            instance = this;
            InitPool();
        }

        private void InitPool()
        {
            _objects = new Dictionary<PoolObjectType, List<PoolObject>>(_prefabs.Length);
            
            for (int i = 0; i < _prefabs.Length; i++)
            {
                _objects.Add((PoolObjectType) i, new List<PoolObject>(_prefabs[i].count));
                for (int o = 0; o < _prefabs[i].count; o++)
                {
                    PoolObject poolObject = Instantiate(_prefabs[i].prefab, transform);
                    poolObject.gameObject.SetActive(false);
                    
                    _objects[(PoolObjectType) i].Add(poolObject);
                }
            }
        }

        public PoolObject GetObject(PoolObjectType type)
        {
            for (int i = 0; i < _objects[type].Count; i++)
            {
                if (!_objects[type][i].isActiveAndEnabled)
                {
                    _objects[type][i].gameObject.SetActive(true);
                    return _objects[type][i];
                }
            }
            
            PoolObject poolObject = Instantiate(_prefabs[(int) type].prefab, transform);
            _objects[type].Add(poolObject);
            return poolObject;
        }

        public void ReleaseObject(PoolObject poolObject)
        {
            poolObject.ReturnToPool();
        }
    }
}