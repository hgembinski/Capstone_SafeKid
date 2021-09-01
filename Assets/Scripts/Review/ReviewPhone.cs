//Haiden Gembinski
//Review Phone Script

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReviewPhone : MonoBehaviour
{
    public Text numbertxt;
    public Text currentNumber;
    public GameObject nextButton;
    public GameObject resetButton;
    string displayedNumber;
    string number = "";
    string current;
    int count = 0;

    void Start()
    {
        displayedNumber = "__________";

        using (StreamReader sr = new StreamReader("contactActive.txt"))
        {
            sr.ReadLine();
            number = sr.ReadLine(); //get the saved number from 2nd line of file
        }

        //populates first number
        current = number[count].ToString();
        displayedNumber = displayedNumber.Remove(count, 1).Insert(count, current); //fills in current index of displayed number with same index of saved number
        currentNumber.text = displayedNumber[count].ToString();
        count++;

        //prints blank number to UI to init
        numbertxt.text = "(" + displayedNumber[0] + displayedNumber[1] + displayedNumber[2] + ") " + displayedNumber[3] +
                displayedNumber[4] + displayedNumber[5] + " - " + displayedNumber[6] + displayedNumber[7] + displayedNumber[8] + displayedNumber[9];

    }

    void Update()
    {
        //update displayed number
        numbertxt.text = "(" + displayedNumber[0] + displayedNumber[1] + displayedNumber[2] + ") " + displayedNumber[3] +
                displayedNumber[4] + displayedNumber[5] + " - " + displayedNumber[6] + displayedNumber[7] + displayedNumber[8] + displayedNumber[9];

        if (count == 10) //switches button once all numbers have been iterated through
        {
            nextButton.SetActive(false);
            resetButton.SetActive(true);
        }
    }

    public void NextNumberButton()
    {
        if (count < 10)
        {
            current = number[count].ToString();
            displayedNumber = displayedNumber.Remove(count, 1).Insert(count, current); //fills in current index of displayed number with same index of saved number
            currentNumber.text = displayedNumber[count].ToString();
            count++;
        }
    }

    public void ResetButton()
    {
        resetButton.SetActive(false);
        nextButton.SetActive(true);
        displayedNumber = "__________";
        count = 0;

        //populates first number
        current = number[count].ToString();
        displayedNumber = displayedNumber.Remove(count, 1).Insert(count, current); //fills in current index of displayed number with same index of saved number
        currentNumber.text = displayedNumber[count].ToString();
        count++;

        //prints blank number to UI to init
        numbertxt.text = "(" + displayedNumber[0] + displayedNumber[1] + displayedNumber[2] + ") " + displayedNumber[3] +
                displayedNumber[4] + displayedNumber[5] + " - " + displayedNumber[6] + displayedNumber[7] + displayedNumber[8] + displayedNumber[9];

    }

}

