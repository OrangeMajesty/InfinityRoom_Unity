using Game.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    public class WorldMoveSystem: IEcsInitSystem, IEcsRunSystem
    {
        public const string Name = "WorldMoveSystem";
        //-------------------------------------------
        
        private Transform _worldTransform;

        public void Init()
        {
            _worldTransform = Modeler.ModelWorld.WorldGameObject.transform;
        }
        
        public void Run()
        {
            _worldTransform.Translate(Modeler.ModelWorld.SpeedMove * Time.deltaTime * -1f, 0, 0);
        }
    }
}