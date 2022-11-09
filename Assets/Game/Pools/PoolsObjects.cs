using System.Collections.Generic;
using Game.Models;
using Game.Types;
using UnityEngine;

namespace Game.Pools
{
    /// <summary>
    /// Класс управляющий списком пуллов.
    /// </summary>
    public class PoolsObjects: MonoBehaviour
    {
        public static PoolsObjects instance;
        private Dictionary<PoolObjectType, List<PoolObject>> _objects;

        [SerializeField, ArrayByEnum(typeof(PoolObjectType))]
        private PoolPrefabs[] _prefabs;

        private Transform rootTransform;

        
        public void OnceInit()
        {
            instance = this;
            
            // Определение родителя.
            rootTransform = Modeler.ModelWorld.WorldGameObject == null
                ? transform
                : Modeler.ModelWorld.WorldGameObject.transform;

            BuildPools();
        }

        /// <summary>
        /// Создание объектов м заполнение словаря.
        /// </summary>
        private void BuildPools()
        {
            _objects = new Dictionary<PoolObjectType, List<PoolObject>>(_prefabs.Length);
            
            for (int i = 0; i < _prefabs.Length; i++)
            {
                _objects.Add((PoolObjectType) i, new List<PoolObject>(_prefabs[i].count));
                for (int o = 0; o < _prefabs[i].count; o++)
                {
                    var parent = _prefabs[i].withoutParent ? null : rootTransform;
                    PoolObject poolObject = Instantiate(_prefabs[i].prefab, parent);
                    poolObject.gameObject.SetActive(false);
                    
                    _objects[(PoolObjectType) i].Add(poolObject);
                }
            }
        }

        /// <summary>
        /// Получение объекта из пулла.
        /// СОздаст объект если в пулле нет свободного объекта.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        
        public PoolObject GetObject(PoolObjectType type)
        {
            for (int i = 0; i < _objects[type].Count; i++)
            {
                if (!_objects[type][i].gameObject.activeInHierarchy)
                {
                    _objects[type][i].gameObject.SetActive(true);
                    return _objects[type][i];
                }
            }
            
            var parent = _prefabs[(int) type].withoutParent ? null : rootTransform;
            PoolObject poolObject = Instantiate(_prefabs[(int) type].prefab, parent);
            _objects[type].Add(poolObject);
            return poolObject;
        }

        /// <summary>
        /// Освобождает все объекты всех пуллов.
        /// </summary>
        public void ReleaseAllObjects()
        {
            foreach (var pollObjects in _objects.Values)
            {
                foreach (var poolObject in pollObjects)
                {
                    poolObject.transform.position = Vector3.zero;
                    poolObject.ReturnToPool();
                }
            }
        }
    }
}