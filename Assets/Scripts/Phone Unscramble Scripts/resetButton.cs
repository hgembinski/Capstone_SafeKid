using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class resetButton : MonoBehaviour
{
    public Button btn;
    Color black = new Color(0.0f, 0.0f, 0.0f);

 
    public Text digit1;
    public Vector3 digit1DefaultPos;
    public Text digit2;
    public Vector3 digit2DefaultPos;	
    public Text digit3;
    public Vector3 digit3DefaultPos;
    public Text digit4;
    public Vector3 digit4DefaultPos;
    public Text digit5;
    public Vector3 digit5DefaultPos;
    public Text digit6;
    public Vector3 digit6DefaultPos;
    public Text digit7;
    public Vector3 digit7DefaultPos;
    public Text digit8;
    public Vector3 digit8DefaultPos;
    public Text digit9;
    public Vector3 digit9DefaultPos;
    public Text digit10;
    public Vector3 digit10DefaultPos;
    public Text digit11;
    public Vector3 digit11DefaultPos;
    public Text digit12;
    public Vector3 digit12DefaultPos;

    // Start is called before the first frame update
    void Start()
    {
	digit1DefaultPos = digit1.GetComponent<RectTransform>().localPosition;
	digit2DefaultPos = digit2.GetComponent<RectTransform>().localPosition;
	digit3DefaultPos = digit3.GetComponent<RectTransform>().localPosition;
	digit4DefaultPos = digit4.GetComponent<RectTransform>().localPosition;	
	digit5DefaultPos = digit5.GetComponent<RectTransform>().localPosition;
	digit6DefaultPos = digit6.GetComponent<RectTransform>().localPosition;
	digit7DefaultPos = digit7.GetComponent<RectTransform>().localPosition;
	digit8DefaultPos = digit8.GetComponent<RectTransform>().localPosition;
	digit9DefaultPos = digit9.GetComponent<RectTransform>().localPosition;
	digit10DefaultPos = digit10.GetComponent<RectTransform>().localPosition;
	digit11DefaultPos = digit11.GetComponent<RectTransform>().localPosition;
	digit12DefaultPos = digit12.GetComponent<RectTransform>().localPosition;

        Button btn = GetComponent<Button>();
	btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
	PlayerPrefs.SetInt("unscrambleScore", 0);
	digit1.rectTransform.localPosition = digit1DefaultPos;
	digit1.color = black;
	digit2.rectTransform.localPosition = digit2DefaultPos;
	digit2.color = black;
	digit3.rectTransform.localPosition = digit3DefaultPos;
	digit3.color = black;
	digit4.rectTransform.localPosition = digit4DefaultPos;
	digit4.color = black;
	digit5.rectTransform.localPosition = digit5DefaultPos;
	digit5.color = black;
	digit6.rectTransform.localPosition = digit6DefaultPos;
	digit6.color = black;
	digit7.rectTransform.localPosition = digit7DefaultPos;
	digit7.color = black;
	digit8.rectTransform.localPosition = digit8DefaultPos;
	digit8.color = black;
	digit9.rectTransform.localPosition = digit9DefaultPos;
	digit9.color = black;
	digit10.rectTransform.localPosition = digit10DefaultPos;
	digit10.color = black;
	digit11.rectTransform.localPosition = digit11DefaultPos;
	digit11.color = black;
	digit12.rectTransform.localPosition = digit12DefaultPos;
	digit12.color = black;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
