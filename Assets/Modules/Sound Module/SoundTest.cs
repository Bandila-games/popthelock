using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BandilaGames.Sounds;

public class SoundTest : MonoBehaviour
{

    private void OnEnable()
    {
        
    }

    public void SoundPlay()
    {
       MonoHelper.Run(SoundManager.instance.Play(GAMESFX.TESTSFX,SoundplayerType.SFX,null));
    }
    public void SoundStop()
    {
        MonoHelper.Run(SoundManager.instance.Play(GAMEBGM.MAINBGM, null));
    }

}
