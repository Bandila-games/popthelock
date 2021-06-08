using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BandilaGames.Sounds;
public class GameManager : MonoBehaviour
{
  
    [SerializeField] public LockController lockController;
   

    [SerializeField] public Button mainButton = null;
    [SerializeField] public Text startTxt = null;

    [SerializeField] public GameObject WinScreen;

    private void Awake()
    {

      

    }

    private void Start()
    {
        
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


        if(isLose)
        {

            Start();
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
        yield return new WaitForSeconds(3);
        Debug.Log("HATDOG4");
        IncrementCurrentLevel();
        Start();
       // WinScreen.SetActive(false);
    }

  
    public void StartBGM()
    {
     
        MonoHelper.Run(SoundManager.instance.Play(GAMEBGM.SUPERBGM,isLoop:true));
     
       
    }

    public void StopBGM()
    {
        MonoHelper.Run(SoundManager.instance.Stop(GAMEBGM.SUPERBGM));
    }

    
}
