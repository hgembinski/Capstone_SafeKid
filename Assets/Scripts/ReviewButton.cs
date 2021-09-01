using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviewButton : MonoBehaviour
{

    public void ReviewScene()
    {
        SceneManager.LoadScene("Review");
    }
}
