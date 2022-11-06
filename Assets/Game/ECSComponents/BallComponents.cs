using UnityEngine;

namespace Game.ECSComponents
{
    public struct SpawnBallCmd {}
    public struct BallSpawnedEvent {}

    public struct BallTag
    {
        public GameObject ball;
    }
    
    public struct BallCollisionEvent {}
}