using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    void Awake()
    {
        int muteMusic = PlayerPrefs.GetInt("MuteMusic");
        GameObject[] music = GameObject.FindGameObjectsWithTag("BackgroundMusic");

        DontDestroyOnLoad(this.gameObject);

        if (music.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (muteMusic == 0 && gameObject.GetComponent<AudioSource>().isPlaying == false)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    void Update()
    {
        int muteMusic = PlayerPrefs.GetInt("MuteMusic");

        if (muteMusic == 0 && gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (muteMusic == 1)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }

        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume", 0.25f);

    }
}
