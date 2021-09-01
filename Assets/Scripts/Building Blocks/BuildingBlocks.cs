//THIS FILE READS THE CONTACT ACTIVE FILE AND POPULATES THE SCENE WITH THE CORRECT
//NUMBER OF BLANKS BASED ON THE LEVEL

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class BuildingBlocks : MonoBehaviour
{
	public List <GameObject> avaliableBlanks = new List<GameObject>();	
	public List <TextMeshProUGUI> availableLetters = new List<TextMeshProUGUI>();	
	string currentName;
	int level = 0;
	int randomnumber;
	public Text letterSlots;
	string blanks = "_";
	
	void Start()
	{
		//SET APPROPRIATE PLAYER PREFS
		level = PlayerPrefs.GetInt("buildingBlocksGameLevel");
		
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
       		char[] temporary = currentName.ToCharArray();
       		char[] unorderedLetters = new char[orderedLetters.Length];
		
		//CREATE SCRAMBLED CHAR LIST 
        	for (int i = orderedLetters.Length; i >= 1; i--)
       		{
            		randomnumber = Random.Range(1, i + 1) - 1;
            		unorderedLetters[i - 1] = temporary[randomnumber];
            		temporary[randomnumber] = temporary[i - 1];
        	}

		//CREATING THE CORRECT NUMBER OF BLANKS
		for (int i = 1; i < orderedLetters.Length; i++)	
        	{
			if (orderedLetters[i] != ' '){ blanks = blanks + " _";}
           		else{ blanks = blanks + "   ";}
		}
		letterSlots.text = blanks;

		//GENERATING & POPULATING BLANKS ON SCREEN
		int startPosition = (13 - orderedLetters.Length) / 2;
		int j = 0;
		for (int i = 0; i < 13; i++)
       		{  
			if(i > (startPosition - 1) && i < (startPosition) + orderedLetters.Length)
			{
				availableLetters[i].text = orderedLetters[j].ToString();
				j++;
			}
			else{Destroy(avaliableBlanks[i]);}

        	}

		//REMOVING NULL BLANKS FROM THE LIST
		while (currentName.Length < availableLetters.Count) 
		{	
		  int i = 0;	
		  for (i = 0; i < availableLetters.Count; i++)
		  {if(availableLetters[i].text.Equals("")){availableLetters.RemoveAt(i);}}
		}
		
		//DETERMINE HOW MANY LETTERS TO REMOVE IN LEVEL 1
		int lettersToRemove = 0;
		switch (currentName.Length)
      		{
          	case 1:
             	 	lettersToRemove = 0;
              		break;
          	case 2:
              		lettersToRemove = 0;
              		break;
          	case 3:
             	 	lettersToRemove = 1;
              		break;
          	case 4:
              		lettersToRemove = 1;
              		break;
          	case 5:
             	 	lettersToRemove = 2;
              		break;
          	case 6:
              		lettersToRemove = 2;
              		break;
          	case 7:
             	 	lettersToRemove = 3;
              		break;
          	case 8:
              		lettersToRemove = 3;
              		break;
          	case 9:
             	 	lettersToRemove = 3;
              		break;
          	case 10:
              		lettersToRemove = 4;
              		break;
          	case 11:
             	 	lettersToRemove = 4;
              		break;
          	case 12:
              		lettersToRemove = 4;
              		break;
          	case 13:
              		lettersToRemove = 4;
              		break;
      		}

		//SETTING DIFFICULTY LEVEL BY SETTING THE NUMBER OF EMPTY BLANKS
		if(level == 1)
		{
			for (int i = 0; i < lettersToRemove; i++)
       			{
				randomnumber = Random.Range(0, currentName.Length - i);
				availableLetters[randomnumber].text = "";
				availableLetters[randomnumber].faceColor = new Color32(0, 0, 0, 0);
			}	
		}
		else if(level == 2)
		{
			lettersToRemove = lettersToRemove * 2;
			for (int i = 0; i < lettersToRemove; i++)
       			{
				randomnumber = Random.Range(0, currentName.Length - i);
				availableLetters[randomnumber].text = "";
				availableLetters[randomnumber].faceColor = new Color32(0, 0, 0, 0);
			}
		}
		else
		{
			for(int i = 0; i < availableLetters.Count; i++)
			{
				availableLetters[randomnumber].text = "";
				availableLetters[i].faceColor = new Color32(0, 0, 0, 0);
			}
		}
				
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
