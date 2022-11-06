using System;
using Game.ECSComponents;
using Game.Startup;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Components
{
    public class BallCollisionComponent: MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Collision");

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Collision trigger ");
            var entity = EcsStartup.World.NewEntity();
            entity.Get<BallCollisionEvent>();
        }
    }
}