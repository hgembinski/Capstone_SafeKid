using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class alphabetSoupUIDragger : MonoBehaviour
{
    	public bool inPosition;
	public Vector3 defaultPos;
	private RectTransform rectTransform;
	[SerializeField] private Canvas canvas;
	private CanvasGroup canvasGroup;

	private void Awake()
	{
		defaultPos = GetComponent<RectTransform>().localPosition;
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}
	
	public void OnBeginDrag(PointerEventData eventData){
		inPosition = false;
		canvasGroup.blocksRaycasts = false;
	}
	
	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}
	public void OnEndDrag(PointerEventData eventData){
		canvasGroup.blocksRaycasts = true;
		if( inPosition ){}
		// The item was NOT dropped onto a slot.        	
		else{this.rectTransform.localPosition = defaultPos;}
	}
	
	public void OnPointerDown(PointerEventData eventData){
	
	}
}
