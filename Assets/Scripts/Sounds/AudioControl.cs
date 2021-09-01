using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource clickSound;
    //public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MuteSound"))
        {
            int isSoundMuted = PlayerPrefs.GetInt("MuteSound");

            if (isSoundMuted == 1)
            {
                clickSound.mute = true;
            }
        }
    }

    public void UpdateSounds() //Only used on settings screen to ensure sound prefs take effect without reloading scene
    {
        if (PlayerPrefs.HasKey("MuteSound"))
        {
            int isSoundMuted = PlayerPrefs.GetInt("MuteSound");

            if (isSoundMuted == 1)
            {
                clickSound.mute = true;
            }
            else
            {
                clickSound.mute = false;
            }
        }
    }
}
