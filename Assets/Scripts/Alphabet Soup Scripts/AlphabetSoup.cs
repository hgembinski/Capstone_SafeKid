using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class AlphabetSoup : MonoBehaviour
{
    public List<Text> availableLetters = new List<Text>();
    public Text letter1;
    public Text letter2;
    public Text letter3;
    public Text letter4;
    public Text letter5;
    public Text letter6;
    public Text letter7;
    public Text letter8;
    public Text letter9;
    public Text letter10;
    public Text letter11;
    public Text letter12;
    public Text letter13;
    public Text letter14;
    public Text letter15;

    public List<Text> availableBlanks = new List<Text>();
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
    public Text blank11;
    public Text blank12;
    public Text blank13;


    string currentName;
    int level;
    int randomnumber;
    public Text letterSlots;
    string blanks = "_";

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("gameScore", 0);
        PlayerPrefs.SetString("currentGame", "AlphabetSoup");
        level = PlayerPrefs.GetInt("alphabetGameLevel");

        availableLetters.Add(letter1);
        availableLetters.Add(letter2);
        availableLetters.Add(letter3);
        availableLetters.Add(letter4);
        availableLetters.Add(letter5);
        availableLetters.Add(letter6);
        availableLetters.Add(letter7);
        availableLetters.Add(letter8);
        availableLetters.Add(letter9);
        availableLetters.Add(letter10);
        availableLetters.Add(letter11);
        availableLetters.Add(letter12);
        availableLetters.Add(letter13);
        availableLetters.Add(letter14);
        availableLetters.Add(letter15);

        availableBlanks.Add(blank1);
        availableBlanks.Add(blank2);
        availableBlanks.Add(blank3);
        availableBlanks.Add(blank4);
        availableBlanks.Add(blank5);
        availableBlanks.Add(blank6);
        availableBlanks.Add(blank7);
        availableBlanks.Add(blank8);
        availableBlanks.Add(blank9);
        availableBlanks.Add(blank10);
        availableBlanks.Add(blank11);
        availableBlanks.Add(blank12);
        availableBlanks.Add(blank13);

        string[] setOfLetters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        //GRAB CURRENT PHONE NUMBER
        if (File.Exists("contactActive.txt"))
        {
            using (StreamReader sr = new StreamReader("contactActive.txt"))
            //read the first line
            { currentName = sr.ReadLine().ToUpper(); }
        }

        //CREATING CHAR ARRAYS TO SCRAMBLE NAME
        string[] firstName = currentName.Split(' ');
        currentName = firstName[0];
        char[] orderedLetters = currentName.ToCharArray();
        char[] temporary = currentName.ToCharArray();
        char[] unorderedLetters = new char[orderedLetters.Length];

        //CREATE SCRAMBLED CHAR LIST 
        for (int i = orderedLetters.Length; i >= 1; i--)
        {
            randomnumber = Random.Range(1, i + 1) - 1;
            unorderedLetters[i - 1] = temporary[randomnumber];
            temporary[randomnumber] = temporary[i - 1];
        }

        //CREATING THE CORRECT NUMBER OF BLANKS
        for (int i = 1; i < orderedLetters.Length; i++)
        {
            if (orderedLetters[i] != ' ')
            {
                blanks = blanks + " _";
            }
            else
            {
                blanks = blanks + "   ";
            }
        }
        letterSlots.text = blanks;


        //GENERATING CORRECT LETTERS ON SCREEN
        for (int i = 0; i < unorderedLetters.Length; i++)
        { availableLetters[i].text = unorderedLetters[i].ToString(); }

        //GENERTAING RANDOM LETTERS ON SCREEN
        for (int i = unorderedLetters.Length; i < 15; i++)
        {
            int randomnumber = Random.Range(0, setOfLetters.Length);
            availableLetters[i].text = setOfLetters[randomnumber];
        }

        //GENERATING CORRECT NUMBER OF BLANKS ON SCREEN
        int startPosition = (13 - orderedLetters.Length) / 2;
        for (int i = 0; i < 13; i++)
        {

            if (i > (startPosition - 1) && i < (startPosition) + orderedLetters.Length)
            {
                availableBlanks[i].gameObject.AddComponent<DigitBlank>();

            }
            else { Destroy(availableBlanks[i]); }

        }


        //SET DIFFICULTY
        if (level == 0) { }
        else if (level == 1){ for (int i = currentName.Length + 2; i < 14; i++) { availableLetters[i].text = ""; } }
        else if (level == 2){ for (int i = currentName.Length + 4; i < 14; i++) { availableLetters[i].text = ""; } }
        else { for (int i = currentName.Length + 7; i < 14; i++) { availableLetters[i].text = ""; } }
    }

   
    void Update(){ }
}
