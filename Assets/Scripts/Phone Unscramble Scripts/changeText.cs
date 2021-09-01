using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class changeText : MonoBehaviour
{		
    public Text digit1;
    public Text digit2;
    public Text digit3;
    public Text digit4;
    public Text digit5;
    public Text digit6;
    public Text digit7;
    public Text digit8;
    public Text digit9;
    public Text digit10;
    public Text digit11;
    public Text digit12;
    public Text digit13;

    public Text blank1;
    public Text blank2;
    public Text blank3;
    public Text blank4;
    public Text blank5;
    public Text blank6;
    public Text blank7;
    public Text blank8;
    public Text blank9;
    public Text blank10;


    // Start is called before the first frame update
    void Start()
    {
	PlayerPrefs.SetInt("gameScore", 0);
	PlayerPrefs.SetString("currentGame", "Unscramble");
	string phoneNumber = "";

	//GRAB CURRENT PHONE NUMBER
	if (File.Exists("contactActive.txt"))
        {
            using (StreamReader sr = new StreamReader("contactActive.txt"))
            {
                sr.ReadLine(); //skip the first line
                phoneNumber = sr.ReadLine(); //get the saved number
            }
        }

        char[] orderedDigits = phoneNumber.ToCharArray();
        char[] temporary = phoneNumber.ToCharArray();
        char[] unorderedDigits = new char[orderedDigits.Length];
        
	int randomnumber;
	Color zm = digit1.color;
        zm.a = 0.0f;
	int level = PlayerPrefs.GetInt("gameLevel");

	//CREATE SCRAMBLED CHAR LIST 
        for (int i = orderedDigits.Length; i >= 1; i--)
        {
            randomnumber = Random.Range(1, i + 1) - 1;
            unorderedDigits[i - 1] = temporary[randomnumber];
            temporary[randomnumber] = temporary[i - 1];
        }
	
        digit1.text =  unorderedDigits[0].ToString();
	digit2.text = unorderedDigits[1].ToString();
        digit3.text = unorderedDigits[2].ToString();
	digit4.text= unorderedDigits[3].ToString();
        digit5.text = unorderedDigits[4].ToString();
	digit6.text= unorderedDigits[5].ToString();
        digit7.text = unorderedDigits[6].ToString();
	digit8.text= unorderedDigits[7].ToString();
        digit9.text = unorderedDigits[8].ToString();
	digit10.text= unorderedDigits[9].ToString();

        blank1.text = orderedDigits[0].ToString();
        blank2.text = orderedDigits[1].ToString();
        blank3.text = orderedDigits[2].ToString();
        blank4.text = orderedDigits[3].ToString();
        blank5.text = orderedDigits[4].ToString();
        blank6.text = orderedDigits[5].ToString();
        blank7.text = orderedDigits[6].ToString();
        blank8.text = orderedDigits[7].ToString();
        blank9.text = orderedDigits[8].ToString();
        blank10.text = orderedDigits[9].ToString();

        //SET DIFFICULTY
        if (level == 0){}

        else if (level == 1)
        {
	//MAKE DIGITS TRANSPARENT	
	    blank1.color = zm;	
	    blank4.color = zm;
	    blank7.color = zm;
        }

        else if (level == 2)
        {
	    blank1.color = zm;
	    blank3.color = zm;	
	    blank4.color = zm;
	    blank5.color = zm;	
	    blank7.color = zm;
	    blank9.color = zm;
            digit11.text = Random.Range(0, 9).ToString();
        }
        else
        {
	    blank1.color = zm;
	    blank2.color = zm;	
	    blank3.color = zm;	
	    blank4.color = zm;
	    blank5.color = zm;	
	    blank6.color = zm;	
	    blank7.color = zm;
	    blank8.color = zm;	
	    blank9.color = zm;
	    blank10.color = zm;	
            digit11.text = Random.Range(0, 9).ToString();
            digit12.text = Random.Range(0, 9).ToString();
        }
	
    }

    // Update is called once per frame
    void Update()
    {

    }

}
