using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buildingBlocksLevelSelection : MonoBehaviour
{
   	public void selectLevel1()
	{
		PlayerPrefs.SetInt("buildingBlocksGameLevel", 1);
        	SceneManager.LoadScene("BuildingBlocks");
	}
	
	public void selectLevel2()
	{
		PlayerPrefs.SetInt("buildingBlocksGameLevel", 2);
        	SceneManager.LoadScene("BuildingBlocks");
	}
	
	public void selectLevel3()
	{
		PlayerPrefs.SetInt("buildingBlocksGameLevel", 3);       		
        	SceneManager.LoadScene("BuildingBlocks");
	}	
}
