using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : MonoBehaviour {

    public void SoundMute()
    {
        AudioListener.volume = 0;
    }

    public void SoundUnmute()

    {
        AudioListener.volume = 1;
    }


}
