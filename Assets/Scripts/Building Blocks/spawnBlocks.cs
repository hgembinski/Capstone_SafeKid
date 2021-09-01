//THIS FILE CREATES THE BLOCK GAME OBJECTS
//THE SPAWNBLOCK METHOD IS CALLED WHEN AN OBJECT IS DESTROYED
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class spawnBlocks : MonoBehaviour
{

	public List <Sprite> letters = new List<Sprite>(); 
	public Canvas gameCanvas;
	int randomnumber;
	string currentName;
	int level;

	void Start()
	{
		PlayerPrefs.SetInt("numberOfBlocks", 0); 
		PlayerPrefs.SetInt("indexofNextLetterInName", 0);
		PlayerPrefs.SetInt("currentLetter", 0);
		level = PlayerPrefs.GetInt("buildingBlocksGameLevel");
		spawnBlock();
	}	
	
	void Update(){}

	public void spawnBlock()
	{
		int m = PlayerPrefs.GetInt("numberOfBlocks");
		m = m + 1;
		PlayerPrefs.SetInt("numberOfBlocks", m);
  		
		//GRAB CURRENT NAME
		if (File.Exists("contactActive.txt"))
        	{
          	  using (StreamReader sr = new StreamReader("contactActive.txt"))
          	  	//read the first line
			{currentName = sr.ReadLine().ToUpper();}
      	  	}

		//CREATING CHAR ARRAYS TO SCRAMBLE NAME
		string[] firstName = currentName.Split(' ');
		currentName = firstName[0];
		char[] orderedLetters = currentName.ToCharArray();
		
		//SETTING THE COMPONENTS OF THE GAME OBJECT
		randomnumber = Random.Range(0, 25);
		GameObject newObject = new GameObject();		
		newObject.transform.SetParent(gameCanvas.transform); 
		newObject.AddComponent<CanvasGroup>();
		newObject.AddComponent<Image>();
		
		//THIS LINE SETS THE SPAWN POSITION OF THE GAME OBJECT TAKING AN X CORDINATE AND A Y CORDINATE
		newObject.transform.position = new Vector2(140, 280);

		newObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (80, 80); 
		newObject.AddComponent<dragBlock>();

		int blocksBetweenRandomBlock = 0;
		if(level == 1){blocksBetweenRandomBlock = 4;}
		else if(level == 2){blocksBetweenRandomBlock = 3;}
		else{blocksBetweenRandomBlock = 2;}			

			if(PlayerPrefs.GetInt("numberOfBlocks") % blocksBetweenRandomBlock == 0)
			{
				randomnumber = Random.Range(0, 25);
				newObject.GetComponent<Image>().sprite = letters[randomnumber];
				PlayerPrefs.SetInt("currentLetter", randomnumber);
			}

			//SETTING THE IMAGE TO A RANDOM BLOCK
			else
			{
				int k = PlayerPrefs.GetInt("indexofNextLetterInName");
				if(k > orderedLetters.Length - 1){k = 0;}

				//THIS LINE SETS THE SPRITE OF THE IMAGE COMPONENT ON THE GAME OBJECT FROM THE 
				//LIST OF SPRITES (0-25) WHERE 1 IS THE A LETTER BLOCK AND 25 IS THE Z LETTER BLOCK  
				newObject.GetComponent<Image>().sprite = letters[(orderedLetters[k] - '0')- 17];
				PlayerPrefs.SetInt("currentLetter", (orderedLetters[k] - '0')- 17);
				k = k + 1;
				PlayerPrefs.SetInt("indexofNextLetterInName", k);
			} 


		//WHEN A GAME OBJECT IS DESTROYED THE SPAWN BLOCK METHOD IS CALLED WHICH CALLS 
		//THE CHECK USER ANSWER FROM CHECK SCORE SCRIPT
		checkScore cs;
		cs = GameObject.FindObjectOfType(typeof(checkScore)) as checkScore;
		cs.checkUserAnswer();
	}

 
}
