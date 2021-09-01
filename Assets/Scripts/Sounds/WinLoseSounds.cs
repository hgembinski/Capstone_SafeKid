//Haiden Gembinski
//Win/Lose Sounds Controller Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseSounds : MonoBehaviour
{
    public AudioSource winSound;
    public AudioSource loseSound;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MuteSound"))
        {
            int isSoundMuted = PlayerPrefs.GetInt("MuteSound");

            if (isSoundMuted == 1)
            {
                winSound.mute = true;
                loseSound.mute = true;
            }
        }
    }

}
