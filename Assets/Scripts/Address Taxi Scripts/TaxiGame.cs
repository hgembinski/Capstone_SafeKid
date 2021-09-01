//Haiden Gembinski
//Taxi Game Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System.Linq;

public class TaxiGame : MonoBehaviour
{
    public GameObject streetPreset1, streetPreset2, streetPreset3, streetPreset4, streetPreset5, streetPreset6, streetPreset7, streetPreset8; //street layout presets
    public GameObject cityButton, stateButton, zipButton; //other address objects
    public GameObject editScreen, winScreen, loseScreen; //pop up screens
    public Text editText;
    public InputField editInput;
    public int difficulty = 1; //difficulty level

    //win/lose tones
    public AudioSource winSound;
    public AudioSource loseSound;

    int scramble1, scramble2, scramble3, scramble4; //for use with rnd
    GameObject button1, button2, button3, button4, button5, button6, button7, button8; //buttons corresponding to street parts
    string street, city, state, zip; //original address parts
    string[] streetParts; //parts of the street
    int streetCount; // # of items in the street
    int currentButton; //tracks current button for edit screen, 1-8 are street buttons, 9 is city, 10 is state, 11 is zip
    List<GameObject> address = new List<GameObject>(); //list of address objects
    List<String> correctAddress = new List<String>(); //list of correct address objects to check against

    //scorekeeping
    int line = 22; //defaults to line for level 1
    string score, file;
    string[] scores;
    int attempted, won;

