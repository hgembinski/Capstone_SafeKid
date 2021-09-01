using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnscrambleButton : MonoBehaviour
{
    public void InstructionsUnscramble()
    {
        SceneManager.LoadScene("InstructionsUnscramble");
    }	
}
