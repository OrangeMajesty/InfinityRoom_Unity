using UnityEngine;

namespace Game.ECSComponents
{
    public struct WallBallCmd
    {
        public float x, y;
    }

    public struct WallTag
    {
        public GameObject ball;
    }
}