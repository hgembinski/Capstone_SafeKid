using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class throwAwayBlock : MonoBehaviour, IDropHandler
{
	// Start is called before the first frame update
	void Start()
	{
        
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
			eventData.pointerDrag.GetComponent<dragBlock>().inPosition = true;
			Destroy(eventData.pointerDrag.transform.gameObject);
			spawnBlocks sn;
			sn = GameObject.FindObjectOfType(typeof(spawnBlocks)) as spawnBlocks;
			sn.spawnBlock();
		}
		else{}	
	} 
}
