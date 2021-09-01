using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillInLevelSelectButton : MonoBehaviour
{
    public void FillInLevelSelectScene()
    {
        SceneManager.LoadScene("FillInLevelSelect");
    }
}