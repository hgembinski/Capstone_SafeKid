using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;


public class setEndText : MonoBehaviour
{	
	public Text phoneNumber;
	// Start is called before the first frame update
	void Start()
	{
	if (File.Exists("contactActive.txt"))
        {
            using (StreamReader sr = new StreamReader("contactActive.txt"))
            {
                sr.ReadLine(); //skip the first line
                phoneNumber.text = sr.ReadLine(); //get the saved number
            }
        }
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
