using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BandilaGames.Sounds;

public class LoseController : MonoBehaviour
{

    [SerializeField] public RectTransform continueContainer;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public MenuController menuController;

    [SerializeField] public Button _NoButton;
    [SerializeField] public Button _YesButton;

    private void OnEnable()
    {
        //Get ads 
        //Animate dragon bones lose 

        MonoHelper.Run(SoundManager.instance.Play(GAMEBGM.DRUMBGM,isLoop:false));


        MonoHelper.Run(LoseEnumerator());

    }


    public IEnumerator LoseEnumerator()
    {

        LeanTween.scale(continueContainer, Vector3.zero, 0).setOnComplete(() => {
            _NoButton.onClick.RemoveListener(NoSelect);
            _NoButton.enabled = false;
            _YesButton.onClick.RemoveListener(YesSelect);
            _YesButton.enabled = false;

            _NoButton.onClick.AddListener(NoSelect);
            _YesButton.onClick.AddListener(YesSelect);
            LeanTween.scale(continueContainer, Vector3.one, 1).setEaseOutBounce().setOnComplete(() => {
                _NoButton.enabled = true;
                _YesButton.enabled = true;
            });

        });

        yield break;
    }


    private void NoSelect()
    {
        //Close LoseController;
        this.gameObject.SetActive(false);
        gameManager.gameObject.SetActive(false);
        menuController.gameObject.SetActive(true);
        gameManager.gameData.ResetValues();
    }

    private void YesSelect()
    {
        //Retrieve Ads 

        //If success
        this.gameObject.SetActive(false);
        gameManager.Start();
      //  gameManager.gameData.ResetCurrentValues();

        //disable button
    }

}
