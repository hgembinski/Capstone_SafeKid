using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearInput : MonoBehaviour
{
    public InputField input;
    
    void OnEnable()
    {
        input.text = "";
    }

    void OnDisable()
    {
        input.text = "";
    }
}
