using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ScoreController : MonoBehaviour
{
    [SerializeField] public GameData gameData;

    private int score = 0;
    private int currentLevel = 1;

    public int Score { get { return score; } }
    public int CurrentLevel { get { return currentLevel; } }

    public void IncrementLevel()
    {
        currentLevel += 1;
        if(gameData.HighestLevel<=currentLevel)
        {
            gameData.HighestLevel = currentLevel;
        }
        gameData.CurrentLevel = currentLevel; 
    }

    public void ResetScore()
    {

    }

    public void TrySaveHighScore(int _score)
    {
        score = _score;
    }

    
}
