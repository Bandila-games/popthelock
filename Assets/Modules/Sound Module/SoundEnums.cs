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
        public const string DRUMBGM = "DRUMBGM";
        public const string SUPERBGM = "SUPERBGM";
        public const string SPYBGM = "SPYBGM";
    }
    [Serializable]
    public class GAMESFX : SOUNDCOLLECTION
    {
        public const string TESTSFX = "TESTSFX";

        public const string POP = "POP";


    }

    [Serializable]
    public enum SoundplayerType
    {
        BGM,
        SFX,
        UKNOWN
    }
}