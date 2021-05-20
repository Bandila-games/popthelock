using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BandilaGames.Sounds
{
    [CreateAssetMenu(fileName = "Sound library",menuName ="Sound/Create Sound Library")]
    public class SoundLibrary : ScriptableObject
    {
        [SerializeField] public List<AudioSet> Libraries = new List<AudioSet>();
       
        public AudioClip FindClip(string audiokey)
        {
            if(LibrariesArePopulated()==false)
            {
                GatherLibraries();
            }

            foreach (AudioSet i in Libraries)
            {
                if(i.Library == null)
                {
                    i.InitializeLibrary();
                }

                if (i.Library.ContainsKey(audiokey))
                {
                    return i.Library[audiokey];
                }
            }

            return null;
        }

        private bool LibrariesArePopulated()
        {
            if (Libraries == null) { Libraries = new List<AudioSet>(); return false; }
            if (Libraries.Count <= 0) { return false; }

            return true;
        }

        private void GatherLibraries()
        {
            Libraries = new List<AudioSet>(); 
            Libraries = Resources.LoadAll<AudioSet>("Audiosets").ToList();

            foreach(AudioSet i in Libraries)
            {
                i.InitializeLibrary();
            }
        }
    }
}
