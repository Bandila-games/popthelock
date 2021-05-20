using System.Collections;
using System.Collections.Generic;

namespace BandilaGames.Sounds
{
    public interface ISoundPlayerPool
    {
        List<ISoundPlayer> soundPlayerList { get; set; }

        SoundPlayer soundPlayerPrefab { get; set; }

        ISoundPlayer GetAvailableSoundPlayer();

        IEnumerator SetVolume(string audioKey, float value = 0.75f);

        IEnumerator Stop(string audioKey);

    }
}