using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAlphabetSoupButton : MonoBehaviour
{
    public void AlphabetSoup()
    {
        SceneManager.LoadScene("LevelSelectionAlphabetSoup");
    }
}
