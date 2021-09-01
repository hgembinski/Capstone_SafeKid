using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviewPhoneButton : MonoBehaviour
{
    public void ReviewPhoneScene()
    {
        SceneManager.LoadScene("ReviewPhone");
    }
}
