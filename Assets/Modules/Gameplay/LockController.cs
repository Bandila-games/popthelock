using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BandilaGames.Sounds;

public class LockController : MonoBehaviour
{
    [SerializeField] RectTransform ControllerCircle;
    [SerializeField] RectTransform TargetCircle;
    [SerializeField] float rotationSpeed = 3;
    [SerializeField] float incrementalRotationValue = 0.01f;
    [SerializeField] Text currentLevelCount;

    [SerializeField] public GameObject HardModeTest;

    [SerializeField] public GameManager gameManager;

    [SerializeField] public ColliderDectector colliderDetection;

    [SerializeField] Image glowBG;

    public int levelCount;
    bool isClockWise = false;
    public bool isGameStart = false;
    public bool isHardMode = false;
    int hardModeCtr = 0;
    public float rotationDegrees = 60;

    public void StartRotation()
    {
        //RRotate
        StartCoroutine(RotateControllerCircle());
        currentLevelCount.text = levelCount.ToString();
    }

    public IEnumerator RotateControllerCircle()
    {

        while (isGameStart)
        {
            if (isClockWise)
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

    public void ResetCircles(int gameLevel)
    {
        LeanTween.rotateZ(ControllerCircle.gameObject, 0, 0);
        LeanTween.rotateZ(TargetCircle.gameObject, 90, 0);
        currentLevelCount.text = gameLevel.ToString();
        isClockWise = true;
        isHardMode = false;
        rotationDegrees = 60;
        glowBG.rectTransform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        colliderDetection.isTappedWhileColliding = false;
    }




    public void CounterRotation()
    {         
       
        if (colliderDetection.IsColliding)
        {
            LeanTween.scale(glowBG.gameObject, new Vector3(0.75f, 0.75f, 0.75f), 0.01f).setOnComplete(() => {
                LeanTween.scale(glowBG.gameObject, Vector3.one, 0.05f).setOnComplete(() => {
                    LeanTween.scale(glowBG.gameObject, new Vector3(0.75f, 0.75f, 0.75f), 0.3f);
                });
            });

            MonoHelper.Run(SoundManager.instance.Play(GAMESFX.TESTSFX, null));
            gameManager.AddScore();
          
            if (levelCount >=2)
            {
                isClockWise = !isClockWise;
                rotationSpeed += incrementalRotationValue;
                
                float rotation = isClockWise ? Random.Range(30, rotationDegrees): Random.Range(-rotationDegrees, -30);
               
                LeanTween.rotateZ(TargetCircle.gameObject, rotation, 0.01f);
                levelCount-=1;
                currentLevelCount.text = levelCount.ToString();

                hardModeCtr++;
                if(hardModeCtr>=10)
                {
                    hardModeCtr = 0;
                    isHardMode = !isHardMode;
                }
                HardModeTest.SetActive(isHardMode);
                rotationDegrees = isHardMode ? Random.Range(10,60): Random.Range(40, 180);

                colliderDetection.isTappedWhileColliding = true;

            }
            else
            {
                levelCount--;
                currentLevelCount.text = levelCount.ToString();
                StopRotation();
                 MonoHelper.Run(gameManager.GameFinished(false));
                colliderDetection.isTappedWhileColliding = true;
            }
        }
        else
        {

            StopRotation();
           StartCoroutine(gameManager.GameFinished(true));
        }

       
    }

    public void StopRotation()
    {
        StopCoroutine(RotateControllerCircle());
        LeanTween.cancelAll();
        isGameStart = false;
    }

 
}
