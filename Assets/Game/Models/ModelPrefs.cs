using System;
using Game.Types;
using UnityEngine;

namespace Game.Models
{
    [Serializable]
    public class ModelPrefs
    {
        public float maxTimePlayed;

        private const string MaxTimePlayedKey = "MAX_TIME_PLAYED";

        public void Init()
        {
            if (PlayerPrefs.HasKey(GetPrefKey(Modeler.ModelGame.difficult)))
                maxTimePlayed = PlayerPrefs.GetFloat(GetPrefKey(Modeler.ModelGame.difficult));
            else
                maxTimePlayed = 0;
        }

        public void Save()
        {
            PlayerPrefs.SetFloat(GetPrefKey(Modeler.ModelGame.difficult), maxTimePlayed);
            PlayerPrefs.Save();
        }

        private string GetPrefKey(GameDifficult difficult)
        {
            var difficultStr = difficult.ToString().ToUpper();
            return MaxTimePlayedKey + '_' + difficultStr;
        }
    }
}