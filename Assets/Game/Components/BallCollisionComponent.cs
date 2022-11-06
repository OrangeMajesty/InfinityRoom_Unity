using Game.ECSComponents;
using Game.Startup;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Components
{
    public class BallCollisionComponent: MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var entity = EcsStartup.World.NewEntity();
            entity.Get<BallCollisionEvent>();
        }
    }
}