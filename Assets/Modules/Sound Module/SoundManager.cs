using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BandilaGames.Sounds
{
    [RequireComponent(typeof(AudioListener))]
    public class SoundManager : MonoBehaviour, ISoundManager,ISoundLibraryOwner
    {
        //Initialize
        [SerializeField] public AudioListener listener { get; set; }

        public ISoundPlayerPool soundPlayerPool { get; set; }
        public SoundLibrary Library { get; set; }

        public static SoundManager instance;

        private void Awake()
        {
            if (listener == null) listener = GetComponent<AudioListener>();
            if (soundPlayerPool == null) soundPlayerPool = GetComponent<SoundPlayerPool>();


            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            RetrieveLibrary();

            DontDestroyOnLoad(this.gameObject);
        }

    

        public IEnumerator Play(string audioKey, UnityAction OnPlay = null)
        {
            //AudioClip clipToPlay = Find in library
            
           AudioClip clipToPlay = Library.FindClip(audioKey);
           if(clipToPlay == null) { Debug.LogError("CANT FIND AUDIOKEY"); yield break; }

           ISoundPlayer soundPlayer = soundPlayerPool.GetAvailableSoundPlayer();
            soundPlayer.currentClipID = audioKey;
           yield return soundPlayer.Play(clipToPlay);

            yield return null;
        }
        public IEnumerator Play(string audioKey, SoundplayerType type = SoundplayerType.SFX,UnityAction OnPlay = null)
        {
            //AudioClip clipToPlay = Find in library

            AudioClip clipToPlay = Library.FindClip(audioKey);
            if (clipToPlay == null) { Debug.LogError("CANT FIND AUDIOKEY"); yield break; }

            ISoundPlayer soundPlayer = soundPlayerPool.GetAvailableSoundPlayer();
            soundPlayer.currentClipID = audioKey;
            soundPlayer.type = type;
            yield return soundPlayer.Play(clipToPlay);

            yield return null;
        }
        public IEnumerator Play(string audioKey, SoundplayerType type = SoundplayerType.SFX, float volume = 0.75F, UnityAction OnPlay = null)
        {

            AudioClip clipToPlay = Library.FindClip(audioKey);
            if (clipToPlay == null) { Debug.LogError("CANT FIND AUDIOKEY"); yield break; }

            ISoundPlayer soundPlayer = soundPlayerPool.GetAvailableSoundPlayer();
            soundPlayer.currentClipID = audioKey;
            soundPlayer.type = type;
            yield return soundPlayer.SetVolume(volume);
            yield return soundPlayer.Play(clipToPlay);
        }

        public IEnumerator Play(string audioKey, SoundplayerType type = SoundplayerType.SFX, float volume = 0.75F, bool isLoop = false, UnityAction OnPlay = null)
        {
            AudioClip clipToPlay = Library.FindClip(audioKey);
            if (clipToPlay == null) { Debug.LogError("CANT FIND AUDIOKEY"); yield break; }

            ISoundPlayer soundPlayer = soundPlayerPool.GetAvailableSoundPlayer();
            soundPlayer.currentClipID = audioKey;
            soundPlayer.type = type;
            yield return soundPlayer.SetVolume(volume);
            yield return soundPlayer.SetLoop(isLoop);
            yield return soundPlayer.Play(clipToPlay);
        }


        public IEnumerator Stop(string audioKey, UnityAction onStop = null)
        {
            yield return soundPlayerPool.Stop(audioKey);
            onStop?.Invoke();
        }

      
        public IEnumerator SetVolumeOfType(SoundplayerType type = SoundplayerType.BGM, float value = 0.75F)
        {
            throw new System.NotImplementedException();
        }

        public void RetrieveLibrary()
        {
          Library= Resources.Load<SoundLibrary>("SoundLibrary");
        }
    }
}