//THE METHOD CHECKUSERANSWER RUNS EVERYTIME A GAMEOBJECT IS DESTROYED
//IF THE COMBINED BLANKS ARE EQUAL TO THE CURRENT NAME THE END GAME SCENE IS LOAD 
//ELSE THE GAME WILL CONTINUE TO SPAWN LETTERS 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;
using UnityEngine.SceneManagement;


public class checkScore : MonoBehaviour
{
	public Button btn1;
	public Button btn2;
	public Button btn3;
	public Button btn4;
	public Button btn5;
	public Button btn6;
	public Button btn7;
	public Button btn8;
	public Button btn9;
	public Button btn10;
	public Button btn11;
	public Button btn12;
	public Button btn13;

    //scorekeeping
    string file;
    int line = 40; //default to line for level 1

    void Start()
    {
        //game level from player prefs
        int level = PlayerPrefs.GetInt("buildingBlocksGameLevel", 0);

        switch (level)
        {
            case 1:
                line = 40;
                break;

            case 2:
                line = 42;
                break;

            case 3:
                line = 44;
                break;
        }

        //figure out what contact is the active one for scorekeeping
        if (FileEquals("contactActive.txt", "contact1.txt"))
        {
            file = "contact1.txt";
        }
        else if (FileEquals("contactActive.txt", "contact2.txt"))
        {
            file = "contact2.txt";
        }
        else if (FileEquals("contactActive.txt", "contact3.txt"))
        {
            file = "contact3.txt";
        }
        else if (FileEquals("contactActive.txt", "contact4.txt"))
        {
            file = "contact4.txt";
        }
    }
	
	public void checkUserAnswer()
	{
		string currentName = "";
        	string userAnswer = "";
		if (btn1 != null){userAnswer = userAnswer + btn1.GetComponentInChildren<TMP_Text>().text;}
		if (btn2 != null){userAnswer = userAnswer + btn2.GetComponentInChildren<TMP_Text>().text;}
		if (btn3 != null){userAnswer = userAnswer + btn3.GetComponentInChildren<TMP_Text>().text;}
		if (btn4 != null){userAnswer = userAnswer + btn4.GetComponentInChildren<TMP_Text>().text;}
		if (btn5 != null){userAnswer = userAnswer + btn5.GetComponentInChildren<TMP_Text>().text;}
		if (btn6 != null){userAnswer = userAnswer + btn6.GetComponentInChildren<TMP_Text>().text;}
		if (btn7 != null){userAnswer = userAnswer + btn7.GetComponentInChildren<TMP_Text>().text;}
		if (btn8 != null){userAnswer = userAnswer + btn8.GetComponentInChildren<TMP_Text>().text;}
		if (btn9 != null){userAnswer = userAnswer + btn9.GetComponentInChildren<TMP_Text>().text;}
		if (btn10 != null){userAnswer = userAnswer + btn10.GetComponentInChildren<TMP_Text>().text;}
		if (btn11 != null){userAnswer = userAnswer + btn11.GetComponentInChildren<TMP_Text>().text;}
		if (btn12 != null){userAnswer = userAnswer + btn12.GetComponentInChildren<TMP_Text>().text;}
		if (btn13 != null){userAnswer = userAnswer + btn13.GetComponentInChildren<TMP_Text>().text;}

		//GRAB CURRENT PHONE NUMBER
		if (File.Exists("contactActive.txt"))
        	{
          	  using (StreamReader sr = new StreamReader("contactActive.txt"))
          	  	//read the first line
			{currentName = sr.ReadLine().ToUpper();}
      	  	}

		string[] firstName = currentName.Split(' ');
		currentName = firstName[0];

		if(userAnswer.Equals(currentName))
		{
            UpdateStats(file, line, true);
			SceneManager.LoadScene("endBuildingBlocks");
		}
		else{}
	}

	// Update is called once per frame
	void Update(){}

    //util

    //updates the scores of given file on the given line
    void UpdateStats(string file, int scoreLine, bool win)
    {
        //scorekeeping
        string score = GetLine(file, scoreLine); //get the appropriate line, file is set in Start()
        string[] scores = score.Split(' ');
        int attempted = Int32.Parse(scores[0]);
        int won = Int32.Parse(scores[1]);

        attempted += 1;

        if (win)
        {
            won += 1;
        }


        score = attempted + " " + won;

        ChangeLine(score, file, scoreLine); //rewrite to file
        ChangeLine(score, "contactActive.txt", scoreLine); //also rewrite to contactActive
    }

    //returns specific line of file (for scorekeeping utility)
    string GetLine(string fileName, int line)
    {
        using (var sr = new StreamReader(fileName))
        {
            for (int i = 1; i < line; i++)
                sr.ReadLine();
            return sr.ReadLine();
        }
    }

    //edits specific line of file (for scorekeeping utility)
    static void ChangeLine(string newText, string fileName, int line_to_edit)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line_to_edit - 1] = newText;
        File.WriteAllLines(fileName, arrLine);
    }

    //compares two files (for scorekeeping utility)
    static bool FileEquals(string path1, string path2)
    {
        byte[] file1 = File.ReadAllBytes(path1);
        byte[] file2 = File.ReadAllBytes(path2);
        if (file1.Length == file2.Length)
        {
            for (int i = 0; i < file1.Length; i++)
            {
                if (file1[i] != file2[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}
