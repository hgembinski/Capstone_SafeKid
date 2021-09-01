using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillInButton : MonoBehaviour
{
    public void FillInScene()
    {
        SceneManager.LoadScene("PhoneFillIn"); 
    }
}
