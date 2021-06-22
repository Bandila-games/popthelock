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

    [SerializeField] public GameObject _ScoreIncrement;
    [SerializeField] public GameObject _CircleSpot;


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
           
            var spot = _CircleSpot.transform.position;
            _ScoreIncrement.gameObject.SetActive(false);
            
            LeanTween.move(_ScoreIncrement.gameObject, spot, 0).setOnComplete(()=> {
                _ScoreIncrement.gameObject.SetActive(true);
                LeanTween.move(_ScoreIncrement.gameObject, new Vector3(spot.x, spot.y + 150f, spot.z), 0.3f).setOnComplete(()=> {

                    _ScoreIncrement.gameObject.SetActive(false);
                });
                       
            });

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
                
                float rotation = isClockWise ? Random.Range(TargetCircle.eulerAngles.z+45, TargetCircle.eulerAngles.z + rotationDegrees): Random.Range(TargetCircle.eulerAngles.z - rotationDegrees, TargetCircle.eulerAngles.z - 45);
               
                LeanTween.rotateZ(TargetCircle.gameObject, rotation, 0.01f);
                levelCount-=1;
                gameManager.gameData.CurrentPopsLeft -= 1;
                currentLevelCount.text = levelCount.ToString();

                hardModeCtr++;
                if(hardModeCtr>=10)
                {
                    hardModeCtr = 0;
                    isHardMode = !isHardMode;
                }
                HardModeTest.SetActive(isHardMode);
                rotationDegrees = isHardMode ? Random.Range(30,80): Random.Range(100, 240);

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
