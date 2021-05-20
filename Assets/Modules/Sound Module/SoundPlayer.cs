using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace BandilaGames.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour, ISoundPlayer,IAudioSource
    {
        public SoundplayerType type { get; set; }
        
        [SerializeField]
        public AudioSource source { get; set; }

        public bool IsPlaying => source.isPlaying;

        public string currentClipID { get; set; }

        private void Awake()
        {
            if (source == null) source = GetComponent<AudioSource>();
        }



        public IEnumerator Play(AudioClip audioKey, UnityAction action = null)
        {            
            source.clip = audioKey;
            this.gameObject.name = "SoundPlayer_" + audioKey +"_"+ type.ToString();
            source.Play();
            action?.Invoke();
            yield return null;
        }    

        public IEnumerator SetVolume(float newVolume = 0.75F, UnityAction OnSetVolume = null)
        {
            source.volume = newVolume;
            OnSetVolume?.Invoke();
            yield return null;
        }

        public IEnumerator Stop(UnityAction OnStop = null)
        {
            source.Stop();
            OnStop?.Invoke();
            yield return null;
        }

        public IEnumerator SetLoop(bool isLoop)
        {
            source.loop = isLoop;
            yield return null;
        }
    }
}