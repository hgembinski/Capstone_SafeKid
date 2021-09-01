//Alex Bechke
//MailOutGameController Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;
using TMPro; 

public class MailOutGameController : MonoBehaviour
{

    private Text streettxt, citytxt, statetxt, ziptxt;
    string displayedStreet = "";
    string displayedCity = "";
    string displayedState = "";
    string displayedZip = "";
    string street = "";
    string city = "";
    string state = "";
    string zip = "";
    string[] streetParts;
    public List<GameObject> address = new List<GameObject>(); //list of address objects

    int streetCount;
    int spLength = 0;

    //scorekeeping
    string file;
    int line = 32; //line for Level 3 difficulty

    //public GameObject streetPreset1, streetPreset2; //street layout presets
    public GameObject slot1_1, slot2_1, slot2_2, slot3_1, slot3_2, slot3_3, slot4_1, slot4_2, slot4_3, slot4_4, slot5_1, slot5_2, slot5_3, slot5_4, slot5_5,
        slot6_1, slot6_2, slot6_3, slot6_4, slot6_5, slot6_6;


    //public gameObjects to check if the answer is correct. This involved AnswerSlot script
    public AnswerSlot correctSlot1_1, correctSlot2_1, correctSlot2_2, correctSlot3_1, correctSlot3_2, correctSlot3_3, correctSlot4_1, correctSlot4_2, correctSlot4_3,
    correctSlot4_4, correctSlot5_1, correctSlot5_2, correctSlot5_3, correctSlot5_4, correctSlot5_5, correctSlot6_1, correctSlot6_2, correctSlot6_3, correctSlot6_4,
    correctSlot6_5, correctSlot6_6;
 


    //public gameObjects for text to .SetActive(false) on awake and then .SetActive(true) if they need to spawn in via the # of street address parts
    public GameObject cityText, stateText, zipText, streetTextP1, streetTextP2, streetTextP3, streetTextP4, streetTextP5, streetTextP6; 
    
    public GameObject button1, button2, button3, button4, button5, button6, button7, button8, button9; //buttons corresponding to address parts

    public GameObject winScreen;
    public AudioSource winSound, loseSound;

    ColorBlock cb;
    ColorBlock gcb;
    ColorBlock rcb;
    Color grn;
    Color red;

