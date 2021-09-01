using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MailOutButton : MonoBehaviour
{
    public void AddressMailOut()
    {
        SceneManager.LoadScene("AddressMailOut");
    }
}
