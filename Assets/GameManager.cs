using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BandilaGames.Sounds;
public class GameManager : MonoBehaviour
{
  
    [SerializeField] public LockController lockController;
    [SerializeField] public GameData gameData;

    [SerializeField] public LoseController loseController;


    [SerializeField] public Button mainButton = null;
    [SerializeField] public Text startTxt = null;

    [SerializeField] public Text lvlTxt = null;
    [SerializeField] public Text scoreTxt = null;
    [SerializeField] public GameObject WinScreen;

    private void Awake()
    {

        gameData.ResetValues();
        lvlTxt.text = "Level:" + gameData.CurrentLevel.ToString();
        scoreTxt.text = "Score:" + gameData.CurrentScore.ToString();
    }

    public void Start()
    {
        loseController.gameObject.SetActive(false);
        lockController.isGameStart = false;
        startTxt.gameObject.SetActive(true);
        mainButton.onClick.RemoveAllListeners();
        mainButton.onClick.AddListener(StartGame);
        lockController.ResetCircles(gameData.CurrentLevel);
        StopBGM();
    }


    public void StartGame()
    {
        StartBGM();
        lockController.isGameStart = true;
        lockController.levelCount = 5* gameData.CurrentLevel;
        lockController.StartRotation();
        lvlTxt.text = "Level:" + gameData.CurrentLevel.ToString();
        scoreTxt.text = "Score:" + gameData.CurrentScore.ToString();

        startTxt.gameObject.SetActive(false);
        mainButton.onClick.RemoveAllListeners();
        mainButton.onClick.AddListener(lockController.CounterRotation);
    }

    public void FinishGame()
    {
        //Animate ending 

        MonoHelper.Run(FinishGameEnumerator());
      
    }

    public void IncrementCurrentLevel()
    {
        gameData.CurrentLevel += 1;
    }    

    public IEnumerator GameFinished(bool isLose)
    {

        Debug.Log("CALLED" + isLose);
        if(isLose)
        {
            gameData.ResetValues();
            yield return LoseEnumerator();
              yield break;
        }


        FinishGame();


        yield break;
    }

    private IEnumerator FinishGameEnumerator()
    {
        Debug.Log("HATDOG");
        WinScreen.SetActive(true);
        Debug.Log("HATDOG2");
        this.gameObject.SetActive(false);
        Debug.Log("HATDOG3");
        yield return new WaitForSeconds(2);
        Debug.Log("HATDOG4");
        IncrementCurrentLevel();
        Start();
       // WinScreen.SetActive(false);
    }


    public IEnumerator LoseEnumerator()
    {
        StopBGM();

        loseController.gameObject.SetActive(true);
        //Play sound
        //ResetLoseAnimation
        //Get Ads for watchable


        //play lose animation
        //Show Lose window choice

        //if(available) set button to show adds 
        //On add finish
        //Start();


        yield break;
    }

    public void AddScore()
    {
        gameData.CurrentScore += 1;
        scoreTxt.text = "Score:" + gameData.CurrentScore.ToString();
    }

  
    public void StartBGM()
    {

        //MonoHelper.Run(SoundManager.instance.SetVolumeOfType(SoundplayerType.BGM, 0.35f));
        MonoHelper.Run(SoundManager.instance.Play(GAMEBGM.SPYBGM,isLoop:true));
     
       
    }

    public void StopBGM()
    {
        MonoHelper.Run(SoundManager.instance.Stop(GAMEBGM.SPYBGM));
    }

    
}