    // Start is called before the first frame update
    void Start()
    {

        //setting streetText pieces to be invisable on start
        streetTextP1.SetActive(false);
        streetTextP2.SetActive(false);
        streetTextP3.SetActive(false);
        streetTextP4.SetActive(false);
        streetTextP5.SetActive(false);
        streetTextP6.SetActive(false);


        if (File.Exists("contactActive.txt"))
        {
            using(StreamReader sr = new StreamReader("contactActive.txt"))
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
        }


        streetParts = street.Split(' '); 
        streetCount = streetParts.Count();

        foreach (string s in streetParts)
        {
            spLength += s.Length;
        }

        List<string> streetPartList = streetParts.ToList();

        GameObject.Find("CityText").GetComponentInChildren<Text>().text = city;
        GameObject.Find("StateText").GetComponentInChildren<Text>().text = state;
        GameObject.Find("ZipText").GetComponentInChildren<Text>().text = zip;

        switch (streetCount) //display proper buttons for street parts
        {
            case 1:

                streetTextP1.SetActive(true);
                streetTextP1.GetComponentInChildren<Text>().text = streetParts[0];

                correctSlot1_1.correctAnswer = streetParts[0];

                button1 = slot1_1.transform.gameObject; 
                
                slot1_1.SetActive(true);
               
                address.Add(button1);
                break;

            case 2:

                streetPartList.Clear();
                streetTextP1.SetActive(true);
                streetTextP1.GetComponentInChildren<Text>().text = streetParts[0];
                streetTextP2.SetActive(true);
                streetTextP2.GetComponentInChildren<Text>().text = streetParts[1];
                
                correctSlot2_1.correctAnswer = streetParts[0];
                correctSlot2_2.correctAnswer = streetParts[1]; 

                button1 = slot2_1.transform.gameObject;
                button2 = slot2_2.transform.gameObject;
                slot2_1.SetActive(true);
                slot2_2.SetActive(true);

                address.Add(button1);
                address.Add(button2);
                break;

            case 3:

                streetPartList.Clear();
                streetTextP1.SetActive(true);
                streetTextP1.GetComponentInChildren<Text>().text = streetParts[0];
                streetTextP2.SetActive(true);
                streetTextP2.GetComponentInChildren<Text>().text = streetParts[1];
                streetTextP3.SetActive(true);
                streetTextP3.GetComponentInChildren<Text>().text = streetParts[2];

                correctSlot3_1.correctAnswer = streetParts[0];
                correctSlot3_2.correctAnswer = streetParts[1];
                correctSlot3_3.correctAnswer = streetParts[2];


                button1 = slot3_1.transform.gameObject;
                button2 = slot3_2.transform.gameObject;
                button3 = slot3_3.transform.gameObject;
                slot3_1.SetActive(true);
                slot3_2.SetActive(true);
                slot3_3.SetActive(true);

                address.Add(button1);
                address.Add(button2);
                address.Add(button3); 
                break;

           case 4:

                streetPartList.Clear();

                streetPartList.Clear();
                streetTextP1.SetActive(true);
                streetTextP1.GetComponentInChildren<Text>().text = streetParts[0];
                streetTextP2.SetActive(true);
                streetTextP2.GetComponentInChildren<Text>().text = streetParts[1];
                streetTextP3.SetActive(true);
                streetTextP3.GetComponentInChildren<Text>().text = streetParts[2];
                streetTextP4.SetActive(true);
                streetTextP4.GetComponentInChildren<Text>().text = streetParts[3];

                button1 = slot3_1.transform.gameObject;
                button2 = slot4_2.transform.gameObject;
                button3 = slot4_2.transform.gameObject;
                button4 = slot4_4.transform.gameObject;

                correctSlot4_1.correctAnswer = streetParts[0];
                correctSlot4_2.correctAnswer = streetParts[1];
                correctSlot4_3.correctAnswer = streetParts[2];
                correctSlot4_4.correctAnswer = streetParts[3];

                slot4_1.SetActive(true);
                slot4_2.SetActive(true);
                slot4_3.SetActive(true);
                slot4_4.SetActive(true);

                address.Add(button1);
                address.Add(button2);
                address.Add(button3);
                address.Add(button4); 
                break;

            case 5:

                streetPartList.Clear();

                streetTextP1.SetActive(true);
                streetTextP1.GetComponentInChildren<Text>().text = streetParts[0];
                streetTextP2.SetActive(true);
                streetTextP2.GetComponentInChildren<Text>().text = streetParts[1];
                streetTextP3.SetActive(true);
                streetTextP3.GetComponentInChildren<Text>().text = streetParts[2];
                streetTextP4.SetActive(true);
                streetTextP4.GetComponentInChildren<Text>().text = streetParts[3];
                streetTextP5.SetActive(true);
                streetTextP5.GetComponentInChildren<Text>().text = streetParts[4];


                button1 = slot5_1.transform.gameObject;
                button2 = slot5_2.transform.gameObject;
                button3 = slot5_3.transform.gameObject;
                button4 = slot5_4.transform.gameObject;
                button5 = slot5_5.transform.gameObject;

                correctSlot5_1.correctAnswer = streetParts[0];
                correctSlot5_2.correctAnswer = streetParts[1];
                correctSlot5_3.correctAnswer = streetParts[2];
                correctSlot5_4.correctAnswer = streetParts[3];
                correctSlot5_5.correctAnswer = streetParts[4];

                slot5_1.SetActive(true);
                slot5_2.SetActive(true);
                slot5_3.SetActive(true);
                slot5_4.SetActive(true);
                slot5_5.SetActive(true);

                address.Add(button1);
                address.Add(button2);
                address.Add(button3);
                address.Add(button4);
                address.Add(button5); 
                break;

            case 6:

                streetPartList.Clear();
                streetTextP1.SetActive(true);
                streetTextP1.GetComponentInChildren<Text>().text = streetParts[0];
                streetTextP2.SetActive(true);
                streetTextP2.GetComponentInChildren<Text>().text = streetParts[1];
                streetTextP3.SetActive(true);
                streetTextP3.GetComponentInChildren<Text>().text = streetParts[2];
                streetTextP4.SetActive(true);
                streetTextP4.GetComponentInChildren<Text>().text = streetParts[3];
                streetTextP5.SetActive(true);
                streetTextP5.GetComponentInChildren<Text>().text = streetParts[4];
                streetTextP6.SetActive(true);
                streetTextP6.GetComponentInChildren<Text>().text = streetParts[5];


                button1 = slot6_1.transform.gameObject;
                button2 = slot6_2.transform.gameObject;
                button3 = slot6_3.transform.gameObject;
                button4 = slot6_4.transform.gameObject;
                button5 = slot6_5.transform.gameObject;
                button6 = slot6_6.transform.gameObject;

                correctSlot6_1.correctAnswer = streetParts[0];
                correctSlot6_2.correctAnswer = streetParts[1];
                correctSlot6_3.correctAnswer = streetParts[2];
                correctSlot6_4.correctAnswer = streetParts[3];
                correctSlot6_5.correctAnswer = streetParts[4];
                correctSlot6_6.correctAnswer = streetParts[5];

                slot6_1.SetActive(true);
                slot6_2.SetActive(true);
                slot6_3.SetActive(true);
                slot6_4.SetActive(true);
                slot6_5.SetActive(true);
                slot6_6.SetActive(true); 

                address.Add(button1);
                address.Add(button2);
                address.Add(button3);
                address.Add(button4);
                address.Add(button5);
                address.Add(button6);
                break;
        }


        //I added the following lines to change how the city/state/zip slots were being handled into buttons that could be added straight to the list similar to the street parts
        button7.GetComponent<AnswerSlot>().correctAnswer = city;
        button8.GetComponent<AnswerSlot>().correctAnswer = state;
        button9.GetComponent<AnswerSlot>().correctAnswer = zip;

        address.Add(button7);
        address.Add(button8);
        address.Add(button9);

        //store color values for later use
        cb = address[0].GetComponent<Button>().colors;
        rcb = cb;
        gcb = cb;
        grn = new Color(0, 128, 0, 255);
        red = new Color(255, 0, 0, 255);
        gcb.normalColor = grn;
        rcb.normalColor = red;
    }

    void update()
    {
        streettxt.text = displayedStreet;
        citytxt.text = displayedCity;
        statetxt.text = displayedState;
        ziptxt.text = displayedZip;
    }

    //when hitting submitButton it should check all the buttons but this is where I am having problems
    public void Submit()
    {
        bool win = true; 
        for (int i = 0; i < address.Count(); i++ ) {
            if (address[i].GetComponent<AnswerSlot>().isCorrect == false)
            {
                win = false;
                address[i].GetComponent<Button>().colors = rcb;
            } else
            {
                address[i].GetComponent<Button>().colors = gcb;
            }
        }
        if (win == true)
        {
            UpdateStats(file, line, true); //update stats for win
            winSound.Play();
            winScreen.SetActive(true);
        }
        else
        {
            loseSound.Play();
            UpdateStats(file, line, false); //update stats for loss
        }
    }

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
