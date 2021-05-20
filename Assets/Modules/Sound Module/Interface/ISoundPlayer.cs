using System.Collections;
using UnityEngine.Events;
using UnityEngine;

namespace BandilaGames.Sounds
{
    public interface ISoundPlayer
    {
        SoundplayerType type { get; set; }

        string currentClipID { get; set; }

        IEnumerator Play(AudioClip audioKey, UnityAction OnPlay = null);

        IEnumerator SetLoop(bool isLoop);

        IEnumerator SetVolume(float newVolume = 0.75f, UnityAction OnSetVolume = null);

        IEnumerator Stop(UnityAction OnStop = null);
    }

    public interface IAudioSource
    {
        AudioSource source { get; set; }
    }
}