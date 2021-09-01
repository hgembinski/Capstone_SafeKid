using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUnscrambleButton : MonoBehaviour
{
    public void Unscramble()
    {
        SceneManager.LoadScene("LevelSelectionUnscramble");
    }
}
