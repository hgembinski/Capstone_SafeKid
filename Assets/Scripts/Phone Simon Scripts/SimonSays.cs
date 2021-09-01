using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System;


public class SimonSays : MonoBehaviour
{
    bool freezeInput; //use to "freeze" the numberpad while "simon" gives the sequence
    bool gameOver; //track if wrong number is entered
    bool gamerunning; //is the game currently running

    public int digits; //how many digits to show on current pass
    public int position; //where in the pass you are
    public int state; //for frame updater
    
    //Stores color shift data;
    ColorBlock cb; 
    ColorBlock ncb;
    Color nc;

    //timers
    public float lightbutton;
    private float lightbuttontime;
    public float sequencedelay;
    private float sequencedelaytime;

    //containers
    int[] phone; 
    Button[] buttons;
    AudioSource[] soundsTones;
    AudioSource[] soundsNotes;
    public List<int> sourceNum;
    public List<int> enteredNum; 
    string number;

    //obj refrences
    public Text messageText;
    public Text hintText;
    public GameObject failScreen;
    public GameObject winScreen;

    //options vars
    public bool easyMode = false;
    public int speedMult = 1;
    public bool enableSound = true;

    //sounds vars
    public int soundChoice = 0;
    public AudioSource winSound;
    public AudioSource loseSound;
    public GameObject soundWrapperNotes;
    public GameObject soundWrapperTones;

    //scorekeeping
    int line = 14; //corresponds to line in file for simon score
    string score, file;
    string[] scores;
    int attempted, won;

    // Start is called before the first frame update
    void Start()
    {
        //set the state flags to inital values
        freezeInput = true;
        gameOver = false;
        gamerunning = false;
        state = 1;

        if (File.Exists("contactActive.txt"))
        {
            phone = new int[10];
            using (StreamReader sr = new StreamReader("contactActive.txt"))
            {
                sr.ReadLine(); //skip the first line
                number = sr.ReadLine(); //get the saved number
            }

            //figure out what contact is the active one for scorekeeping
            if (FileEquals("contactActive.txt", "contact1.txt"))
            {
                file = "contact1.txt";
            }
            else if (FileEquals("contactActive.txt", "contact2.txt"))
            {
                file = "contact2.txt";
            }
            else if (FileEquals("contactActive.txt", "contact3.txt"))
            {
                file = "contact3.txt";
            }
            else if (FileEquals("contactActive.txt", "contact4.txt"))
            {
                file = "contact4.txt";
            }

            for (int i = 0; i < 10; i++)
            {
                phone[i] = (int)System.Char.GetNumericValue(number[i]);
            }
        } else
        {
            phone = new int[] { 7, 7, 0, 9, 7, 3, 3, 7, 7, 1 }; //temp line with a hardcoded number in an array while we await contact functionality
        }

        buttons = this.GetComponentsInChildren<Button>(true); //Load buttons into array
        soundsTones = soundWrapperTones.GetComponentsInChildren<AudioSource>();
        soundsNotes = soundWrapperNotes.GetComponentsInChildren<AudioSource>();

        //store color values for later use
        
        cb = buttons[0].colors;
        ncb = cb;
        nc = new Color(255, 0, 255, 255);
        ncb.normalColor = nc;
        ncb.selectedColor = nc;
        ncb.highlightedColor = nc;

        //set time values
        lightbutton = 1;
        sequencedelay = 1;
        digits = 0;
    }

    void Update()
    {
        if (gamerunning == true)
        {
            //State Switch in game. 1 = Keeping button lit, 2 = Delight button and advance, 3 = Time between buttons, 4 = add next number and reset

            switch (state)
            {
                case 1:
                    lightbuttontime -= speedMult * Time.deltaTime;
                    if (lightbuttontime < 0)
                    {
                        state = 2;
                    }
                    break; 
                case 2:
                    buttons[sourceNum[position]].colors = cb;
                    sequencedelaytime = sequencedelay;
                    position++;
                    if (digits == position)
                    {
                        state = 1;
                        gamerunning = false;
                        freezeInput = false;
                        position = 0;
                        enteredNum.Clear();
                    }
                    else
                    {
                        state = 3;
                    }
                    break; 
                case 3:
                    sequencedelaytime -= speedMult * Time.deltaTime;
                    if (sequencedelaytime < 0)
                    {
                        state = 4;
                    }
                break;                
                case 4:
                    playSound(phone[position]);
                    sourceNum.Add(phone[position]);
                    buttons[sourceNum[position]].colors = ncb;
                    lightbuttontime = lightbutton;
                    state = 1;
                    break;
            }
        }
    }

   
    public void SimonSaysGame() // Starts a sequence in the game
    {
        if (gamerunning == false && digits < 10 && freezeInput == true && gameOver == false) 
        {
            sourceNum.Clear();
            digits++;
            gamerunning = true;
            position = 0;
            sourceNum.Add(phone[position]);
            buttons[sourceNum[position]].colors = ncb;
            lightbuttontime = lightbutton;
            messageText.text = "Watch The Pattern, Then Repeat It Back";
            playSound(sourceNum[position]);
        }
    }

