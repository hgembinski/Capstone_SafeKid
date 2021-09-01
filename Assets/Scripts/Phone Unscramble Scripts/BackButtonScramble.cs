using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScramble : MonoBehaviour
{
   public void ExitUnscramble()
    {
        SceneManager.LoadScene("PhonePractice");
    }
}
