using System;
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
            if (PlayerPrefs.HasKey(MaxTimePlayedKey))
                maxTimePlayed = PlayerPrefs.GetFloat(MaxTimePlayedKey);
        }

        public void Save()
        {
            PlayerPrefs.SetFloat(MaxTimePlayedKey, maxTimePlayed);
            PlayerPrefs.Save();
        }
    }
}