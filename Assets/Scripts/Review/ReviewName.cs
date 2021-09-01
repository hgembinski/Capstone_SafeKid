//Haiden Gembinski
//Review Name Script

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReviewName : MonoBehaviour
{
    public Text nametxt;
    public Text currentName;
    public GameObject nextButton;
    public GameObject resetButton;
    string displayedName = "";
    string readName = "";
    string current;
    int count = 0;

    void Start()
    {
        if (File.Exists("contactActive.txt"))
        {
            using (StreamReader sr = new StreamReader("contactActive.txt"))
            {
                readName = sr.ReadLine(); //get the saved name from first line of file
            }
        }

        displayedName = BlankOut(readName);

        //populates first char
        current = readName[count].ToString();
        displayedName = displayedName.Remove(count, 1).Insert(count, current); //fills in current index of displayed name with same index of saved name
        currentName.text = displayedName[count].ToString();
        count++;

        //prints blank name to UI to init
        nametxt.text = displayedName;
        

    }

    void Update()
    {
        //update displayed name
        nametxt.text = displayedName;

        if (count == readName.Length) //switches button once all names have been iterated through
        {
            nextButton.SetActive(false);
            resetButton.SetActive(true);
        }
    }

    public void NextCharButton()
    {
        if (count < readName.Length)
        {
            if (readName[count].ToString() == " " && count != readName.Length) //if there's a space, skip ahead to next non-space char
            {
                count++;
            }

            current = readName[count].ToString();
            displayedName = displayedName.Remove(count, 1).Insert(count, current); //fills in current index of displayed name with same index of saved name
            currentName.text = displayedName[count].ToString();
            count++;
        }
    }

    public void ResetButton()
    {
        resetButton.SetActive(false);
        nextButton.SetActive(true);
        displayedName = BlankOut(readName);
        count = 0;

        //populates first char
        current = readName[count].ToString();
        displayedName = displayedName.Remove(count, 1).Insert(count, current); //fills in current index of displayed name with same index of saved name
        currentName.text = displayedName[count].ToString();
        count++;

        //prints blank name to UI to init
        nametxt.text = displayedName;

    }

    string BlankOut(string s) //generates blanks in the number string
    {
        string blankedString = s;

        for (int i = 0; i < blankedString.Length; i++) //blank everything
        {
            if (s[i].ToString() != " ")
            {
                blankedString = blankedString.Remove(i, 1).Insert(i, "_");
            }
            else
            {
                blankedString = blankedString.Remove(i, 1).Insert(i, "\n");
            }
        }

        return blankedString;
    }

}

