using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BandilaGames.Sounds;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{

    [SerializeField] public Text highScoreTxt;
    [SerializeField] public GameData gameData;


    // Start is called before the first frame update
    void Start()
    {

        // StartBGM();
    }

    private void OnEnable()
    {
     
    }
    private void FixedUpdate()
    {
        highScoreTxt.text = gameData.SavedScore.ToString();
    }
    public void StartBGM()
    {

        //MonoHelper.Run(SoundManager.instance.SetVolumeOfType(SoundplayerType.BGM, 0.35f));
        MonoHelper.Run(SoundManager.instance.Play(GAMEBGM.SPYBGM, isLoop: true));


    }
   

    //3 * 5 = 15
    //
}