    static Random rnd = new Random();

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists("contactActive.txt"))
        {
            using (StreamReader sr = new StreamReader("contactActive.txt"))
            {
                sr.ReadLine();
                sr.ReadLine();
                street = sr.ReadLine(); //get the saved street from third line of file
                city = sr.ReadLine(); //get the city from fourth line
                state = sr.ReadLine(); //get the state from fifth line
                zip = sr.ReadLine(); //get the zip from sixth line
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

            switch(difficulty) //corresponding line in file for scores
            {
                case 1:
                    line = 22;
                    break;
                case 2:
                    line = 24;
                    break;
                case 3:
                    line = 26;
                    break;
            }
        }

        streetParts = street.Split(' ');
        streetCount = streetParts.Count();

        //store correct address
        foreach(string s in streetParts)
        {
            correctAddress.Add(s);
        }

        correctAddress.Add(city);
        correctAddress.Add(state);
        correctAddress.Add(zip);

        //other address parts
        cityButton.GetComponentInChildren<TMP_Text>().text = city.ToString();
        stateButton.GetComponentInChildren<TMP_Text>().text = state.ToString();
        zipButton.GetComponentInChildren<TMP_Text>().text = zip.ToString();

        switch (streetCount) //display proper buttons for street parts
        {
            case 1:
                button1 = streetPreset1.transform.GetChild(0).gameObject;
                streetPreset1.SetActive(true);

                button1.GetComponentInChildren<TMP_Text>().text = streetParts[0];

                address.Add(button1);
                break;

            case 2:
                button1 = streetPreset2.transform.GetChild(0).gameObject;
                button2 = streetPreset2.transform.GetChild(1).gameObject;
                streetPreset2.SetActive(true);

                button1.GetComponentInChildren<TMP_Text>().text = streetParts[0];
                button2.GetComponentInChildren<TMP_Text>().text = streetParts[1];

                address.Add(button1);
                address.Add(button2);
                break;

            case 3:
                button1 = streetPreset3.transform.GetChild(0).gameObject;
                button2 = streetPreset3.transform.GetChild(1).gameObject;
                button3 = streetPreset3.transform.GetChild(2).gameObject;
                streetPreset3.SetActive(true);

                button1.GetComponentInChildren<TMP_Text>().text = streetParts[0];
                button2.GetComponentInChildren<TMP_Text>().text = streetParts[1];
                button3.GetComponentInChildren<TMP_Text>().text = streetParts[2];

                address.Add(button1);
                address.Add(button2);
                address.Add(button3);
                break;

            case 4:
                button1 = streetPreset4.transform.GetChild(0).gameObject;
                button2 = streetPreset4.transform.GetChild(1).gameObject;
                button3 = streetPreset4.transform.GetChild(2).gameObject;
                button4 = streetPreset4.transform.GetChild(3).gameObject;
                streetPreset4.SetActive(true);

                button1.GetComponentInChildren<TMP_Text>().text = streetParts[0];
                button2.GetComponentInChildren<TMP_Text>().text = streetParts[1];
                button3.GetComponentInChildren<TMP_Text>().text = streetParts[2];
                button4.GetComponentInChildren<TMP_Text>().text = streetParts[3];

                address.Add(button1);
                address.Add(button2);
                address.Add(button3);
                address.Add(button4);
                break;

            case 5:
                button1 = streetPreset5.transform.GetChild(0).gameObject;
                button2 = streetPreset5.transform.GetChild(1).gameObject;
                button3 = streetPreset5.transform.GetChild(2).gameObject;
                button4 = streetPreset5.transform.GetChild(3).gameObject;
                button5 = streetPreset5.transform.GetChild(4).gameObject;
                streetPreset5.SetActive(true);

                button1.GetComponentInChildren<TMP_Text>().text = streetParts[0];
                button2.GetComponentInChildren<TMP_Text>().text = streetParts[1];
                button3.GetComponentInChildren<TMP_Text>().text = streetParts[2];
                button4.GetComponentInChildren<TMP_Text>().text = streetParts[3];
                button5.GetComponentInChildren<TMP_Text>().text = streetParts[4];

                address.Add(button1);
                address.Add(button2);
                address.Add(button3);
                address.Add(button4);
                address.Add(button5);
                break;

            case 6:
                button1 = streetPreset6.transform.GetChild(0).gameObject;
                button2 = streetPreset6.transform.GetChild(1).gameObject;
                button3 = streetPreset6.transform.GetChild(2).gameObject;
                button4 = streetPreset6.transform.GetChild(3).gameObject;
                button5 = streetPreset6.transform.GetChild(4).gameObject;
                button6 = streetPreset6.transform.GetChild(5).gameObject;
                streetPreset6.SetActive(true);

                button1.GetComponentInChildren<TMP_Text>().text = streetParts[0];
                button2.GetComponentInChildren<TMP_Text>().text = streetParts[1];
                button3.GetComponentInChildren<TMP_Text>().text = streetParts[2];
                button4.GetComponentInChildren<TMP_Text>().text = streetParts[3];
                button5.GetComponentInChildren<TMP_Text>().text = streetParts[4];
                button6.GetComponentInChildren<TMP_Text>().text = streetParts[5];

                address.Add(button1);
                address.Add(button2);
                address.Add(button3);
                address.Add(button4);
                address.Add(button5);
                address.Add(button6);
                break;

            case 7:
                button1 = streetPreset7.transform.GetChild(0).gameObject;
                button2 = streetPreset7.transform.GetChild(1).gameObject;
                button3 = streetPreset7.transform.GetChild(2).gameObject;
                button4 = streetPreset7.transform.GetChild(3).gameObject;
                button5 = streetPreset7.transform.GetChild(4).gameObject;
                button6 = streetPreset7.transform.GetChild(5).gameObject;
                button7 = streetPreset7.transform.GetChild(6).gameObject;
                streetPreset7.SetActive(true);

                button1.GetComponentInChildren<TMP_Text>().text = streetParts[0];
                button2.GetComponentInChildren<TMP_Text>().text = streetParts[1];
                button3.GetComponentInChildren<TMP_Text>().text = streetParts[2];
                button4.GetComponentInChildren<TMP_Text>().text = streetParts[3];
                button5.GetComponentInChildren<TMP_Text>().text = streetParts[4];
                button6.GetComponentInChildren<TMP_Text>().text = streetParts[5];
                button7.GetComponentInChildren<TMP_Text>().text = streetParts[6];

                address.Add(button1);
                address.Add(button2);
                address.Add(button3);
                address.Add(button4);
                address.Add(button5);
                address.Add(button6);
                address.Add(button7);
                break;

            case 8:
                button1 = streetPreset8.transform.GetChild(0).gameObject;
                button2 = streetPreset8.transform.GetChild(1).gameObject;
                button3 = streetPreset8.transform.GetChild(2).gameObject;
                button4 = streetPreset8.transform.GetChild(3).gameObject;
                button5 = streetPreset8.transform.GetChild(4).gameObject;
                button6 = streetPreset8.transform.GetChild(5).gameObject;
                button7 = streetPreset8.transform.GetChild(6).gameObject;
                button8 = streetPreset8.transform.GetChild(7).gameObject;
                streetPreset8.SetActive(true);

                button1.GetComponentInChildren<TMP_Text>().text = streetParts[0];
                button2.GetComponentInChildren<TMP_Text>().text = streetParts[1];
                button3.GetComponentInChildren<TMP_Text>().text = streetParts[2];
                button4.GetComponentInChildren<TMP_Text>().text = streetParts[3];
                button5.GetComponentInChildren<TMP_Text>().text = streetParts[4];
                button6.GetComponentInChildren<TMP_Text>().text = streetParts[5];
                button7.GetComponentInChildren<TMP_Text>().text = streetParts[6];
                button8.GetComponentInChildren<TMP_Text>().text = streetParts[7];

                address.Add(button1);
                address.Add(button2);
                address.Add(button3);
                address.Add(button4);
                address.Add(button5);
                address.Add(button6);
                address.Add(button7);
                address.Add(button8);
                break;
        }

        address.Add(cityButton);
        address.Add(stateButton);
        address.Add(zipButton);

        //difficulty determines how many parts of the address are scrambled, 1 = 2 parts, 2 = 4 parts, 3 = everything
        switch (difficulty)
        {
            case 1:
                //scramble two parts of the address
                scramble1 = rnd.Next(0, address.Count);
                scramble2 = rnd.Next(0, address.Count);

                //ensure each scramble number is unique
                while (scramble1 == scramble2)
                {
                    scramble2 = rnd.Next(0, address.Count);
                }

                address[scramble1].GetComponentInChildren<TMP_Text>().text = Scramble(address[scramble1].GetComponentInChildren<TMP_Text>().text);
                address[scramble2].GetComponentInChildren<TMP_Text>().text = Scramble(address[scramble2].GetComponentInChildren<TMP_Text>().text);
                break;

            case 2:
                //scramble four parts of the address
                scramble1 = rnd.Next(0, address.Count);
                scramble2 = rnd.Next(0, address.Count);
                scramble3 = rnd.Next(0, address.Count);
                scramble4 = rnd.Next(0, address.Count);

                //ensure each scramble number is unique
                while (scramble2 == scramble1 || scramble2 == scramble3 || scramble2 == scramble4)
                {
                    scramble2 = rnd.Next(0, address.Count);
                }

                while (scramble3 == scramble1 || scramble3 == scramble2 || scramble3 == scramble4)
                {
                    scramble3 = rnd.Next(0, address.Count);
                }

                while (scramble4 == scramble1 || scramble4 == scramble2 || scramble4 == scramble3)
                {
                    scramble4 = rnd.Next(0, address.Count);
                }

                address[scramble1].GetComponentInChildren<TMP_Text>().text = Scramble(address[scramble1].GetComponentInChildren<TMP_Text>().text);
                address[scramble2].GetComponentInChildren<TMP_Text>().text = Scramble(address[scramble2].GetComponentInChildren<TMP_Text>().text);
                address[scramble3].GetComponentInChildren<TMP_Text>().text = Scramble(address[scramble3].GetComponentInChildren<TMP_Text>().text);
                address[scramble4].GetComponentInChildren<TMP_Text>().text = Scramble(address[scramble4].GetComponentInChildren<TMP_Text>().text);
                break;

            case 3:
                //scramble everything
                foreach (GameObject g in address)
                {
                    g.GetComponentInChildren<TMP_Text>().text = Scramble(g.GetComponentInChildren<TMP_Text>().text);
                }
                break;

        }
    }

    //Buttons
    public void Button1()
    {
        editScreen.SetActive(true);
        currentButton = 1;

        editText.text = button1.GetComponentInChildren<TMP_Text>().text;   
    }

    public void Button2()
    {
        editScreen.SetActive(true);
        currentButton = 2;

        editText.text = button2.GetComponentInChildren<TMP_Text>().text;
    }

    public void Button3()
    {
        editScreen.SetActive(true);
        currentButton = 3;

        editText.text = button3.GetComponentInChildren<TMP_Text>().text;
    }

    public void Button4()
    {
        editScreen.SetActive(true);
        currentButton = 4;

        editText.text = button4.GetComponentInChildren<TMP_Text>().text;
    }

    public void Button5()
    {
        editScreen.SetActive(true);
        currentButton = 5;

        editText.text = button5.GetComponentInChildren<TMP_Text>().text;
    }

    public void Button6()
    {
        editScreen.SetActive(true);
        currentButton = 6;

        editText.text = button6.GetComponentInChildren<TMP_Text>().text;
    }

    public void Button7()
    {
        editScreen.SetActive(true);
        currentButton = 7;

        editText.text = button7.GetComponentInChildren<TMP_Text>().text;
    }

    public void Button8()
    {
        editScreen.SetActive(true);
        currentButton = 8;

        editText.text = button8.GetComponentInChildren<TMP_Text>().text;
    }

    public void CityButton()
    {
        editScreen.SetActive(true);
        currentButton = 9;

        editText.text = cityButton.GetComponentInChildren<TMP_Text>().text;
    }

    public void StateButton()
    {
        editScreen.SetActive(true);
        currentButton = 10;

        editText.text = stateButton.GetComponentInChildren<TMP_Text>().text;
    }

    public void ZipButton()
    {
        editScreen.SetActive(true);
        currentButton = 11;

        editText.text = zipButton.GetComponentInChildren<TMP_Text>().text;
    }

    public void editDoneButton()
    {
        switch(currentButton)
        {
            case 1:
                button1.GetComponentInChildren<TMP_Text>().text = editInput.text; //set street button 1 text to input field
                editScreen.SetActive(false);
                break;

            case 2:
                button2.GetComponentInChildren<TMP_Text>().text = editInput.text; //set street button 2 text to input field
                editScreen.SetActive(false);
                break;

            case 3:
                button3.GetComponentInChildren<TMP_Text>().text = editInput.text; //set street button 3 text to input field
                editScreen.SetActive(false);
                break;

            case 4:
                button4.GetComponentInChildren<TMP_Text>().text = editInput.text; //set street button 4 text to input field
                editScreen.SetActive(false);
                break;

            case 5:
                button5.GetComponentInChildren<TMP_Text>().text = editInput.text; //set street button 5 text to input field
                editScreen.SetActive(false);
                break;

            case 6:
                button6.GetComponentInChildren<TMP_Text>().text = editInput.text; //set street button 6 text to input field
                editScreen.SetActive(false);
                break;

            case 7:
                button7.GetComponentInChildren<TMP_Text>().text = editInput.text; //set street button 7 text to input field
                editScreen.SetActive(false);
                break;

            case 8:
                button8.GetComponentInChildren<TMP_Text>().text = editInput.text; //set street button 8 text to input field
                editScreen.SetActive(false);
                break;

            case 9:
                cityButton.GetComponentInChildren<TMP_Text>().text = editInput.text; //set city button text to input field
                editScreen.SetActive(false);
                break;

            case 10:
                stateButton.GetComponentInChildren<TMP_Text>().text = editInput.text; //set state button text to input field
                editScreen.SetActive(false);
                break;

            case 11:
                zipButton.GetComponentInChildren<TMP_Text>().text = editInput.text; //set zip button text to input field
                editScreen.SetActive(false);
                break;
        }
    }

    //Win/Loss check
    public void GoButton()
    {
        List<String> checkAddress = new List<String>();
        bool win = true;

        foreach (GameObject g in address)
        {
            checkAddress.Add(g.GetComponentInChildren<TMP_Text>().text);
        }

        for (int i = 0; i < checkAddress.Count; i++)
        {
            if (checkAddress[i] != correctAddress[i])
            {
                win = false;
            }
        }

        //scorekeeping
        score = GetLine(file, line); //get the appropriate line, file is set in Start()
        scores = score.Split(' ');
        attempted = Int32.Parse(scores[0]);
        won = Int32.Parse(scores[1]);

        if (win)
        {
            winScreen.SetActive(true);
            attempted += 1;
            won += 1;
            winSound.Play();
        }
        else
        {
            loseScreen.SetActive(true);
            attempted += 1;
            loseSound.Play();
        }

        score = attempted + " " + won;

        ChangeLine(score, file, line); //rewrite to file
        ChangeLine(score, "contactActive.txt", line); //also rewrite to contactActive
    }

    //method to shuffle string contents
    static string Scramble(string s)
    {

        if (string.IsNullOrEmpty(s))
            return s;
        char[] chars = s.ToCharArray();
        char c;
        int j;
        for (int i = chars.Length - 1; i > 0; i--)
        {
            j = rnd.Next(i + 1);
            if (j == i)
                continue;
            c = chars[j];
            chars[j] = chars[i];
            chars[i] = c;
        }
        return new string(chars);
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
