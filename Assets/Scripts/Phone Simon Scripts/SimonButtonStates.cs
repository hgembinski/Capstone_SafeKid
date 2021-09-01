using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButtonStates : MonoBehaviour
{
    public GameObject controller;


    //number buttons
    public void Button1()
    {
        controller.GetComponent<SimonSays>().recieveNum(1);
    }

    public void Button2()
    {
        controller.GetComponent<SimonSays>().recieveNum(2);
    }

    public void Button3()
    {
        controller.GetComponent<SimonSays>().recieveNum(3);
    }

    public void Button4()
    {
        controller.GetComponent<SimonSays>().recieveNum(4);
    }

    public void Button5()
    {
        controller.GetComponent<SimonSays>().recieveNum(5);
    }

    public void Button6()
    {
        controller.GetComponent<SimonSays>().recieveNum(6);
    }

    public void Button7()
    {
        controller.GetComponent<SimonSays>().recieveNum(7);
    }

    public void Button8()
    {
        controller.GetComponent<SimonSays>().recieveNum(8);
    }

    public void Button9()
    {
        controller.GetComponent<SimonSays>().recieveNum(9);
    }

    public void Button0()
    {
        controller.GetComponent<SimonSays>().recieveNum(0);
    }
}
