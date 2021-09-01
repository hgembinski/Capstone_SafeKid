using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startBuildingBlocks : MonoBehaviour
{
    public void BuildingBlocks()
    {
        SceneManager.LoadScene("selectLevelBuildingBlocks");
    }
}
