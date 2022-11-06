using System;
using Game.ECSComponents;
using Game.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECSSystems
{
    public class PlayingTimeSystem: IEcsRunSystem
    {
        public const string Name = "PlayingTimeSystem";
        //-------------------------------------------

        private EcsFilter<GameStartEvent> _gameStartEvent;
        private EcsFilter<GamePlayingTag> _gamePlayingTag;

        private float _startTimeOffset;
        
        public void Run()
        {
            if (!_gameStartEvent.IsEmpty())
            {
                _startTimeOffset = Time.time;
            }
            
            if (!_gamePlayingTag.IsEmpty())
                Modeler.ModelGame.playingTime = Time.time - _startTimeOffset;
        }
    }
}