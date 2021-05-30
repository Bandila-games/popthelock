using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BandilaGames.Sounds;
public class GameManager : MonoBehaviour
{
    [SerializeField] RectTransform ControllerCircle;
    [SerializeField] RectTransform TargetCircle;
    [SerializeField] float rotationSpeed = 1;

    int currentLevel = 1;

    bool isClockWise = false;
    bool isGameStart = false;

    private void Awake()
    {
        StartGame();
    }


    public void StartGame()
    {
        //RRotate
        isGameStart = true;
        StartCoroutine(RotateControllerCircle());
   
    }

    public IEnumerator RotateControllerCircle()
    {

        while(isGameStart)
        {
            if(isClockWise)
            {
                //rotate clock wise
                LeanTween.rotateZ(ControllerCircle.gameObject, ControllerCircle.eulerAngles.z + rotationSpeed, 0.01f);
              
            }
            else
            {
                //rotate counter clockwise
                LeanTween.rotateZ(ControllerCircle.gameObject, ControllerCircle.eulerAngles.z - rotationSpeed, 0.01f);
            }
            yield return null;
        }


        yield return null;
    }


    public void CounterRotation()
    {
        isClockWise = !isClockWise;
        rotationSpeed += 0.25f;
        LeanTween.rotateZ(TargetCircle.gameObject, Random.Range(0,360), 0.01f);

    }

    public void Surprise()
    {
        MonoHelper.Run(SoundManager.instance.Play(GAMEBGM.MAINBGM, isLoop: true));
    }
}
