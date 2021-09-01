using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSimon : MonoBehaviour
{
    public void StartGameSimon()
    {
        SceneManager.LoadScene("SimonLevel1");
    }
}