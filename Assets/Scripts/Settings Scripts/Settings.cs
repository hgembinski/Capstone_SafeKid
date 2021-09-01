//Haiden Gembinski
//Settings Controller Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle soundToggle;
    public Toggle musicToggle;
    public Slider volume;
    int muteSound;
    int muteMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MuteSound")) //get the saved state for mute sound and set the toggle accordingly
        {
            muteSound = PlayerPrefs.GetInt("MuteSound");
            
            if (muteSound == 1)
            {
                soundToggle.isOn = true;
            }
            else
            {
                soundToggle.isOn = false;
            }
        }

        if (PlayerPrefs.HasKey("MuteMusic")) //get the saved state for mute music and set the toggle accordingly
        {
            muteMusic = PlayerPrefs.GetInt("MuteMusic");

            if (muteMusic == 1)
            {
                musicToggle.isOn = true;
            }

            else
            {
                musicToggle.isOn = false;
            }
        }
    }

    public void SoundToggle() //whether or not to mute the game sound depending on the toggle
    {
        if (soundToggle.isOn == true)
        {
            PlayerPrefs.SetInt("MuteSound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MuteSound", 0);
        }
    }

    public void MusicToggle() //whether or not to mute the game music depending on the toggle
    {
        if (musicToggle.isOn == true)
        {
            PlayerPrefs.SetInt("MuteMusic", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MuteMusic", 0);
        }
    }
}
