using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class alphabetSoupLevelSelection : MonoBehaviour
{
	public void selectLevel1()
	{
		PlayerPrefs.SetInt("alphabetGameLevel", 1);
        PlayerPrefs.SetString("currentGame", "AlphabetSoup");
		SceneManager.LoadScene("AlphabetSoup");
	}
	
	public void selectLevel2()
	{
		PlayerPrefs.SetInt("alphabetGameLevel", 2);
        PlayerPrefs.SetString("currentGame", "AlphabetSoup");
        SceneManager.LoadScene("AlphabetSoup");
	}
	
	public void selectLevel3()
	{
		PlayerPrefs.SetInt("alphabetGameLevel", 3);
        PlayerPrefs.SetString("currentGame", "AlphabetSoup");
        SceneManager.LoadScene("AlphabetSoup");
	}	
}
