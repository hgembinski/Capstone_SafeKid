//Haiden Gembinski
//Statistics Scene Controller Script 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Statistics : MonoBehaviour
{
    public GameObject contact1, contact2, contact3, contact4;
    public GameObject showStatsScreen, fillInStatsScreen, simonStatsScreen, unscrambleStatsScreen, taxiStatsScreen, mailOutStatsScreen, soupStatsScreen, blocksStatsScreen;
    
    //main contacts display objects
    public Text displayName1, displayName2, displayName3, displayName4;
    public Text displayNumber1, displayNumber2, displayNumber3, displayNumber4;
    public Text displayAddress1, displayAddress2, displayAddress3, displayAddress4;

    //scores display objects
    public Text fillIn_level1_attempted, fillIn_level1_won, fillIn_level1_percent, fillIn_level2_attempted, fillIn_level2_won, fillIn_level2_percent,
        fillIn_level3_attempted, fillIn_level3_won, fillIn_level3_percent;
    public Text simon_attempted, simon_won, simon_percent;
    public Text unscramble_level1_attempted, unscramble_level1_won, unscramble_level1_percent, unscramble_level2_attempted, unscramble_level2_won, unscramble_level2_percent,
        unscramble_level3_attempted, unscramble_level3_won, unscramble_level3_percent;
    public Text taxi_level1_attempted, taxi_level1_won, taxi_level1_percent, taxi_level2_attempted, taxi_level2_won, taxi_level2_percent,
        taxi_level3_attempted, taxi_level3_won, taxi_level3_percent;
    public Text mailOut_level1_attempted, mailOut_level1_won, mailOut_level1_percent, mailOut_level2_attempted, mailOut_level2_won, mailOut_level2_percent,
        mailOut_level3_attempted, mailOut_level3_won, mailOut_level3_percent;
    public Text soup_level1_attempted, soup_level1_won, soup_level1_percent, soup_level2_attempted, soup_level2_won, soup_level2_percent,
        soup_level3_attempted, soup_level3_won, soup_level3_percent;
    public Text blocks_level1_attempted, blocks_level1_won, blocks_level1_percent, blocks_level2_attempted, blocks_level2_won, blocks_level2_percent,
        blocks_level3_attempted, blocks_level3_won, blocks_level3_percent;

    //contact info
    string name1, name2, name3, name4;
    string number1, number2, number3, number4;
    string street1, street2, street3, street4;
    string city1, city2, city3, city4;
    string state1, state2, state3, state4;
    string zip1, zip2, zip3, zip4;
    string[] fillIn1, fillIn2, fillIn3, simon, unscramble1, unscramble2, unscramble3, taxi1, taxi2, taxi3, mailOut1, mailOut2, mailOut3, soup1, soup2, soup3,
        blocks1, blocks2, blocks3;

    //score info
    List<string> contact1_scores = new List<string>(); //contact 1 scores
    List<string> contact2_scores = new List<string>(); //contact 2 scores
    List<string> contact3_scores = new List<string>(); //contact 3 scores
    List<string> contact4_scores = new List<string>(); //contact 4 scores

    /*
     List Info by Index:
     0 = Fill In Level 1
     1 = Fill In Level 2
     2 = Fill In Level 3
     3 = Simon
     4 = Unscramble Level 1
     5 = Unscramble Level 2
     6 = Unscramble Level 3
     7 = Taxi Level 1
     8 = Taxi Level 2
     9 = Taxi Level 3
     10 = Mail Out Level 1
     11 = Mail Out Level 2
     12 = Mail Out Level 3
     13 = Alphabet Soup Level 1
     14 = Alphabet Soup Level 2
     15 = Alphabet Soup Level 3
     16 = Blocks Level 1
     17 = Blocks Level 2
     18 = Blocks Level 3
     */

    // Start is called before the first frame update
    void Start()
    {
        //default display
        contact1.SetActive(false);
        contact2.SetActive(false);
        contact3.SetActive(false);
        contact4.SetActive(false);

        //get contact info if it exists
        if (File.Exists("contact1.txt"))
        {
            using (StreamReader sr = new StreamReader("contact1.txt"))
            {
                //get contact info
                name1 = sr.ReadLine();
                number1 = sr.ReadLine();
                street1 = sr.ReadLine();
                city1 = sr.ReadLine();
                state1 = sr.ReadLine();
                zip1 = sr.ReadLine();

                //get scores
                sr.ReadLine(); //fill in scores
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine(); //simon scores
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine(); //unscramble scores
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine(); //taxi scores
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine(); //mail Out scores
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine(); //alphabet soup scores
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine(); //blocks scores
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact1_scores.Add(sr.ReadLine());

            }
            
            //display info
            displayName1.text = name1;
            displayNumber1.text = "(" + number1[0] + number1[1] + number1[2] + ") " + number1[3] + number1[4] + number1[5] + " - "
                + number1[6] + number1[7] + number1[8] + number1[9];
            displayAddress1.text = street1 + "\n" + city1 + ", " + state1 + " " + zip1;

            contact1.SetActive(true);
        }

        if (File.Exists("contact2.txt"))
        {
            using (StreamReader sr = new StreamReader("contact2.txt"))
            {
                //get contact info
                name2 = sr.ReadLine();
                number2 = sr.ReadLine();
                street2 = sr.ReadLine();
                city2 = sr.ReadLine();
                state2 = sr.ReadLine();
                zip2 = sr.ReadLine();

                //get scores
                sr.ReadLine(); //fill in scores
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine(); //simon scores
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine(); //unscramble scores
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine(); //taxi scores
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine(); //mail Out scores
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine(); //alphabet soup scores
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine(); //blocks scores
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact2_scores.Add(sr.ReadLine());

            }

            //display info
            displayName2.text = name2;
            displayNumber2.text = "(" + number2[0] + number2[1] + number2[2] + ") " + number2[3] + number2[4] + number2[5] + " - "
                + number2[6] + number2[7] + number2[8] + number2[9];
            displayAddress2.text = street2 + "\n" + city2 + ", " + state2 + " " + zip2;

            contact2.SetActive(true);
        }

        if (File.Exists("contact3.txt"))
        {
            using (StreamReader sr = new StreamReader("contact3.txt"))
            {
                //get contact info
                name3 = sr.ReadLine();
                number3 = sr.ReadLine();
                street3 = sr.ReadLine();
                city3 = sr.ReadLine();
                state3 = sr.ReadLine();
                zip3 = sr.ReadLine();

                //get scores
                sr.ReadLine(); //fill in scores
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine(); //simon scores
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine(); //unscramble scores
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine(); //taxi scores
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine(); //mail Out scores
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine(); //alphabet soup scores
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine(); //blocks scores
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact3_scores.Add(sr.ReadLine());

            }

            //display info
            displayName3.text = name3;
            displayNumber3.text = "(" + number3[0] + number3[1] + number3[2] + ") " + number3[3] + number3[4] + number3[5] + " - "
                + number3[6] + number3[7] + number3[8] + number3[9];
            displayAddress3.text = street3 + "\n" + city3 + ", " + state3 + " " + zip3;

            contact3.SetActive(true);
        }

        if (File.Exists("contact4.txt"))
        {
            using (StreamReader sr = new StreamReader("contact4.txt"))
            {
                //get contact info
                name4 = sr.ReadLine();
                number4 = sr.ReadLine();
                street4 = sr.ReadLine();
                city4 = sr.ReadLine();
                state4 = sr.ReadLine();
                zip4 = sr.ReadLine();

                //get scores
                sr.ReadLine(); //fill in scores
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine(); //simon scores
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine(); //unscramble scores
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine(); //taxi scores
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine(); //mail Out scores
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine(); //alphabet soup scores
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine(); //blocks scores
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());
                sr.ReadLine();
                contact4_scores.Add(sr.ReadLine());

            }

            //display info
            displayName4.text = name4;
            displayNumber4.text = "(" + number4[0] + number4[1] + number4[2] + ") " + number4[3] + number4[4] + number4[5] + " - "
                + number4[6] + number4[7] + number4[8] + number4[9];
            displayAddress4.text = street4 + "\n" + city4 + ", " + state4 + " " + zip4;

            contact4.SetActive(true);
        }
    }

    //buttons
    public void Contact1_ViewStatsButton()
    {
        showStatsScreen.SetActive(true);
        //get stats from list
        fillIn1 = contact1_scores[0].Split(' ');
        fillIn2 = contact1_scores[1].Split(' ');
        fillIn3 = contact1_scores[2].Split(' ');
        simon = contact1_scores[3].Split(' ');
        unscramble1 = contact1_scores[4].Split(' ');
        unscramble2 = contact1_scores[5].Split(' ');
        unscramble3 = contact1_scores[6].Split(' ');
        taxi1 = contact1_scores[7].Split(' ');
        taxi2 = contact1_scores[8].Split(' ');
        taxi3 = contact1_scores[9].Split(' ');
        mailOut1 = contact1_scores[10].Split(' ');
        mailOut2 = contact1_scores[11].Split(' ');
        mailOut3 = contact1_scores[12].Split(' ');
        soup1 = contact1_scores[13].Split(' ');
        soup2 = contact1_scores[14].Split(' ');
        soup3 = contact1_scores[15].Split(' ');
        blocks1 = contact1_scores[16].Split(' ');
        blocks2 = contact1_scores[17].Split(' ');
        blocks3 = contact1_scores[18].Split(' ');

        DisplayStats(); //update the stats displays
    }

    public void Contact2_ViewStatsButton()
    {
        showStatsScreen.SetActive(true);
        //get stats from list
        fillIn1 = contact2_scores[0].Split(' ');
        fillIn2 = contact2_scores[1].Split(' ');
        fillIn3 = contact2_scores[2].Split(' ');
        simon = contact2_scores[3].Split(' ');
        unscramble1 = contact2_scores[4].Split(' ');
        unscramble2 = contact2_scores[5].Split(' ');
        unscramble3 = contact2_scores[6].Split(' ');
        taxi1 = contact2_scores[7].Split(' ');
        taxi2 = contact2_scores[8].Split(' ');
        taxi3 = contact2_scores[9].Split(' ');
        mailOut1 = contact2_scores[10].Split(' ');
        mailOut2 = contact2_scores[11].Split(' ');
        mailOut3 = contact2_scores[12].Split(' ');
        soup1 = contact2_scores[13].Split(' ');
        soup2 = contact2_scores[14].Split(' ');
        soup3 = contact2_scores[15].Split(' ');
        blocks1 = contact2_scores[16].Split(' ');
        blocks2 = contact2_scores[17].Split(' ');
        blocks3 = contact2_scores[18].Split(' ');

        DisplayStats(); //update the stats displays
    }

    public void Contact3_ViewStatsButton()
    {
        showStatsScreen.SetActive(true);
        //get stats from list
        fillIn1 = contact3_scores[0].Split(' ');
        fillIn2 = contact3_scores[1].Split(' ');
        fillIn3 = contact3_scores[2].Split(' ');
        simon = contact3_scores[3].Split(' ');
        unscramble1 = contact3_scores[4].Split(' ');
        unscramble2 = contact3_scores[5].Split(' ');
        unscramble3 = contact3_scores[6].Split(' ');
        taxi1 = contact3_scores[7].Split(' ');
        taxi2 = contact3_scores[8].Split(' ');
        taxi3 = contact3_scores[9].Split(' ');
        mailOut1 = contact3_scores[10].Split(' ');
        mailOut2 = contact3_scores[11].Split(' ');
        mailOut3 = contact3_scores[12].Split(' ');
        soup1 = contact3_scores[13].Split(' ');
        soup2 = contact3_scores[14].Split(' ');
        soup3 = contact3_scores[15].Split(' ');
        blocks1 = contact3_scores[16].Split(' ');
        blocks2 = contact3_scores[17].Split(' ');
        blocks3 = contact3_scores[18].Split(' ');

        DisplayStats(); //update the stats displays
    }

    public void Contact4_ViewStatsButton()
    {
        showStatsScreen.SetActive(true);
        //get stats from list
        fillIn1 = contact4_scores[0].Split(' ');
        fillIn2 = contact4_scores[1].Split(' ');
        fillIn3 = contact4_scores[2].Split(' ');
        simon = contact4_scores[3].Split(' ');
        unscramble1 = contact4_scores[4].Split(' ');
        unscramble2 = contact4_scores[5].Split(' ');
        unscramble3 = contact4_scores[6].Split(' ');
        taxi1 = contact4_scores[7].Split(' ');
        taxi2 = contact4_scores[8].Split(' ');
        taxi3 = contact4_scores[9].Split(' ');
        mailOut1 = contact4_scores[10].Split(' ');
        mailOut2 = contact4_scores[11].Split(' ');
        mailOut3 = contact4_scores[12].Split(' ');
        soup1 = contact4_scores[13].Split(' ');
        soup2 = contact4_scores[14].Split(' ');
        soup3 = contact4_scores[15].Split(' ');
        blocks1 = contact4_scores[16].Split(' ');
        blocks2 = contact4_scores[17].Split(' ');
        blocks3 = contact4_scores[18].Split(' ');

        DisplayStats(); //update the stats displays
    }

    public void fillInStatsButton()
    {
        fillInStatsScreen.SetActive(true);
    }

    public void SimonStatsButton()
    {
        simonStatsScreen.SetActive(true);
    }

    public void UnscrambleStatsButton()
    {
        unscrambleStatsScreen.SetActive(true);
    }

    public void TaxiStatsButton()
    {
        taxiStatsScreen.SetActive(true);
    }

    public void MailOutStatsButton()
    {
        mailOutStatsScreen.SetActive(true);
    }

    public void SoupStatsButton()
    {
        soupStatsScreen.SetActive(true);
    }

    public void BlocksStatsButton()
    {
        blocksStatsScreen.SetActive(true);
    }

    void DisplayStats() //updates all of the stats displays with the currently selected contact's scores
    {
        //display stats
        //Fill In Scores
        if (Int32.Parse(fillIn1[0]) > 0)
        {
            fillIn_level1_attempted.text = "Attempted: " + fillIn1[0];
            fillIn_level1_won.text = "Won: " + fillIn1[1];
            fillIn_level1_percent.text = "Percent: " + (Math.Round((float.Parse(fillIn1[1]) / float.Parse(fillIn1[0])), 4) * 100) + "%";
        }
        else
        {
            fillIn_level1_attempted.text = "Attempted: -";
            fillIn_level1_won.text = "Won: -";
            fillIn_level1_percent.text = "Percent: -";
        }
        if (Int32.Parse(fillIn2[0]) > 0)
        {
            fillIn_level2_attempted.text = "Attempted: " + fillIn2[0];
            fillIn_level2_won.text = "Won: " + fillIn2[1];
            fillIn_level2_percent.text = "Percent: " + (Math.Round((float.Parse(fillIn2[1]) / float.Parse(fillIn2[0])), 4) * 100) + "%";
        }
        else
        {
            fillIn_level2_attempted.text = "Attempted: -";
            fillIn_level2_won.text = "Won: -";
            fillIn_level2_percent.text = "Percent: -";
        }
        if (Int32.Parse(fillIn3[0]) > 0)
        {
            fillIn_level3_attempted.text = "Attempted: " + fillIn3[0];
            fillIn_level3_won.text = "Won: " + fillIn3[1];
            fillIn_level3_percent.text = "Percent: " + (Math.Round((float.Parse(fillIn3[1]) / float.Parse(fillIn3[0])), 4) * 100) + "%";
        }
        else
        {
            fillIn_level3_attempted.text = "Attempted: -";
            fillIn_level3_won.text = "Won: -";
            fillIn_level3_percent.text = "Percent: -";
        }
        //Simon Score
        if (Int32.Parse(simon[0]) > 0)
        {
            simon_attempted.text = "Attempted: " + simon[0];
            simon_won.text = "Won: " + simon[1];
            simon_percent.text = "Percent: " + (Math.Round((float.Parse(simon[1]) / float.Parse(simon[0])), 4) * 100) + "%";
        }
        else
        {
            simon_attempted.text = "Attempted: -";
            simon_won.text = "Won: -";
            simon_percent.text = "Percent: -";
        }
        //Unscramble Scores
        if (Int32.Parse(unscramble1[0]) > 0)
        {
            unscramble_level1_attempted.text = "Attempted: " + unscramble1[0];
            unscramble_level1_won.text = "Won: " + unscramble1[1];
            unscramble_level1_percent.text = "Percent: " + (Math.Round((float.Parse(unscramble1[1]) / float.Parse(unscramble1[0])), 4) * 100) + "%";
        }
        else
        {
            unscramble_level1_attempted.text = "Attempted: -";
            unscramble_level1_won.text = "Won:-";
            unscramble_level1_percent.text = "Percent: -";
        }
        if (Int32.Parse(unscramble2[0]) > 0)
        {
            unscramble_level2_attempted.text = "Attempted: " + unscramble2[0];
            unscramble_level2_won.text = "Won: " + unscramble2[1];
            unscramble_level2_percent.text = "Percent: " + (Math.Round((float.Parse(unscramble2[1]) / float.Parse(unscramble2[0])), 4) * 100) + "%";
        }
        else
        {
            unscramble_level2_attempted.text = "Attempted: -";
            unscramble_level2_won.text = "Won: -";
            unscramble_level2_percent.text = "Percent: -";
        }
        if (Int32.Parse(unscramble3[0]) > 0)
        {
            unscramble_level3_attempted.text = "Attempted: " + unscramble3[0];
            unscramble_level3_won.text = "Won: " + unscramble3[1];
            unscramble_level3_percent.text = "Percent: " + (Math.Round((float.Parse(unscramble3[1]) / float.Parse(unscramble3[0])), 4) * 100) + "%";
        }
        else
        {
            unscramble_level3_attempted.text = "Attempted: -";
            unscramble_level3_won.text = "Won:  -";
            unscramble_level3_percent.text = "Percent:  -";
        }
        //Taxi Scores
        if (Int32.Parse(taxi1[0]) > 0)
        {
            taxi_level1_attempted.text = "Attempted: " + taxi1[0];
            taxi_level1_won.text = "Won: " + taxi1[1];
            taxi_level1_percent.text = "Percent: " + (Math.Round((float.Parse(taxi1[1]) / float.Parse(taxi1[0])), 4) * 100) + "%";
        }
        else
        {
            taxi_level1_attempted.text = "Attempted: -";
            taxi_level1_won.text = "Won: -";
            taxi_level1_percent.text = "Percent: -";
        }
        if (Int32.Parse(taxi2[0]) > 0)
        {
            taxi_level2_attempted.text = "Attempted: " + taxi2[0];
            taxi_level2_won.text = "Won: " + taxi2[1];
            taxi_level2_percent.text = "Percent: " + (Math.Round((float.Parse(taxi2[1]) / float.Parse(taxi2[0])), 4) * 100) + "%";
        }
        else
        {
            taxi_level2_attempted.text = "Attempted: -";
            taxi_level2_won.text = "Won: -";
            taxi_level2_percent.text = "Percent: -";
        }
        if (Int32.Parse(taxi3[0]) > 0)
        {
            taxi_level3_attempted.text = "Attempted: " + taxi3[0];
            taxi_level3_won.text = "Won: " + taxi3[1];
            taxi_level3_percent.text = "Percent: " + (Math.Round((float.Parse(taxi3[1]) / float.Parse(taxi3[0])), 4) * 100) + "%";
        }
        else
        {
            taxi_level3_attempted.text = "Attempted: -";
            taxi_level3_won.text = "Won: -";
            taxi_level3_percent.text = "Percent: -";
        }
        //Mail Out Scores
        if (Int32.Parse(mailOut1[0]) > 0)
        {
            mailOut_level1_attempted.text = "Attempted: " + mailOut1[0];
            mailOut_level1_won.text = "Won: " + mailOut1[1];
            mailOut_level1_percent.text = "Percent: " + (Math.Round((float.Parse(mailOut1[1]) / float.Parse(mailOut1[0])), 4) * 100) + "%";
        }
        else
        {
            mailOut_level1_attempted.text = "Attempted: -";
            mailOut_level1_won.text = "Won: -";
            mailOut_level1_percent.text = "Percent: -";
        }
        if (Int32.Parse(mailOut2[0]) > 0)
        {
            mailOut_level2_attempted.text = "Attempted: " + mailOut2[0];
            mailOut_level2_won.text = "Won: " + mailOut2[1];
            mailOut_level2_percent.text = "Percent: " + (Math.Round((float.Parse(mailOut2[1]) / float.Parse(mailOut2[0])), 4) * 100) + "%";
        }
        else
        {
            mailOut_level2_attempted.text = "Attempted: -";
            mailOut_level2_won.text = "Won: -";
            mailOut_level2_percent.text = "Percent: -";
        }
        if (Int32.Parse(mailOut3[0]) > 0)
        {
            mailOut_level3_attempted.text = "Attempted: " + mailOut3[0];
            mailOut_level3_won.text = "Won: " + mailOut3[1];
            mailOut_level3_percent.text = "Percent: " + (Math.Round((float.Parse(mailOut3[1]) / float.Parse(mailOut3[0])), 4) * 100) + "%";
        }
        else
        {
            mailOut_level3_attempted.text = "Attempted: -";
            mailOut_level3_won.text = "Won: -";
            mailOut_level3_percent.text = "Percent: -";
        }
        //Alphabet Soup Scores
        if (Int32.Parse(soup1[0]) > 0)
        {
            soup_level1_attempted.text = "Attempted: " + soup1[0];
            soup_level1_won.text = "Won: " + soup1[1];
            soup_level1_percent.text = "Percent: " + (Math.Round((float.Parse(soup1[1]) / float.Parse(soup1[0])), 4) * 100) + "%";
        }
        else
        {
            soup_level1_attempted.text = "Attempted: -";
            soup_level1_won.text = "Won: -";
            soup_level1_percent.text = "Percent: -";
        }
        if (Int32.Parse(soup2[0]) > 0)
        {
            soup_level2_attempted.text = "Attempted: " + soup2[0];
            soup_level2_won.text = "Won: " + soup2[1];
            soup_level2_percent.text = "Percent: " + (Math.Round((float.Parse(soup2[1]) / float.Parse(soup2[0])), 4) * 100) + "%";
        }
        else
        {
            soup_level2_attempted.text = "Attempted: -";
            soup_level2_won.text = "Won: -";
            soup_level2_percent.text = "Percent: -";
        }
        if (Int32.Parse(soup3[0]) > 0)
        {
            soup_level3_attempted.text = "Attempted: " + soup3[0];
            soup_level3_won.text = "Won: " + soup3[1];
            soup_level3_percent.text = "Percent: " + (Math.Round((float.Parse(soup3[1]) / float.Parse(soup3[0])), 4) * 100) + "%";
        }
        else
        {
            soup_level3_attempted.text = "Attempted: -";
            soup_level3_won.text = "Won: -";
            soup_level3_percent.text = "Percent: -";
        }
        //Blocks Scores
        if (Int32.Parse(blocks1[0]) > 0)
        {
            blocks_level1_attempted.text = "Attempted: " + blocks1[0];
            blocks_level1_won.text = "Won: " + blocks1[1];
            blocks_level1_percent.text = "Percent: " + (Math.Round((float.Parse(blocks1[1]) / float.Parse(blocks1[0])), 4) * 100) + "%";
        }
        else
        {
            blocks_level1_attempted.text = "Attempted: -";
            blocks_level1_won.text = "Won: -";
            blocks_level1_percent.text = "Percent: -";
        }
        if (Int32.Parse(blocks2[0]) > 0)
        {
            blocks_level2_attempted.text = "Attempted: " + blocks2[0];
            blocks_level2_won.text = "Won: " + blocks2[1];
            blocks_level2_percent.text = "Percent: " + (Math.Round((float.Parse(blocks2[1]) / float.Parse(blocks2[0])), 4) * 100) + "%";
        }
        else
        {
            blocks_level2_attempted.text = "Attempted: -";
            blocks_level2_won.text = "Won: -";
            blocks_level2_percent.text = "Percent: -";
        }
        if (Int32.Parse(blocks3[0]) > 0)
        {
            blocks_level3_attempted.text = "Attempted: " + blocks3[0];
            blocks_level3_won.text = "Won: " + blocks3[1];
            blocks_level3_percent.text = "Percent: " + (Math.Round((float.Parse(blocks3[1]) / float.Parse(blocks3[0])), 4) * 100) + "%";
        }
        else
        {
            blocks_level3_attempted.text = "Attempted: -";
            blocks_level3_won.text = "Won: -";
            blocks_level3_percent.text = "Percent: -";
        }
    }
}
