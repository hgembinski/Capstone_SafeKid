using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
	public Text buttonText;
	public Button btn;
	public Image image; 

	public void PassLevel1()
    {
        PlayerPrefs.SetInt("gameLevel", 1);
        PlayerPrefs.SetString("currentGame", "Unscramble");
        SceneManager.LoadScene("Unscramble");
	}

	public void PassLevel2()
	{
		PlayerPrefs.SetInt("gameLevel", 2);
        PlayerPrefs.SetString("currentGame", "Unscramble");
        SceneManager.LoadScene("Unscramble");
	}

	public void PassLevel3()
	{
		PlayerPrefs.SetInt("gameLevel", 3);
        PlayerPrefs.SetString("currentGame", "Unscramble");
        SceneManager.LoadScene("Unscramble");
	}
}
