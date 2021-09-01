using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillInLevel2Button : MonoBehaviour
{
    public void FillInLevel2Scene()
    {
        SceneManager.LoadScene("FillInLevel2");
    }
}
