using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MailOutDescriptionButton : MonoBehaviour
{
    public void MailOutDescriptionButtonScene()
    {
        SceneManager.LoadScene("AddressMailOut");
    }
}
