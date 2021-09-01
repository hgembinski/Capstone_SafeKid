//Haiden Gembinski
//Contacts Scene Controller Script

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class Contacts : MonoBehaviour
{
    public GameObject contact1, contact2, contact3, contact4; //contact displays
    public GameObject inactive1, inactive2, inactive3, inactive4; //inactive fades for nonselected contacts
    public GameObject activeIcon1, activeIcon2, activeIcon3, activeIcon4; //active icons for showing selected contact
    public GameObject contactSelectButton1, contactSelectButton2, contactSelectButton3, contactSelectButton4; //select buttons
    public GameObject addContactButton1, addContactButton2, addContactButton3, addContactButton4;
    public GameObject addContact1, addContact2, addContact3, addContact4; //add contact screens
    public GameObject editContact1, editContact2, editContact3, editContact4; //edit contact screens
    public GameObject deleteContactConfirm1, deleteContactConfirm2, deleteContactConfirm3, deleteContactConfirm4; //delete confirmation screens
    public GameObject resetStatsConfirm1, resetStatsConfirm2, resetStatsConfirm3, resetStatsConfirm4; //reset stats confirmation screens
    public GameObject errorScreen; //error screen
    public Text errorText; //error display text

    string savedName1, savedName2, savedName3, savedName4;
    string savedNumber1, savedNumber2, savedNumber3, savedNumber4;
    string savedStreet1, savedStreet2, savedStreet3, savedStreet4;
    string savedCity1, savedCity2, savedCity3, savedCity4;
    string savedState1, savedState2, savedState3, savedState4;
    string savedZip1, savedZip2, savedZip3, savedZip4;
    string file;
    int activeContact = 0;



    // Start is called before the first frame update
    void Start()
    {
        //default display
        contact1.SetActive(false);
        addContactButton1.SetActive(true);

        contact2.SetActive(false);
        addContactButton2.SetActive(false);

        contact3.SetActive(false);
        addContactButton3.SetActive(false);

        contact4.SetActive(false);
        addContactButton4.SetActive(true);

        //check for existing active contact
        if (File.Exists("contact1.txt") && File.Exists("contactActive.txt"))
        {
            if (FileEquals("contactActive.txt", "contact1.txt"))
            {
                activeContact = 1;
            }
        }

        if (File.Exists("contact2.txt") && File.Exists("contactActive.txt"))
        {
            if (FileEquals("contactActive.txt", "contact2.txt"))
            {
                activeContact = 2;
            }
        }

        if (File.Exists("contact3.txt") && File.Exists("contactActive.txt"))
        {
            if (FileEquals("contactActive.txt", "contact3.txt"))
            {
                activeContact = 3;
            }
        }

        if (File.Exists("contact4.txt") && File.Exists("contactActive.txt"))
        {
            if (FileEquals("contactActive.txt", "contact4.txt"))
            {
                activeContact = 4;
            }
        }

        if (activeContact == 0 && File.Exists("contactActive.txt")) //if a current active contact exists but doesn't match any existing ones, delete it
        {
            File.Delete("contactActive.txt");
        }
    }

    // Update is called once per frame
    void Update()
    {

        //display accordingly if contacts exist
        //contact 1
        if (File.Exists("contact1.txt"))
        {
            using (StreamReader sr = new StreamReader("contact1.txt"))
            {
                savedName1 = sr.ReadLine();
                savedNumber1 = sr.ReadLine();
                savedStreet1 = sr.ReadLine();
                savedCity1 = sr.ReadLine();
                savedState1 = sr.ReadLine();
                savedZip1 = sr.ReadLine();
            }

            contact1.SetActive(true);
            addContactButton1.SetActive(false);

            //display name
            GameObject name1 = GameObject.Find("Name1");
            name1.GetComponent<Text>().text = savedName1;

            //display number
            GameObject number1 = GameObject.Find("Number1");
            number1.GetComponent<Text>().text = "(" + savedNumber1[0] + savedNumber1[1] + savedNumber1[2] + ") " + savedNumber1[3] + savedNumber1[4] + savedNumber1[5] + " - "
                + savedNumber1[6] + savedNumber1[7] + savedNumber1[8] + savedNumber1[9];

            //display address
            GameObject address1 = GameObject.Find("Address1");
            address1.GetComponent<Text>().text = savedStreet1 + "\n" + savedCity1 + ", " + savedState1 + " " + savedZip1;
        }

        else
        {
            contact1.SetActive(false);
            addContactButton1.SetActive(true);
        }

        //contact 2
        if (File.Exists("contact2.txt"))
        {
            if (!File.Exists("contact1.txt")) //if the previous contact doesn't exist, copy this one to the first slot
            {
                CopyFile("contact2.txt", "contact1.txt");
                if (activeContact == 2) //if this is currently the active file, track it appropriately
                {
                    activeContact = 1;
                }
                File.Delete("contact2.txt"); //after copying, delete this one to avoid duplicates
            }

            else
            {
                using (StreamReader sr = new StreamReader("contact2.txt"))
                {
                    savedName2 = sr.ReadLine();
                    savedNumber2 = sr.ReadLine();
                    savedStreet2 = sr.ReadLine();
                    savedCity2 = sr.ReadLine();
                    savedState2 = sr.ReadLine();
                    savedZip2 = sr.ReadLine();
                }

                contact2.SetActive(true);
                addContactButton2.SetActive(false);

                //display name
                GameObject name2 = GameObject.Find("Name2");
                name2.GetComponent<Text>().text = savedName2;

                //display number
                GameObject number2 = GameObject.Find("Number2");
                number2.GetComponent<Text>().text = "(" + savedNumber2[0] + savedNumber2[1] + savedNumber2[2] + ") " + savedNumber2[3] + savedNumber2[4] + savedNumber2[5] + " - "
                    + savedNumber2[6] + savedNumber2[7] + savedNumber2[8] + savedNumber2[9];

                //display address
                GameObject address2 = GameObject.Find("Address2");
                address2.GetComponent<Text>().text = savedStreet2 + "\n" + savedCity2 + ", " + savedState2 + " " + savedZip2;
            }
        }

        else
        {
            contact2.SetActive(false);
            addContactButton2.SetActive(true);
        }

        //contact 3
        if (File.Exists("contact3.txt"))
        {
            if (!File.Exists("contact2.txt")) //if the previous contact doesn't exist, copy this one to the previous slot
            {
                CopyFile("contact3.txt", "contact2.txt");
                if (activeContact == 3) //if this is currently the active file, track it appropriately
                {
                    activeContact = 2;
                }
                File.Delete("contact3.txt"); //after copying, delete this one to avoid duplicates
            }

            else
            {
                using (StreamReader sr = new StreamReader("contact3.txt"))
                {
                    savedName3 = sr.ReadLine();
                    savedNumber3 = sr.ReadLine();
                    savedStreet3 = sr.ReadLine();
                    savedCity3 = sr.ReadLine();
                    savedState3 = sr.ReadLine();
                    savedZip3 = sr.ReadLine();
                }

                contact3.SetActive(true);
                addContactButton3.SetActive(false);

                //display name
                GameObject name3 = GameObject.Find("Name3");
                name3.GetComponent<Text>().text = savedName3;

                //display number
                GameObject number3 = GameObject.Find("Number3");
                number3.GetComponent<Text>().text = "(" + savedNumber3[0] + savedNumber3[1] + savedNumber3[2] + ") " + savedNumber3[3] + savedNumber3[4] + savedNumber3[5] + " - "
                    + savedNumber3[6] + savedNumber3[7] + savedNumber3[8] + savedNumber3[9];

                //display address
                GameObject address3 = GameObject.Find("Address3");
                address3.GetComponent<Text>().text = savedStreet3 + "\n" + savedCity3 + ", " + savedState3 + " " + savedZip3;
            }
        }

        else
        {
            contact3.SetActive(false);
            addContactButton3.SetActive(true);
        }

        //contact 4
        if (File.Exists("contact4.txt"))
        {
            if (!File.Exists("contact3.txt")) //if the previous contact doesn't exist, copy this one to the previous slot
            {
                CopyFile("contact4.txt", "contact3.txt");
                if (activeContact == 4) //if this is currently the active file, track it appropriately
                {
                    activeContact = 3;
                }
                File.Delete("contact4.txt"); //after copying, delete this one to avoid duplicates
            }
            else
            {
                using (StreamReader sr = new StreamReader("contact4.txt"))
                {
                    savedName4 = sr.ReadLine();
                    savedNumber4 = sr.ReadLine();
                    savedStreet4 = sr.ReadLine();
                    savedCity4 = sr.ReadLine();
                    savedState4 = sr.ReadLine();
                    savedZip4 = sr.ReadLine();
                }

                contact4.SetActive(true);
                addContactButton4.SetActive(false);

                //display name
                GameObject name4 = GameObject.Find("Name4");
                name4.GetComponent<Text>().text = savedName4;

                //display number
                GameObject number4 = GameObject.Find("Number4");
                number4.GetComponent<Text>().text = "(" + savedNumber4[0] + savedNumber4[1] + savedNumber4[2] + ") " + savedNumber4[3] + savedNumber4[4] + savedNumber4[5] + " - "
                    + savedNumber4[6] + savedNumber4[7] + savedNumber4[8] + savedNumber4[9];

                //display address
                GameObject address4 = GameObject.Find("Address4");
                address4.GetComponent<Text>().text = savedStreet4 + "\n" + savedCity4 + ", " + savedState4 + " " + savedZip4;
            }
        }

        else
        {
            contact4.SetActive(false);
            addContactButton4.SetActive(true);
        }

        //active buttons
        if (addContactButton1.activeInHierarchy == true)
        {
            addContactButton2.SetActive(false);
            addContactButton3.SetActive(false);
            addContactButton4.SetActive(false);
        }
        if (addContactButton2.activeInHierarchy == true)
        {
            addContactButton3.SetActive(false);
            addContactButton4.SetActive(false);
        }
        if (addContactButton3.activeInHierarchy == true)
        {
            addContactButton4.SetActive(false);
        }

        //GUI display for currently selected contact
        switch (activeContact)
        {
            case 0: //if no active contact
                //inactive fades
                inactive1.SetActive(true);
                inactive2.SetActive(true);
                inactive3.SetActive(true);
                inactive4.SetActive(true);

                //"selected" icons
                activeIcon1.SetActive(false);
                activeIcon2.SetActive(false);
                activeIcon3.SetActive(false);
                activeIcon4.SetActive(false);

                //select buttons
                contactSelectButton1.SetActive(true);
                contactSelectButton2.SetActive(true);
                contactSelectButton3.SetActive(true);
                contactSelectButton4.SetActive(true);
                break;

            case 1:
                inactive1.SetActive(false);
                inactive2.SetActive(true);
                inactive3.SetActive(true);
                inactive4.SetActive(true);

                activeIcon1.SetActive(true);
                activeIcon2.SetActive(false);
                activeIcon3.SetActive(false);
                activeIcon4.SetActive(false);

                contactSelectButton1.SetActive(false);
                contactSelectButton2.SetActive(true);
                contactSelectButton3.SetActive(true);
                contactSelectButton4.SetActive(true);
                break;

            case 2:
                inactive1.SetActive(true);
                inactive2.SetActive(false);
                inactive3.SetActive(true);
                inactive4.SetActive(true);

                activeIcon1.SetActive(false);
                activeIcon2.SetActive(true);
                activeIcon3.SetActive(false);
                activeIcon4.SetActive(false);

                contactSelectButton1.SetActive(true);
                contactSelectButton2.SetActive(false);
                contactSelectButton3.SetActive(true);
                contactSelectButton4.SetActive(true);
                break;

            case 3:
                inactive1.SetActive(true);
                inactive2.SetActive(true);
                inactive3.SetActive(false);
                inactive4.SetActive(true);

                activeIcon1.SetActive(false);
                activeIcon2.SetActive(false);
                activeIcon3.SetActive(true);
                activeIcon4.SetActive(false);

                contactSelectButton1.SetActive(true);
                contactSelectButton2.SetActive(true);
                contactSelectButton3.SetActive(false);
                contactSelectButton4.SetActive(true);
                break;

            case 4:
                inactive1.SetActive(true);
                inactive2.SetActive(true);
                inactive3.SetActive(true);
                inactive4.SetActive(false);

                activeIcon1.SetActive(false);
                activeIcon2.SetActive(false);
                activeIcon3.SetActive(false);
                activeIcon4.SetActive(true);

                contactSelectButton1.SetActive(true);
                contactSelectButton2.SetActive(true);
                contactSelectButton3.SetActive(true);
                contactSelectButton4.SetActive(false);
                break;
        }
    }


    //buttons
    public void ShowAddContact1()
    {
        addContact1.SetActive(true);

    }

    public void ShowAddContact2()
    {
        addContact2.SetActive(true);
    }

    public void ShowAddContact3()
    {
        addContact3.SetActive(true);
    }

    public void ShowAddContact4()
    {
        addContact4.SetActive(true);
    }

    public void ShowEditContact1()
    {
        editContact1.SetActive(true);
    }

    public void ShowEditContact2()
    {
        editContact2.SetActive(true);
    }

    public void ShowEditContact3()
    {
        editContact3.SetActive(true);
    }

    public void ShowEditContact4()
    {
        editContact4.SetActive(true);
    }

    public void ShowDeleteConfirm1()
    {
        deleteContactConfirm1.SetActive(true);
    }

    public void ShowDeleteConfirm2()
    {
        deleteContactConfirm2.SetActive(true);
    }

    public void ShowDeleteConfirm3()
    {
        deleteContactConfirm3.SetActive(true);
    }

    public void ShowDeleteConfirm4()
    {
        deleteContactConfirm4.SetActive(true);
    }


    public void SelectContact1()
    {
        //copy to contactActive.txt
        CopyFile("contact1.txt", "contactActive.txt");

        activeContact = 1; //track active contact
    }

    public void SelectContact2()
    {
        //copy to contactActive.txt
        CopyFile("contact2.txt", "contactActive.txt");

        activeContact = 2; //track active contact
    }

    public void SelectContact3()
    {
        //copy to contactActive.txt
        CopyFile("contact3.txt", "contactActive.txt");

        activeContact = 3; //track active contact
    }

    public void SelectContact4()
    {
        //copy to contactActive.txt
        CopyFile("contact4.txt", "contactActive.txt");

        activeContact = 4; //track active contact
    }

    public void AddContact1()
    {
        //get info from input fields
        InputField nameInput = GameObject.Find("NameInput1").GetComponent<InputField>();
        InputField numberInput = GameObject.Find("NumberInput1").GetComponent<InputField>();
        InputField streetInput = GameObject.Find("StreetInput1").GetComponent<InputField>();
        InputField cityInput = GameObject.Find("CityInput1").GetComponent<InputField>();
        InputField stateInput = GameObject.Find("StateInput1").GetComponent<InputField>();
        InputField zipInput = GameObject.Find("ZipInput1").GetComponent<InputField>();

        string name = nameInput.text.ToString();
        string number = numberInput.text.ToString();
        string street = streetInput.text.ToString();
        string city = cityInput.text.ToString();
        string state = stateInput.text.ToString();
        string zip = zipInput.text.ToString();

        //if validity checks passed, write to file
        if (CheckNull(name) && CheckNameFirstChar(name) && CheckNumber(number) && CheckNull(street) && CheckStreetLength(street) && CheckNull(city) && CheckNull(state)
                     && CheckNull(zip))
        {
            file = "contact1.txt";
            PrintContact(file, name, number, street, city, state, zip);

            addContact1.SetActive(false); //close addContact screen
        }

        else //display appropriate error
        {
            if (!CheckNull(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid name.";
            }

            else if (!CheckNameFirstChar(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Name cannot begin with a space, please enter a valid name.";
            }

            else if (!CheckNull(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNumber(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNull(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid street.";
            }

            else if (!CheckStreetLength(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Street is too long. Street must be comprised of eight seperate words/numbers or less.";
            }

            else if (!CheckNull(city))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid city.";
            }

            else if (!CheckNull(state))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid state.";
            }

            else if (!CheckNull(zip))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid zip code.";
            }
        }

    }

    public void AddContact2()
    {
        //get info from input fields
        InputField nameInput = GameObject.Find("NameInput2").GetComponent<InputField>();
        InputField numberInput = GameObject.Find("NumberInput2").GetComponent<InputField>();
        InputField streetInput = GameObject.Find("StreetInput2").GetComponent<InputField>();
        InputField cityInput = GameObject.Find("CityInput2").GetComponent<InputField>();
        InputField stateInput = GameObject.Find("StateInput2").GetComponent<InputField>();
        InputField zipInput = GameObject.Find("ZipInput2").GetComponent<InputField>();

        string name = nameInput.text.ToString();
        string number = numberInput.text.ToString();
        string street = streetInput.text.ToString();
        string city = cityInput.text.ToString();
        string state = stateInput.text.ToString();
        string zip = zipInput.text.ToString();

        //if validity checks passed, write to file
        if (CheckNull(name) && CheckNameFirstChar(name) && CheckNumber(number) && CheckNull(street) && CheckStreetLength(street) && CheckNull(city) && CheckNull(state)
                     && CheckNull(zip))
        {
            file = "contact2.txt";
            PrintContact(file, name, number, street, city, state, zip);

            addContact2.SetActive(false); //close addContact screen
        }

        else //display appropriate error
        {
            if (!CheckNull(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid name.";
            }

            else if (!CheckNameFirstChar(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Name cannot begin with a space, please enter a valid name.";
            }

            else if (!CheckNull(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNumber(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNull(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid street.";
            }

            else if (!CheckStreetLength(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Street is too long. Street must be comprised of eight seperate words/numbers or less.";
            }

            else if (!CheckNull(city))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid city.";
            }

            else if (!CheckNull(state))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid state.";
            }

            else if (!CheckNull(zip))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid zip code.";
            }
        }

    }

    public void AddContact3()
    {
        //get info from input fields
        InputField nameInput = GameObject.Find("NameInput3").GetComponent<InputField>();
        InputField numberInput = GameObject.Find("NumberInput3").GetComponent<InputField>();
        InputField streetInput = GameObject.Find("StreetInput3").GetComponent<InputField>();
        InputField cityInput = GameObject.Find("CityInput3").GetComponent<InputField>();
        InputField stateInput = GameObject.Find("StateInput3").GetComponent<InputField>();
        InputField zipInput = GameObject.Find("ZipInput3").GetComponent<InputField>();

        string name = nameInput.text.ToString();
        string number = numberInput.text.ToString();
        string street = streetInput.text.ToString();
        string city = cityInput.text.ToString();
        string state = stateInput.text.ToString();
        string zip = zipInput.text.ToString();

        //if validity checks passed, write to file
        if (CheckNull(name) && CheckNameFirstChar(name) && CheckNumber(number) && CheckNull(street) && CheckStreetLength(street) && CheckNull(city) && CheckNull(state)
                     && CheckNull(zip))
        {
            file = "contact3.txt";
            PrintContact(file, name, number, street, city, state, zip);

            addContact3.SetActive(false); //close addContact screen
        }

        else //display appropriate error
        {
            if (!CheckNull(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid name.";
            }

            else if (!CheckNameFirstChar(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Name cannot begin with a space, please enter a valid name.";
            }

            else if (!CheckNull(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNumber(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNull(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid street.";
            }

            else if (!CheckStreetLength(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Street is too long. Street must be comprised of eight seperate words/numbers or less.";
            }

            else if (!CheckNull(city))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid city.";
            }

            else if (!CheckNull(state))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid state.";
            }

            else if (!CheckNull(zip))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid zip code.";
            }
        }

    }

    public void AddContact4()
    {
        //get info from input fields
        InputField nameInput = GameObject.Find("NameInput4").GetComponent<InputField>();
        InputField numberInput = GameObject.Find("NumberInput4").GetComponent<InputField>();
        InputField streetInput = GameObject.Find("StreetInput4").GetComponent<InputField>();
        InputField cityInput = GameObject.Find("CityInput4").GetComponent<InputField>();
        InputField stateInput = GameObject.Find("StateInput4").GetComponent<InputField>();
        InputField zipInput = GameObject.Find("ZipInput4").GetComponent<InputField>();

        string name = nameInput.text.ToString();
        string number = numberInput.text.ToString();
        string street = streetInput.text.ToString();
        string city = cityInput.text.ToString();
        string state = stateInput.text.ToString();
        string zip = zipInput.text.ToString();

        //if validity checks passed, write to file
        if (CheckNull(name) && CheckNameFirstChar(name) && CheckNumber(number) && CheckNull(street) && CheckStreetLength(street) && CheckNull(city) && CheckNull(state)
                     && CheckNull(zip))
        {
            file = "contact4.txt";
            PrintContact(file, name, number, street, city, state, zip);

            addContact4.SetActive(false); //close addContact screen
        }

        else //display appropriate error
        {
            if (!CheckNull(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid name.";
            }

            else if (!CheckNameFirstChar(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Name cannot begin with a space, please enter a valid name.";
            }

            else if (!CheckNull(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNumber(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNull(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid street.";
            }

            else if (!CheckStreetLength(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Street is too long. Street must be comprised of eight seperate words/numbers or less.";
            }

            else if (!CheckNull(city))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid city.";
            }

            else if (!CheckNull(state))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid state.";
            }

            else if (!CheckNull(zip))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid zip code.";
            }
        }

    }

    public void EditContact1()
    {
        //get info from input fields
        InputField nameInput = GameObject.Find("EditNameInput1").GetComponent<InputField>();
        InputField numberInput = GameObject.Find("EditNumberInput1").GetComponent<InputField>();
        InputField streetInput = GameObject.Find("EditStreetInput1").GetComponent<InputField>();
        InputField cityInput = GameObject.Find("EditCityInput1").GetComponent<InputField>();
        InputField stateInput = GameObject.Find("EditStateInput1").GetComponent<InputField>();
        InputField zipInput = GameObject.Find("EditZipInput1").GetComponent<InputField>();

        string name = nameInput.text.ToString();
        string number = numberInput.text.ToString();
        string street = streetInput.text.ToString();
        string city = cityInput.text.ToString();
        string state = stateInput.text.ToString();
        string zip = zipInput.text.ToString();

        //if validity checks passed, write to file
        if (CheckNull(name) && CheckNameFirstChar(name) && CheckNumber(number) && CheckNull(street) && CheckStreetLength(street) && CheckNull(city) && CheckNull(state)
                     && CheckNull(zip))
        {
            ChangeLine(name, "contact1.txt", 1);
            ChangeLine(number, "contact1.txt", 2);
            ChangeLine(street, "contact1.txt", 3);
            ChangeLine(city, "contact1.txt", 4);
            ChangeLine(state, "contact1.txt", 5);
            ChangeLine(zip, "contact1.txt", 6);


            if (activeContact == 1) //if this is the current contact, recopy to contactActive
            {
                CopyFile("contact1.txt", "contactActive.txt");
            }

            resetStatsConfirm1.SetActive(true); //prompt for stats reset
        }

        else //display appropriate error
        {
            if (!CheckNull(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid name.";
            }

            else if (!CheckNameFirstChar(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Name cannot begin with a space, please enter a valid name.";
            }

            else if (!CheckNull(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNumber(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNull(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid street.";
            }

            else if (!CheckStreetLength(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Street is too long. Street must be comprised of eight seperate words/numbers or less.";
            }

            else if (!CheckNull(city))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid city.";
            }

            else if (!CheckNull(state))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid state.";
            }

            else if (!CheckNull(zip))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid zip code.";
            }
        }

    }

    public void EditContact2()
    {
        //get info from input fields
        InputField nameInput = GameObject.Find("EditNameInput2").GetComponent<InputField>();
        InputField numberInput = GameObject.Find("EditNumberInput2").GetComponent<InputField>();
        InputField streetInput = GameObject.Find("EditStreetInput2").GetComponent<InputField>();
        InputField cityInput = GameObject.Find("EditCityInput2").GetComponent<InputField>();
        InputField stateInput = GameObject.Find("EditStateInput2").GetComponent<InputField>();
        InputField zipInput = GameObject.Find("EditZipInput2").GetComponent<InputField>();

        string name = nameInput.text.ToString();
        string number = numberInput.text.ToString();
        string street = streetInput.text.ToString();
        string city = cityInput.text.ToString();
        string state = stateInput.text.ToString();
        string zip = zipInput.text.ToString();

        //if validity checks passed, write to file
        if (CheckNull(name) && CheckNameFirstChar(name) && CheckNumber(number) && CheckNull(street) && CheckStreetLength(street) && CheckNull(city) && CheckNull(state)
                     && CheckNull(zip))
        {
            ChangeLine(name, "contact2.txt", 1);
            ChangeLine(number, "contact2.txt", 2);
            ChangeLine(street, "contact2.txt", 3);
            ChangeLine(city, "contact2.txt", 4);
            ChangeLine(state, "contact2.txt", 5);
            ChangeLine(zip, "contact2.txt", 6);

            if (activeContact == 2) //if this is the current contact, recopy to contactActive
            {
                CopyFile("contact2.txt", "contactActive.txt");
            }

            resetStatsConfirm2.SetActive(true); //prompt for stats reset
        }

        else //display appropriate error
        {
            if (!CheckNull(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid name.";
            }

            else if (!CheckNameFirstChar(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Name cannot begin with a space, please enter a valid name.";
            }

            else if (!CheckNull(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNumber(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNull(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid street.";
            }

            else if (!CheckStreetLength(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Street is too long. Street must be comprised of eight seperate words/numbers or less.";
            }

            else if (!CheckNull(city))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid city.";
            }

            else if (!CheckNull(state))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid state.";
            }

            else if (!CheckNull(zip))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid zip code.";
            }
        }

    }

    public void EditContact3()
    {
        //get info from input fields
        InputField nameInput = GameObject.Find("EditNameInput3").GetComponent<InputField>();
        InputField numberInput = GameObject.Find("EditNumberInput3").GetComponent<InputField>();
        InputField streetInput = GameObject.Find("EditStreetInput3").GetComponent<InputField>();
        InputField cityInput = GameObject.Find("EditCityInput3").GetComponent<InputField>();
        InputField stateInput = GameObject.Find("EditStateInput3").GetComponent<InputField>();
        InputField zipInput = GameObject.Find("EditZipInput3").GetComponent<InputField>();

        string name = nameInput.text.ToString();
        string number = numberInput.text.ToString();
        string street = streetInput.text.ToString();
        string city = cityInput.text.ToString();
        string state = stateInput.text.ToString();
        string zip = zipInput.text.ToString();

        //if validity checks passed, write to file
        if (CheckNull(name) && CheckNameFirstChar(name) && CheckNumber(number) && CheckNull(street) && CheckStreetLength(street) && CheckNull(city) && CheckNull(state)
                     && CheckNull(zip))
        {
            ChangeLine(name, "contact3.txt", 1);
            ChangeLine(number, "contact3.txt", 2);
            ChangeLine(street, "contact3.txt", 3);
            ChangeLine(city, "contact3.txt", 4);
            ChangeLine(state, "contact3.txt", 5);
            ChangeLine(zip, "contact3.txt", 6);

            if (activeContact == 3) //if this is the current contact, recopy to contactActive
            {
                CopyFile("contact3.txt", "contactActive.txt");
            }


            resetStatsConfirm3.SetActive(true); //prompt for stats reset
        }

        else //display appropriate error
        {
            if (!CheckNull(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid name.";
            }

            else if (!CheckNameFirstChar(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Name cannot begin with a space, please enter a valid name.";
            }

            else if (!CheckNull(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNumber(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNull(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid street.";
            }

            else if (!CheckStreetLength(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Street is too long. Street must be comprised of eight seperate words/numbers or less.";
            }

            else if (!CheckNull(city))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid city.";
            }

            else if (!CheckNull(state))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid state.";
            }

            else if (!CheckNull(zip))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid zip code.";
            }
        }

    }

    public void EditContact4()
    {
        //get info from input fields
        InputField nameInput = GameObject.Find("EditNameInput4").GetComponent<InputField>();
        InputField numberInput = GameObject.Find("EditNumberInput4").GetComponent<InputField>();
        InputField streetInput = GameObject.Find("EditStreetInput4").GetComponent<InputField>();
        InputField cityInput = GameObject.Find("EditCityInput4").GetComponent<InputField>();
        InputField stateInput = GameObject.Find("EditStateInput4").GetComponent<InputField>();
        InputField zipInput = GameObject.Find("EditZipInput4").GetComponent<InputField>();

        string name = nameInput.text.ToString();
        string number = numberInput.text.ToString();
        string street = streetInput.text.ToString();
        string city = cityInput.text.ToString();
        string state = stateInput.text.ToString();
        string zip = zipInput.text.ToString();

        //if validity checks passed, write to file
        if (CheckNull(name) && CheckNameFirstChar(name) && CheckNumber(number) && CheckNull(street) && CheckStreetLength(street) && CheckNull(city) && CheckNull(state)
                     && CheckNull(zip))
        {
            ChangeLine(name, "contact4.txt", 1);
            ChangeLine(number, "contact4.txt", 2);
            ChangeLine(street, "contact4.txt", 3);
            ChangeLine(city, "contact4.txt", 4);
            ChangeLine(state, "contact4.txt", 5);
            ChangeLine(zip, "contact4.txt", 6);

            if (activeContact == 4) //if this is the current contact, recopy to contactActive
            {
                CopyFile("contact4.txt", "contactActive.txt");
            }


            resetStatsConfirm4.SetActive(true); //prompt for stats reset
        }

        else //display appropriate error
        {
            if (!CheckNull(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid name.";
            }

            else if (!CheckNameFirstChar(name))
            {
                errorScreen.SetActive(true);
                errorText.text = "Name cannot begin with a space, please enter a valid name.";
            }

            else if (!CheckNull(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNumber(number))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid phone number.";
            }

            else if (!CheckNull(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid street.";
            }

            else if (!CheckStreetLength(street))
            {
                errorScreen.SetActive(true);
                errorText.text = "Street is too long. Street must be comprised of eight seperate words/numbers or less.";
            }

            else if (!CheckNull(city))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid city.";
            }

            else if (!CheckNull(state))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid state.";
            }

            else if (!CheckNull(zip))
            {
                errorScreen.SetActive(true);
                errorText.text = "Please enter a valid zip code.";
            }
        }

    }

    public void DeleteContact1()
    {
        File.Delete("contact1.txt");
        contactSelectButton1.SetActive(true);
        activeIcon1.SetActive(false);
        deleteContactConfirm1.SetActive(false);

        if (activeContact == 1) //if this is the currently selected contact, also delete the active contact file
        {
            File.Delete("contactActive.txt");
            activeContact = 0; //no active contact since it was deleted
        }
    }

    public void DeleteContact2()
    {
        File.Delete("contact2.txt");
        contactSelectButton2.SetActive(true);
        activeIcon2.SetActive(false);
        deleteContactConfirm2.SetActive(false);

        if (activeContact == 2) //if this is the currently selected contact, also delete the active contact file
        {
            File.Delete("contactActive.txt");
            activeContact = 0; //no active contact since it was deleted
        }
    }

    public void DeleteContact3()
    {
        File.Delete("contact3.txt");
        contactSelectButton3.SetActive(true);
        activeIcon3.SetActive(false);
        deleteContactConfirm3.SetActive(false);

        if (activeContact == 3) //if this is the currently selected contact, also delete the active contact file
        {
            File.Delete("contactActive.txt");
            activeContact = 0; //no active contact since it was deleted
        }
    }

    public void DeleteContact4()
    {
        File.Delete("contact4.txt");
        contactSelectButton4.SetActive(true);
        activeIcon4.SetActive(false);
        deleteContactConfirm4.SetActive(false);

        if (activeContact == 4) //if this is the currently selected contact, also delete the active contact file
        {
            File.Delete("contactActive.txt");
            activeContact = 0;
        }
    }

    public void CancelButton()
    {
        addContact1.SetActive(false);
        editContact1.SetActive(false);
        addContact2.SetActive(false);
        editContact2.SetActive(false);
        addContact3.SetActive(false);
        editContact3.SetActive(false);
        addContact4.SetActive(false);
        editContact4.SetActive(false);
    }

    public void ResetStats1()
    {
        file = "contact1.txt";

        for (int i = 8; i < 44; i += 2)
        {
            ChangeLine("0 0", file, i);
        }

        if (activeContact == 1) //if this is the current contact, recopy to contactActive
        {
            CopyFile("contact1.txt", "contactActive.txt");
        }

        resetStatsConfirm1.SetActive(false);
        CancelButton();
    }

    public void ResetStats2()
    {
        file = "contact2.txt";

        for (int i = 8; i < 44; i += 2)
        {
            ChangeLine("0 0", file, i);
        }

        if (activeContact == 2) //if this is the current contact, recopy to contactActive
        {
            CopyFile("contact2.txt", "contactActive.txt");
        }

        resetStatsConfirm2.SetActive(false);
        CancelButton();
    }

    public void ResetStats3()
    {
        file = "contact3.txt";

        for (int i = 8; i < 44; i += 2)
        {
            ChangeLine("0 0", file, i);
        }

        if (activeContact == 3) //if this is the current contact, recopy to contactActive
        {
            CopyFile("contact3.txt", "contactActive.txt");
        }

        resetStatsConfirm3.SetActive(false);
        CancelButton();
    }

    public void ResetStats4()
    {
        file = "contact4.txt";

        for (int i = 8; i < 44; i += 2)
        {
            ChangeLine("0 0", file, i);
        }

        if (activeContact == 4) //if this is the current contact, recopy to contactActive
        {
            CopyFile("contact4.txt", "contactActive.txt");
        }

        resetStatsConfirm4.SetActive(false);
        CancelButton();
    }

    //validity checks
    public static bool CheckNumber(string s)
    {
        foreach (char c in s) //check if number is actually numerical
        {
            if (!(c >= '0' && c <= '9'))
            {
                return false;
            }
        }

        if (s.Length != 10) //check if number is correct length
        {
            return false;
        }

        return true;

    }

    public static bool CheckNull(string s) //check if null
    {
        if (s == "")
        {
            return false;
        }

        return true;
    }

    public static bool CheckStreetLength(string s)
    {
        string[] streetParts = s.Split(' ');
        int streetCount = streetParts.Count();

        if (streetCount > 8)
        {
            return false;
        }
        return true;
    }

    public static bool CheckNameFirstChar(string s)
    {
        if (s.Length > 0 && s[0] == ' ')
        {
            return false;
        }

        return true;
    }


    //utility functions
    static bool FileEquals(string path1, string path2) //compare two files
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

    static void CopyFile(string origin, string destination) //copy contents of origin file to destination
    {
        StreamWriter sw = new StreamWriter(destination);
        StreamReader sr = new StreamReader(origin);
        string line;

        try
        {
            while ((line = sr.ReadLine()) != null)
            {
                sw.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Cannot copy" + origin +  " to " + destination);
            Debug.Log(e);
        }

        sw.Close();
        sr.Close();
    }

    //edits specific line of file
    static void ChangeLine(string newText, string fileName, int line_to_edit)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line_to_edit - 1] = newText;
        File.WriteAllLines(fileName, arrLine);
    }

    static void PrintContact(string file, string name, string number, string street, string city, string state, string zip)
    {
        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(name);
            sw.WriteLine(number);
            sw.WriteLine(street);
            sw.WriteLine(city);
            sw.WriteLine(state);
            sw.WriteLine(zip);
            sw.WriteLine("Fill In Level 1 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Fill In Level 2 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Fill In Level 3 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Simon Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Unscramble Level 1 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Unscramble Level 2 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Unscramble Level 3 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Taxi Level 1 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Taxi Level 2 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Taxi Level 3 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Mail Out Level 1 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Mail Out Level 2 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Mail Out Level 3 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Alphabet Soup Level 1 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Alphabet Soup Level 2 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Alphabet Soup Level 3 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Blocks Level 1 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Blocks Level 2 Score: ");
            sw.WriteLine("0 0");
            sw.WriteLine("Blocks Level 3 Score: ");
            sw.WriteLine("0 0");
        }
    }
}
