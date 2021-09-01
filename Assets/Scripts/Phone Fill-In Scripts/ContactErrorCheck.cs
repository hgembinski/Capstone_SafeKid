using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ContactErrorCheck : MonoBehaviour
{
    public GameObject errorScreen;

    // Start is called before the first frame update
    void Start() //show error if no active contact exists
    {
        if (!File.Exists("contactActive.txt"))
        {
            errorScreen.SetActive(true);
        }

    }
}
