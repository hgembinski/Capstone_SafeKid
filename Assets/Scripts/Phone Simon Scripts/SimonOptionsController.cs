using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonOptionsController : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject hintBar;
    public GameObject SimonGame;

    public void ShowOptions()
    {
        if (optionsPanel.activeSelf)
        {
            optionsPanel.SetActive(false);
        }
        else
        {
            optionsPanel.SetActive(true);
        }
    }

    public void ShowHintBar(bool b)
    {
        hintBar.SetActive(b);
    }

    public void EasyModeToggle(bool b)
    {
        SimonGame.GetComponent<SimonSays>().easyMode = b;
    }

    public void updateSpeed(int s)
    {
        SimonGame.GetComponent<SimonSays>().speedMult = s + 1;
    }

    public void switchSounds(int s)
    {
        SimonGame.GetComponent<SimonSays>().soundChoice = s;
    }
}
