//Haiden Gembinski
//Number controller script for Fill In Game Level 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberButtonsLevel1 : MonoBehaviour
{
    public GameObject controller;
    public GameObject toneSounds;

    List<int> previousSlots = new List<int>();
    AudioSource[] tones;

    void Start()
    {
        tones = toneSounds.GetComponentsInChildren<AudioSource>();

        if (PlayerPrefs.HasKey("MuteSound")) //check if sound is universally muted
        {
            int muteSounds = PlayerPrefs.GetInt("MuteSound");

            if (muteSounds == 1) //if yes, mute all the number tones
            {
                foreach (AudioSource a in tones)
                {
                    a.mute = true;
                }
            }
        }
    }

    
    //number buttons
    public void Button1()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[1].Play();

        for (int i = 0; i < newTestString.Length; i++) //iterate through string
        {
            index = newTestString[i];
            if (index == '_') //if a blank is found, fill it in once with the number
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "1");
                controller.GetComponent<FillInLevel1>().testString = newTestString; //send the updated string to the other script
                break;
            }
        }
    }

    public void Button2()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[2].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "2");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void Button3()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[3].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "3");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void Button4()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[4].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "4");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void Button5()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[5].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "5");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void Button6()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[6].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "6");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void Button7()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[7].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "7");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void Button8()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[8].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "8");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void Button9()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[9].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "9");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void Button0()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[0].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "0");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void ButtonStar()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[0].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "*");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void ButtonPound()
    {
        char index;
        string newTestString = controller.GetComponent<FillInLevel1>().testString;

        //play sound
        tones[0].Play();

        for (int i = 0; i < newTestString.Length; i++)
        {
            index = newTestString[i];
            if (index == '_')
            {
                previousSlots.Add(i); //save the last edited index
                newTestString = newTestString.Remove(i, 1).Insert(i, "#");
                controller.GetComponent<FillInLevel1>().testString = newTestString;
                break;
            }
        }
    }

    public void clearButton() //resets number with original blanks
    {
        controller.GetComponent<FillInLevel1>().testString = controller.GetComponent<FillInLevel1>().resetString;
        
    }

    public void clearLastButton() //clears the last edited blank
    {
        if (previousSlots.Count > 0)
        {
            string newTestString = controller.GetComponent<FillInLevel1>().testString;
            newTestString = newTestString.Remove(previousSlots[previousSlots.Count - 1], 1).Insert(previousSlots[previousSlots.Count - 1], "_");
            previousSlots.RemoveAt(previousSlots.Count - 1); //remove the utilized index from the list

            controller.GetComponent<FillInLevel1>().testString = newTestString;
        }
    }
}
