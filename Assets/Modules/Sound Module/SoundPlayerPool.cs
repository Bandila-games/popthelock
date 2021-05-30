using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace BandilaGames.Sounds
{
    public class SoundPlayerPool : MonoBehaviour, ISoundPlayerPool
    {
       
        public List<ISoundPlayer> soundPlayerList { get; set; }
        public SoundPlayer soundPlayerPrefab { get; set; }

        private void Awake()
        {
            soundPlayerList = new List<ISoundPlayer>();
            soundPlayerPrefab = Resources.Load<SoundPlayer>("SoundPlayerPrefab");
            
        }


        public ISoundPlayer GetAvailableSoundPlayer()
        {
            if (soundPlayerList == null) soundPlayerList= new List<ISoundPlayer>();
            if (soundPlayerList.Count <= 0) //empty
            {               
                soundPlayerList.Add(CreateSoundPlayer());
                return soundPlayerList[soundPlayerList.Count-1];
            }
            else
            {
                foreach(SoundPlayer soundPlayer in soundPlayerList)
                {
                    if(soundPlayer.IsPlaying == false)
                    {
                        return soundPlayer;
                    }
                }
                soundPlayerList.Add(CreateSoundPlayer());
                return soundPlayerList[soundPlayerList.Count - 1];
            }
        }

        private ISoundPlayer CreateSoundPlayer()
        {
            ISoundPlayer soundPlayer = Instantiate(soundPlayerPrefab, this.transform);
          
            return soundPlayer;
        }

        public IEnumerator SetVolume(string audioKey, float value = 0.75F)
        {
           foreach(ISoundPlayer i in soundPlayerList)
            {
                if(i.currentClipID == audioKey)
                {
                    yield return i.SetVolume(value);
                    break;
                }
            }
            yield return null;
        }

        public IEnumerator Stop(string audioKey)
        {
            foreach (ISoundPlayer i in soundPlayerList)
            {
                if (i.currentClipID == audioKey)
                {
                   yield return i.Stop();
                    break;
                }
            }
            yield return null;
        }
    }
}