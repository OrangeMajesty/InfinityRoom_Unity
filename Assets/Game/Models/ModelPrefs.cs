using System;
using Game.Types;
using UnityEngine;

namespace Game.Models
{
    /// <summary>
    /// Модель хранит и управляет данными PlayerPrefs.
    /// Используется для хранения лучшего игрового времени на сложности и кол-ва попыток.
    /// </summary>
    [Serializable]
    public class ModelPrefs
    {
        public float maxTimePlayed;
        public float gameCount;

        private const string MaxTimePlayedKey = "MAX_TIME_PLAYED";
        private const string GameCountKey = "GAME_COUNT";

        public void Init()
        {
            maxTimePlayed = GetValue(MaxTimePlayedKey);
            gameCount = GetValue(GameCountKey);
        }

        public void Save()
        {
            PlayerPrefs.SetFloat(GetPrefKey(MaxTimePlayedKey, Modeler.ModelGame.difficult), maxTimePlayed);
            PlayerPrefs.SetFloat(GetPrefKey(GameCountKey, Modeler.ModelGame.difficult), gameCount);
            PlayerPrefs.Save();
        }

        private float GetValue(string key)
        {
            if (PlayerPrefs.HasKey(GetPrefKey(key, Modeler.ModelGame.difficult)))
               return PlayerPrefs.GetFloat(GetPrefKey(key, Modeler.ModelGame.difficult));

            return 0;
        }

        private string GetPrefKey(string baseKey, GameDifficult difficult)
        {
            var difficultStr = difficult.ToString().ToUpper();
            return baseKey + '_' + difficultStr;
        }
    }
}