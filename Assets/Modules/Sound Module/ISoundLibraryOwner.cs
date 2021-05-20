using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BandilaGames.Sounds
{
    public interface ISoundLibraryOwner 
    {
        SoundLibrary Library { get; set; }

        void RetrieveLibrary();
    }
}