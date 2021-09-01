//real project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class ButtonDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IBeginDragHandler
{
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform; 

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>(); 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .75f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = Input.mousePosition; 
        //transform.position = Input.mousePosition / canvas.scaleFactor;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDown");
        canvasGroup.alpha = 1f;

        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
