//Haiden Gembinski
//Script to clear input fields on enable or disable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoClearInput : MonoBehaviour
{
    public InputField nameInput, numberInput, streetInput, cityInput, stateInput, zipInput;

    void OnEnable()
    {
        //clear input fields
        nameInput.text = "";
        numberInput.text = "";
        streetInput.text = "";
        cityInput.text = "";
        stateInput.text = "";
        zipInput.text = "";
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
