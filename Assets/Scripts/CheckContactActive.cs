//Haiden Gembinski
//Script to delete Active Contact if it does not match an existing contact

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CheckContactActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int activeContact = 0;

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

}
