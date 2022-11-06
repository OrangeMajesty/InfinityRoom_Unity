using System;

namespace Game.Pools
{
    /// <summary>
    /// Данные генерации одного пулла объектов.
    /// </summary>
    [Serializable]
    public class PoolPrefabs
    {
        // Объект.
        public PoolObject prefab;
        
        // Кол-во объектов в пулле.
        public int count;
        
        // Создание объекта без родителя.
        public bool withoutParent;
    }
}