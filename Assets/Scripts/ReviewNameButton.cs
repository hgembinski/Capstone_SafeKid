using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviewNameButton : MonoBehaviour
{
    public void ReviewNameScene()
    {
        SceneManager.LoadScene("ReviewName");
    }
}
