using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddEditContactButton : MonoBehaviour
{
    public void ContactsScene()
    {
        SceneManager.LoadScene("Contacts");
    }
}
