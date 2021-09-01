using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class selectBlank : MonoBehaviour
{
	public Button btn;
	// Start is called before the first frame update
	void Start(){
	Button btn = GetComponent<Button>();
	btn.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	void Update(){}

	void TaskOnClick()
	{
		switch (PlayerPrefs.GetInt("currentLetter"))
      		{
		case 0:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "A";
              		break;
		case 1:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "B";
              		break;
          	case 2:
              		btn.GetComponentInChildren<TMP_Text>().text = "C";
              		break;
          	case 3:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "D";
              		break;
          	case 4:
              		btn.GetComponentInChildren<TMP_Text>().text = "E";
              		break;
          	case 5:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "F";
              		break;
          	case 6:
              		btn.GetComponentInChildren<TMP_Text>().text = "G";
              		break;
          	case 7:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "H";
              		break;
          	case 8:
              		btn.GetComponentInChildren<TMP_Text>().text = "I";
              		break;
          	case 9:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "J";
              		break;
          	case 10:
              		btn.GetComponentInChildren<TMP_Text>().text = "K";
              		break;
          	case 11:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "L";
              		break;
          	case 12:
              		btn.GetComponentInChildren<TMP_Text>().text = "M";
              		break;
          	case 13:
              		btn.GetComponentInChildren<TMP_Text>().text = "N";
              		break;
          	case 14:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "O";
              		break;
          	case 15:
              		btn.GetComponentInChildren<TMP_Text>().text = "P";
              		break;
          	case 16:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "Q";
              		break;
          	case 17:
              		btn.GetComponentInChildren<TMP_Text>().text = "R";
              		break;
          	case 18:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "S";
              		break;
          	case 19:
              		btn.GetComponentInChildren<TMP_Text>().text = "T";
              		break;
          	case 20:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "U";
              		break;
          	case 21:
              		btn.GetComponentInChildren<TMP_Text>().text = "V";
              		break;
          	case 22:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "W";
              		break;
          	case 23:
              		btn.GetComponentInChildren<TMP_Text>().text = "X";
              		break;
          	case 24:
             	 	btn.GetComponentInChildren<TMP_Text>().text = "Y";
              		break;
          	case 25:
              		btn.GetComponentInChildren<TMP_Text>().text = "Z";
              		break;
		}

		btn.GetComponentInChildren<TMP_Text>().faceColor = new Color32(0, 0, 0, 255);

	} 	

}
