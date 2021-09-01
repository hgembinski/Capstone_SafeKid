using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillInLevel1Button : MonoBehaviour
{
    public void FillInLevel1Scene()
    {
        SceneManager.LoadScene("FillInLevel1");
    }
}
