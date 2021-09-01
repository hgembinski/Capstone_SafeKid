using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class setEndTextAlphabetSoup : MonoBehaviour
{
    public Text currentName;
	// Start is called before the first frame update
	void Start()
	{
	if (File.Exists("contactActive.txt"))
        {
            using (StreamReader sr = new StreamReader("contactActive.txt"))
            {
                currentName.text = sr.ReadLine().ToUpper(); //get the saved name
            }
        }
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
