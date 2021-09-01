//Haiden Gembinski
//Script to fill in edit fields on Enable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AutoFillInEdit : MonoBehaviour
{
    public InputField nameInput, numberInput, streetInput, cityInput, stateInput, zipInput;
    public string contactFile;

    string savedName, savedNumber, savedStreet, savedCity, savedState, savedZip;
    

    void OnEnable()
    {

        //get saved data
        if (File.Exists(contactFile))
        {
            using (StreamReader sr = new StreamReader(contactFile))
            {
                savedName = sr.ReadLine();
                savedNumber = sr.ReadLine();
                savedStreet = sr.ReadLine();
                savedCity = sr.ReadLine();
                savedState = sr.ReadLine();
                savedZip = sr.ReadLine();
            }
        }

        //fill in input fields
        nameInput.text = savedName;
        numberInput.text = savedNumber;
        streetInput.text = savedStreet;
        cityInput.text = savedCity;
        stateInput.text = savedState;
        zipInput.text = savedZip;
    }

    void OnDisable()
    {
        //clear input fields
        nameInput.text = "";
        numberInput.text = "";
        streetInput.text = "";
        cityInput.text = "";
        stateInput.text = "";
        zipInput.text = "";
    }
}
