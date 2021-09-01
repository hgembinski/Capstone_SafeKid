using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;

public class DigitBlank : MonoBehaviour, IDropHandler
{
	public int score = 0;
	public Button btn;
	public Text blank;
	public Text digit;
	string currentName;

    public GameObject audioControl;
    AudioSource winSound, loseSound;

    //scorekeeping
    string file;
    int line;

    Color green = new Color(0.0f, 1.0f, 0.0f);	
    	Color red = new Color(1.0f, 0.0f, 0.0f);

    int blanks; //for alphabet soup
	
	void Start()
    	{	
	btn = GameObject.FindGameObjectWithTag("SubmitButton").GetComponent<Button>();
        audioControl = GameObject.FindGameObjectWithTag("AudioController");
        winSound = audioControl.transform.GetChild(1).GetComponent<AudioSource>();
        loseSound = audioControl.transform.GetChild(2).GetComponent<AudioSource>();
        btn.onClick.AddListener(TaskOnClick);

        PlayerPrefs.SetInt("unscrambleScore", 0);
        PlayerPrefs.SetInt("soupScore", 0);

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
 

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
			eventData.pointerDrag.GetComponent<UIDragger>().inPosition = true;
			digit = eventData.pointerDrag.GetComponent<Text>();
			blank = GetComponent<Text>();

            if (PlayerPrefs.GetString("currentGame").Equals("Unscramble"))
            {
                score = PlayerPrefs.GetInt("unscrambleScore");
            }
            else if (PlayerPrefs.GetString("currentGame").Equals("AlphabetSoup"))
            {
                score = PlayerPrefs.GetInt("soupScore");
            }
		}
		else{}

        if (digit.text.Equals(blank.text))
        {
            score = score + 1;
            if (PlayerPrefs.GetString("currentGame").Equals("Unscramble"))
            {
                PlayerPrefs.SetInt("unscrambleScore", score);
            }
            if (PlayerPrefs.GetString("currentGame").Equals("AlphabetSoup"))
            {
                PlayerPrefs.SetInt("soupScore", score);
            }
        }
        else { }		
	} 

    public void UnscrambleWinCheck() //checks for win in unscramble
    {
        int checkScore = PlayerPrefs.GetInt("unscrambleScore");
        if (PlayerPrefs.GetInt("gameLevel") == 1)
        {
            line = 16;
            if (checkScore > 2)
            {
                //winSound.Play(); -> handled in end game scene
                UpdateStats(file, line, true); //update for win
            }
            else
            {
                loseSound.Play();
                UpdateStats(file, line, false); //update for loss
            }
        }
        else if (PlayerPrefs.GetInt("gameLevel") == 2)
        {
            line = 18; //corresponds to stored score for level 2
            if (checkScore > 5)
            {
                //winSound.Play(); -> handled in end game scene
                UpdateStats(file, line, true); //update for win
            }
            else
            {
                loseSound.Play();
                UpdateStats(file, line, false); //update for loss
            }
        }
        else if (PlayerPrefs.GetInt("gameLevel") == 3)
        {
            line = 20; //corresponds to stored score for level 3
            if (checkScore > 9)
            {
                //winSound.Play(); -> handled in end game scene
                UpdateStats(file, line, true); //update for win
            }
            else
            {
                loseSound.Play();
                UpdateStats(file, line, false); //update for loss
            }
        }
    }

    public void SoupWinCheck() //checks for win in alphabet soup
    {
        int checkScore = PlayerPrefs.GetInt("soupScore");
        blanks = 0;
        if (File.Exists("contactActive.txt"))
        {
            using (StreamReader sr = new StreamReader("contactActive.txt")) { currentName = sr.ReadLine(); }
        }

        foreach (char c in currentName)
        {
            if (c == ' ')
            {
                blanks += 1;
            }
        }

        if (PlayerPrefs.GetInt("alphabetGameLevel") == 1)
        {
            line = 34;
            if (checkScore >= currentName.Length - blanks)
            {
                //winSound.Play(); -> handled in end game scene
                UpdateStats(file, line, true); //update for win
            }
            else
            {
                loseSound.Play();
                UpdateStats(file, line, false); //update for loss
            }
        }
        else if (PlayerPrefs.GetInt("alphabetGameLevel") == 2)
        {
            line = 36; //corresponds to stored score for level 2
            if (checkScore >= currentName.Length - blanks)
            {
                //winSound.Play(); -> handled in end game scene
                UpdateStats(file, line, true); //update for win
            }
            else
            {
                loseSound.Play();
                UpdateStats(file, line, false); //update for loss
            }
        }
        else if (PlayerPrefs.GetInt("alphabetGameLevel") == 3)
        {
            line = 38; //corresponds to stored score for level 3
            if (checkScore >= currentName.Length - blanks)
            {
                //winSound.Play(); -> handled in end game scene
                UpdateStats(file, line, true); //update for win
            }
            else
            {
                loseSound.Play();
                UpdateStats(file, line, false); //update for loss
            }
        }
    }

    void TaskOnClick()
	{		
		if(digit != null)
		{
			if (digit.text.Equals(blank.text)){digit.color = green;}
			else{digit.color = red;}
		}
		else{}
		
		if(PlayerPrefs.GetString("currentGame").Equals("Unscramble"))
		{

            if (PlayerPrefs.GetInt("gameLevel") == 1)
            {
                if (score > 2)
                {
                    SceneManager.LoadScene("endGameUnscramble");
                }
            }
			else if(PlayerPrefs.GetInt("gameLevel") == 2)
            {
                if (score > 5)
                {
                    SceneManager.LoadScene("endGameUnscramble");
                }
            }
			else if(PlayerPrefs.GetInt("gameLevel") == 3)
            {
                if (score > 9)
                {
                    SceneManager.LoadScene("endGameUnscramble");
                }
            } 
			else{}		
		}
		else if(PlayerPrefs.GetString("currentGame").Equals("AlphabetSoup"))
		{
			if (File.Exists("contactActive.txt"))
        		{
                using (StreamReader sr = new StreamReader("contactActive.txt"))
                {
                    currentName = sr.ReadLine();
                    string[] firstName = currentName.Split(' ');
                    currentName = firstName[0];
                }
      	  		}
            blanks = 0;
            foreach (char c in currentName)
            {
                if (c == ' ')
                {
                    blanks += 1;
                }
            }
            if (score >= currentName.Length - blanks)
            {
                SceneManager.LoadScene("endAlphabetSoup");
            }
        }
		else{}

		digit = null;
		blank = null;
	}


    //util

    //updates the scores of given file on the given line
    void UpdateStats(string file, int scoreLine, bool win)
    {
        //scorekeeping
        string score = GetLine(file, scoreLine); //get the appropriate line, file is set in Start()
        string []scores = score.Split(' ');
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
