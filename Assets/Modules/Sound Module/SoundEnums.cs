using System;

namespace BandilaGames.Sounds
{
    [Serializable]
    public class SOUNDCOLLECTION
    {

    }
    [Serializable]
    public class GAMEBGM : SOUNDCOLLECTION
    {
        public const string MAINBGM = "MAINBGM";
    }
    [Serializable]
    public class GAMESFX : SOUNDCOLLECTION
    {
        public const string TESTSFX = "TESTSFX";
    }

    [Serializable]
    public enum SoundplayerType
    {
        BGM,
        SFX,
        UKNOWN
    }
}