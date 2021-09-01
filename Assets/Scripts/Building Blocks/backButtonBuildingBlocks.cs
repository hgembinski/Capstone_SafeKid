using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backButtonBuildingBlocks : MonoBehaviour
{
    public void returnToInstructionsBuildingBlocks()
    {
        SceneManager.LoadScene("InstructionsBuildingBlocks");
    }
}
