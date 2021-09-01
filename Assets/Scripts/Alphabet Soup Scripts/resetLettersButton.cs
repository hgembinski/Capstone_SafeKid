using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class resetLettersButton : MonoBehaviour
{
    public Button btn;
    Color standardColor = new Color(0.9433962f, 0.6855335f, 0.06674972f);

 
    public Text letter1;
    public Vector3 letter1DefaultPos;
    public Text letter2;
    public Vector3 letter2DefaultPos;	
    public Text letter3;
    public Vector3 letter3DefaultPos;
    public Text letter4;
    public Vector3 letter4DefaultPos;
    public Text letter5;
    public Vector3 letter5DefaultPos;
    public Text letter6;
    public Vector3 letter6DefaultPos;
    public Text letter7;
    public Vector3 letter7DefaultPos;
    public Text letter8;
    public Vector3 letter8DefaultPos;
    public Text letter9;
    public Vector3 letter9DefaultPos;
    public Text letter10;
    public Vector3 letter10DefaultPos;
    public Text letter11;
    public Vector3 letter11DefaultPos;
    public Text letter12;
    public Vector3 letter12DefaultPos; 
    public Text letter13;
    public Vector3 letter13DefaultPos;    
    public Text letter14;
    public Vector3 letter14DefaultPos; 
    public Text letter15;
    public Vector3 letter15DefaultPos; 


// Start is called before the first frame update
    void Start()
    {
        letter1DefaultPos = letter1.GetComponent<RectTransform>().localPosition;
	letter2DefaultPos = letter2.GetComponent<RectTransform>().localPosition;
	letter3DefaultPos = letter3.GetComponent<RectTransform>().localPosition;
	letter4DefaultPos = letter4.GetComponent<RectTransform>().localPosition;	
	letter5DefaultPos = letter5.GetComponent<RectTransform>().localPosition;
	letter6DefaultPos = letter6.GetComponent<RectTransform>().localPosition;
	letter7DefaultPos = letter7.GetComponent<RectTransform>().localPosition;
	letter8DefaultPos = letter8.GetComponent<RectTransform>().localPosition;
	letter9DefaultPos = letter9.GetComponent<RectTransform>().localPosition;
	letter10DefaultPos = letter10.GetComponent<RectTransform>().localPosition;
	letter11DefaultPos = letter11.GetComponent<RectTransform>().localPosition;
	letter12DefaultPos = letter12.GetComponent<RectTransform>().localPosition;
	letter13DefaultPos = letter13.GetComponent<RectTransform>().localPosition;
	letter14DefaultPos = letter14.GetComponent<RectTransform>().localPosition;
	letter15DefaultPos = letter15.GetComponent<RectTransform>().localPosition;

        Button btn = GetComponent<Button>();
	btn.onClick.AddListener(TaskOnClick);
    }

	void TaskOnClick(){
        PlayerPrefs.SetInt("soupScore", 0);
        letter1.rectTransform.localPosition = letter1DefaultPos;
		letter1.color = standardColor;
		letter2.rectTransform.localPosition = letter2DefaultPos;
		letter2.color = standardColor;
		letter3.rectTransform.localPosition = letter3DefaultPos;
		letter3.color = standardColor;
		letter4.rectTransform.localPosition = letter4DefaultPos;
		letter4.color = standardColor;
		letter5.rectTransform.localPosition = letter5DefaultPos;
		letter5.color = standardColor;
		letter6.rectTransform.localPosition = letter6DefaultPos;
		letter6.color = standardColor;
		letter7.rectTransform.localPosition = letter7DefaultPos;
		letter7.color = standardColor;
		letter8.rectTransform.localPosition = letter8DefaultPos;
		letter8.color = standardColor;
		letter9.rectTransform.localPosition = letter9DefaultPos;
		letter9.color = standardColor;
		letter10.rectTransform.localPosition = letter10DefaultPos;
		letter10.color = standardColor;
		letter11.rectTransform.localPosition = letter11DefaultPos;
		letter11.color = standardColor;
		letter12.rectTransform.localPosition = letter12DefaultPos;
		letter12.color = standardColor;
		letter13.rectTransform.localPosition = letter13DefaultPos;
		letter13.color = standardColor;
		letter14.rectTransform.localPosition = letter14DefaultPos;
		letter14.color = standardColor;
		letter15.rectTransform.localPosition = letter15DefaultPos;
		letter15.color = standardColor;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
