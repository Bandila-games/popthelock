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


    [SerializeField] public Text scoreTxt = null;
    [SerializeField] public GameObject WinScreen;
    [SerializeField] public Button WinScreenButton;
    [SerializeField] public Text WinScoreTxt;
    [SerializeField] public Text LvlScoreTxt;


    private int callCounter = 0;

    private void Awake()
    {
      
        gameData.ResetValues();
        startTxt.text = "TAP ANYWHERE TO START!";
        scoreTxt.text = "0";
        callCounter = 0;
    }

  

    public void Start()
    {
        scoreTxt.text = gameData.CurrentScore.ToString();
        callCounter = 0;
        loseController.gameObject.SetActive(false);
        lockController.isGameStart = false;
        startTxt.text = "TAP ANYWHERE TO START!";
        mainButton.onClick.RemoveAllListeners();
        mainButton.onClick.AddListener(StartGame);
        lockController.ResetCircles(gameData.CurrentPopsLeft);
       //StopBGM();
    }


    public void StartGame()
    {
        
        lockController.isGameStart = true;
        lockController.levelCount = gameData.CurrentPopsLeft;
        lockController.StartRotation();
        startTxt.text = "Level: " + gameData.CurrentLevel.ToString();
        scoreTxt.text =  gameData.CurrentScore.ToString();

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
        gameData.CurrentPopsLeft = gameData.CurrentLevel * 5;
    }    

    public IEnumerator GameFinished(bool isLose)
    {

        if(callCounter == 0)
        {
            callCounter = isLose ? 1 : 2;
        }

        Debug.Log("CALLED" + isLose + callCounter);
        if(callCounter==1)
        {
            lockController._ScoreIncrement.gameObject.SetActive(false);
           
            yield return LoseEnumerator();
              yield break;
        }
        else if(callCounter == 2)
        {
            callCounter = 3;
            yield return new WaitForEndOfFrame();
            FinishGame();         
        }



        yield break;
    }

    private IEnumerator FinishGameEnumerator()
    {
        //Debug.Log("HATDOG");
        WinScreen.SetActive(true);
        WinScoreTxt.text = gameData.CurrentScore.ToString();
        LvlScoreTxt.text = "Level: " + gameData.CurrentLevel.ToString();
        WinScreenButton.interactable = false;
       // Debug.Log("HATDOG2");
        this.gameObject.SetActive(false);
       // Debug.Log("HATDOG3");
        yield return new WaitForSeconds(1.4f);
        WinScreenButton.interactable = true;
       // Debug.Log("HATDOG4");
        IncrementCurrentLevel();
        Start();
       // WinScreen.SetActive(false);
    }


    public IEnumerator LoseEnumerator()
    {
        //StopBGM();

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
        scoreTxt.text = gameData.CurrentScore.ToString();
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
