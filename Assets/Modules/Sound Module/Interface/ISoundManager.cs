using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace BandilaGames.Sounds
{
    public interface ISoundManager
    {
        AudioListener listener { get; set; }
        ISoundPlayerPool soundPlayerPool {  get;  set; }
        IEnumerator Play(string audioKey, UnityAction OnPlay = null);
        IEnumerator Play(string audioKey, SoundplayerType type = SoundplayerType.SFX, UnityAction OnPlay = null);

        IEnumerator Play(string audioKey, SoundplayerType type = SoundplayerType.SFX, float volume = 0.75f, UnityAction OnPlay = null);

        IEnumerator Play(string audioKey, SoundplayerType type = SoundplayerType.SFX, float volume = 0.75f, bool isLoop = false, UnityAction OnPlay = null);

        IEnumerator Stop(string audioKey, UnityAction onStop = null);

        IEnumerator SetVolumeOfType(SoundplayerType type = SoundplayerType.BGM, float value = 0.75f);

   
    }
}