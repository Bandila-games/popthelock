using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BandilaGames.Sounds
{
    [CreateAssetMenu(fileName = "AudioSet", menuName = "Sound/Create AudioSet")]
    public class AudioSet : ScriptableObject
    {
        public Dictionary<string, AudioClip> Library;

        [SerializeField] List<SoundClip> clips = new List<SoundClip>();

        public void InitializeLibrary()
        {
            Library = new Dictionary<string, AudioClip>();
            foreach(SoundClip clip in clips)
            {
                Library.Add(clip.AudioKey, clip.clip);
            }
        }
    }
}


[System.Serializable]
public struct SoundClip
{
    public string AudioKey;
    public AudioClip clip;
}