//Haiden Gembinski
//Fill In Level 1 Script

using System;
using Random = System.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class FillInLevel1 : MonoBehaviour
{
    public TMP_Text txt;
    string number;

    public GameObject TryAgain;
    public GameObject Success;

    public AudioSource winSound;
    public AudioSource loseSound;

    public string testString;
    public string resetString; //to save blank positions in case of reset

    //scorekeeping
    int line = 8; //corresponds to line for level 1
    string score, file;
    string[] scores;
    int attempted, won;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists("contactActive.txt"))
        {
            using (StreamReader sr = new StreamReader("contactActive.txt"))
            {
                sr.ReadLine(); //skip the first line
                number = sr.ReadLine(); //get the saved number
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

        testString = GenerateBlanks(number);
        resetString = testString;

        //prints out number with blanks to UI
        txt.text = "(" + testString[0] + testString[1] + testString[2] + ")" + testString[3] +
                testString[4] + testString[5] + "-" + testString[6] + testString[7] + testString[8] + testString[9];
    }

    void Update()
    {
        //updates displayed number
        txt.text = "(" + testString[0] + testString[1] + testString[2] + ")" + testString[3] +
                testString[4] + testString[5] + "-" + testString[6] + testString[7] + testString[8] + testString[9];
    }

   string GenerateBlanks(string number) //generates blanks in the number string
    {
        string testString = number;
        int blank1, blank2, blank3;
        Random rnd = new Random();

        blank1 = rnd.Next(0, 10);
        blank2 = rnd.Next(0, 10);
        blank3 = rnd.Next(0, 10);

        //ensure no blank is the same
        while (blank2 == blank1 || blank2 == blank3)
        {
            blank2 = rnd.Next(0, 10);
        }

        while (blank3 == blank1 || blank3 == blank2)
        {
            blank3 = rnd.Next(0, 10);
        }

        testString = testString.Remove(blank1, 1).Insert(blank1, "_");
        testString = testString.Remove(blank2, 1).Insert(blank2, "_");
        testString = testString.Remove(blank3, 1).Insert(blank3, "_");

        return testString;
    }

    public void CheckAnswer()
    {
        //scorekeeping
        score = GetLine(file, line); //get the appropriate line, file is set in Start()
        scores = score.Split(' ');
        attempted = Int32.Parse(scores[0]);
        won = Int32.Parse(scores[1]);

        if (number == testString) //win condition
        {
            Success.SetActive(true);
            attempted += 1;
            won += 1;
            winSound.Play();
        }
        else
        {
            TryAgain.SetActive(true);
            attempted += 1;
            loseSound.Play();
        }

        score = attempted + " " + won;

        ChangeLine(score, file, line); //rewrite to file
        ChangeLine(score, "contactActive.txt", line); //also rewrite to contactActive
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
