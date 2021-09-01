using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MailOutLevelSelectButton : MonoBehaviour
{
    public void MailOutLevelSelectScene()
    {
        SceneManager.LoadScene("MailOutLevelSelect");
    }
}