    public void recieveNum(int n)
    {
        if (!freezeInput)
        {
            playSound(n);
            enteredNum.Add(n);
            if (sourceNum[position] == enteredNum[position])
            {
                updateHint(position);
                position++;
                messageText.text = "Thats Right, Keep Going!";
            }
            else
            {
                if (easyMode == true)
                {
                    messageText.text = "Sorry, that was incorrect. Try again!";
                    freezeInput = true;
                    digits--;
                    enteredNum.Clear();
                } else
                {
                    loseGame();
                }
            }

            if (enteredNum.Count == sourceNum.Count)
            {
                freezeInput = true;
                messageText.text = "Press The Button To Continue";
                if (digits == 10)
                {
                    winGame();
                }
            }
        } else
        {
            messageText.text = ("Please Wait For The Pattern To Finish");
        }     
    }

    void loseGame()
    {
        gameOver = true;
        failScreen.SetActive(true);
        loseSound.Play();

        //scorekeeping
        score = GetLine(file, line); //get the appropriate line, file is set in Start()
        scores = score.Split(' ');
        attempted = Int32.Parse(scores[0]);
        won = Int32.Parse(scores[1]);

        //increment scores appropriately
        attempted += 1;

        score = attempted + " " + won;

        ChangeLine(score, file, line); //rewrite to file
        ChangeLine(score, "contactActive.txt", line); //also rewrite to contactActive
    }

    void winGame ()
    {
        gameOver = true;
        winScreen.SetActive(true);
        winSound.Play();

        //scorekeeping
        score = GetLine(file, line); //get the appropriate line, file is set in Start()
        scores = score.Split(' ');
        attempted = Int32.Parse(scores[0]);
        won = Int32.Parse(scores[1]);

        //increment scores appropriately
        attempted += 1;
        won += 1;

        score = attempted + " " + won;

        ChangeLine(score, file, line); //rewrite to file
        ChangeLine(score, "contactActive.txt", line); //also rewrite to contactActive
    }

    void resetGame()
    {
        freezeInput = true;
        gameOver = false;
        gamerunning = false;
        state = 1;
        digits = 0;
        enteredNum.Clear();
    }

    void updateHint(int p)
    {
        int n = p + 1;
        string sourceString = hintText.text;
        StringBuilder newString = new StringBuilder(sourceString);
        if (p < 3)
        {
            newString[n * 2 - 2] = number[p];
        } else if (p < 6)
        {
            newString[n * 2] = number[p];
        } else
        {
            newString[n * 2 + 2] = number[p];
        }
        hintText.text = newString.ToString();
    } 

    void playSound (int a)
    {
        if (soundChoice == 1)
        {
            soundsNotes[a].Play();
        } else
        {
            soundsTones[a].Play();
        }
    }

    //returns specific line of file (for scorekeeping utility)
    string GetLine(string fileName, int line)
    {
        using (var sr = new StreamReader(fileName))
        {
            for (int i = 1; i < line; i++)
                sr.ReadLine();
            return sr.ReadLine();
        }
    }

    //edits specific line of file (for scorekeeping utility)
    static void ChangeLine(string newText, string fileName, int line_to_edit)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line_to_edit - 1] = newText;
        File.WriteAllLines(fileName, arrLine);
    }

    //compares two files (for scorekeeping utility)
    static bool FileEquals(string path1, string path2)
    {
        byte[] file1 = File.ReadAllBytes(path1);
        byte[] file2 = File.ReadAllBytes(path2);
        if (file1.Length == file2.Length)
        {
            for (int i = 0; i < file1.Length; i++)
            {
                if (file1[i] != file2[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}

