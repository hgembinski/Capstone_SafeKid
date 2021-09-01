using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillInLevel3Button : MonoBehaviour
{
    public void FillInLevel3Scene()
    {
        SceneManager.LoadScene("FillInLevel3");
    }
}
