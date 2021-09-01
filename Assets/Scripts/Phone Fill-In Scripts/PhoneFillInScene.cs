using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneFillInScene : MonoBehaviour
{
    public void FillInSceneButton()
    {
        SceneManager.LoadScene("PhoneFillIn");
    }
}
