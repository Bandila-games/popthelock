using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[CreateAssetMenu (fileName = "GameData",menuName ="Game Data/Data")]
public class GameData :ScriptableObject
{

    public int CurrentLevel = 1;
    public int HighestLevel = 1;
    public int CurrentScore = 0;
    public int SavedScore;
    public int SavedLevel;

    public void SaveValues()
    {
      if(CurrentScore > SavedScore)
        {
            PlayerPrefs.SetInt("SavedScore", CurrentScore);
        }

      if(CurrentLevel> SavedLevel)
        {
            PlayerPrefs.SetInt("SavedLevel", CurrentLevel);
        }

        PlayerPrefs.Save();
    }

    public void LoadValues()
    {
       
        if (PlayerPrefs.HasKey("SavedScore"))
        {
            SavedScore = PlayerPrefs.GetInt("SavedScore");
            CurrentScore = SavedScore;
        }

        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            SavedLevel = PlayerPrefs.GetInt("SavedLevel");
            CurrentLevel = SavedLevel;
        }
       
    }

    public void ResetValues()
    {

        if(CurrentScore > SavedScore)
        {
            SavedScore = CurrentScore;
            PlayerPrefs.SetInt("SavedScore", CurrentScore);
        }


        CurrentLevel = 1;
        CurrentScore = 0;

      


    }

  

}

