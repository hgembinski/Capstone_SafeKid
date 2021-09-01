using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MailOutLevel1Button : MonoBehaviour
{
    public void MailOutLevel1ButtonScene()
    {
        SceneManager.LoadScene("MailOutTest");
    }
}
