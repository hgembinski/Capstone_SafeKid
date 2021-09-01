//Haiden Gembinski
//Review Address Script

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class ReviewAddress : MonoBehaviour
{
    public Text streettxt, citytxt, statetxt, ziptxt;
    public Text currentPart;
    public GameObject nextButton, resetButton;
    string displayedStreet = "";
    string displayedCity = "";
    string displayedState = "";
    string displayedZip = "";
    string street = "";
    string city = "";
    string state = "";
    string zip = "";
    string[] streetParts;
    bool showStreet, showCity, showState, showZip, done;
    int streetCount;
    int index = 0;
    int spLength = 0;
    int count = 0;

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
        }

        streetParts = street.Split(' ');
        streetCount = streetParts.Count();

        foreach (string s in streetParts)
        {
            spLength += s.Length;
        }


        //blank out each part
        displayedStreet = BlankOut(street);
        displayedCity = BlankOut(city);
        displayedState = BlankOut(state);
        displayedZip = BlankOut(zip);

        //display init
        streettxt.text = displayedStreet;
        citytxt.text = displayedCity;
        statetxt.text = displayedState;
        ziptxt.text = displayedZip;

        showStreet = false;
        showCity = false;
        showState = false;
        showZip = false;
        done = false;

    }

    void Update()
    {
        //update displays
        streettxt.text = displayedStreet;
        citytxt.text = displayedCity;
        statetxt.text = displayedState;
        ziptxt.text = displayedZip;

        if (done) //switches button once all parts have been iterated through
        {
            nextButton.SetActive(false);
            resetButton.SetActive(true);
        }
    }

    public void NextPartButton()
    {
        if (showStreet == false)
        {
            if (index + streetParts[count].Length < spLength)
            {
                displayedStreet = displayedStreet.Remove(index, streetParts[count].Length + 1).Insert(index, streetParts[count] + " ");
                index += streetParts[count].Length + 1;
                currentPart.text = streetParts[count];
                count++;
            }

            else
            {
                displayedStreet = displayedStreet.Remove(index, streetParts[count].Length).Insert(index, streetParts[count]);
                index += streetParts[count].Length;
                currentPart.text = streetParts[count];
                count++;
            }

            if (count == streetCount)
            {
                showStreet = true;
            }
        }

        else if (showCity == false)
        {
            displayedCity = city;
            currentPart.text = city;
            showCity = true;
        }

        else if (showState == false)
        {
            displayedState = state;
            currentPart.text = state;
            showState = true;
        }

        else if (showZip == false)
        {
            displayedZip = zip;
            currentPart.text = zip;
            showZip = true;
            done = true;
        }

    }

    public void ResetButton()
    {
        resetButton.SetActive(false);
        nextButton.SetActive(true);

        //blank out each part
        displayedStreet = BlankOut(street);
        displayedCity = BlankOut(city);
        displayedState = BlankOut(state);
        displayedZip = BlankOut(zip);

        //display init
        streettxt.text = displayedStreet;
        citytxt.text = displayedCity;
        statetxt.text = displayedState;
        ziptxt.text = displayedZip;

        showStreet = false;
        showCity = false;
        showState = false;
        showZip = false;
        done = false;

        count = 0;
        index = 0;


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
                blankedString = blankedString.Remove(i, 1).Insert(i, " ");
            }
        }

        return blankedString;
    }
}
