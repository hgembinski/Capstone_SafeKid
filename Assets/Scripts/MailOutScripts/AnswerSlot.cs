using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnswerSlot : MonoBehaviour, IDropHandler
{

    public string correctAnswer; //used to check the answers with the button boxes aka answer slots
    public bool isCorrect = false; //bool will remember if the last set value is correct

    //Used to snap the text into place with the boxes but also checks if they match as well
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            if (correctAnswer == eventData.pointerDrag.GetComponentInChildren<Text>().text)
            {
                Debug.Log("Correct!");
                isCorrect = true;
                Debug.Log(isCorrect);
            }
            else
            {
                Debug.Log("False");
                isCorrect = false;
                Debug.Log(isCorrect);
            }
        }
    }
}
