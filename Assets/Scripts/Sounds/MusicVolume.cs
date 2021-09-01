using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider musicVolume;
    
    // Start is called before the first frame update
    void Start()
    {
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume", 0.25f);
    }

    // Update is called once per frame
    public void SetMusicVolume()
    {
        float vol = musicVolume.value;
        PlayerPrefs.SetFloat("MusicVolume", vol);
    }
}
