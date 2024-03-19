using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonsController : MonoBehaviour
{
    public delegate void ButtonAction();

    public static event ButtonAction OnButton1Pressed;
    public static event ButtonAction OnButton2Pressed;
    public static event ButtonAction OnButton3Pressed;
    public static event ButtonAction OnButton4Pressed;
    public static event ButtonAction OnButton5Pressed;
    public static event ButtonAction OnButton6Pressed;
    public static event ButtonAction OnButton7Pressed;
    public static event ButtonAction OnButton8Pressed;
    public static event ButtonAction OnButton9Pressed;
    public static event ButtonAction OnButton10Pressed;
    public static event ButtonAction OnButton11Pressed;
    public static event ButtonAction OnButton12Pressed;
    public static event ButtonAction OnButton13Pressed;
    public static event ButtonAction OnButton14Pressed;
    public static event ButtonAction OnButton15Pressed;
    public static event ButtonAction OnButton16Pressed;
    public static event ButtonAction OnButton17Pressed;
    public static event ButtonAction OnButton18Pressed;

    public void btn_up_L() // кнопка 1
    {
        OnButton1Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_up_L");
    }
    public void btn_up_R() // кнопка 2
    {
        OnButton2Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_up_R");
    }
    public void btn_up()  // кнопка 3
    {
        OnButton3Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_up");
    }
    public void btn_down() // кнопка 4
    {
        OnButton4Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_down");
    }
    public void btn_phone_up() // кнопка 5
    {
        OnButton5Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_phone_up");
    }
    public void btn_phone_down() // кнопка 6
    {
        OnButton6Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_phone_down");
    }
    public void btn_1() // кнопка 7
    {
        OnButton7Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_1");
    }
    public void btn_2() // кнопка 8
    {
        OnButton8Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_2");
    }
    public void btn_3() // кнопка 9
    {
        OnButton9Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_3");
    }
    public void btn_4() // кнопка 10
    {
        OnButton10Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_4");
    }
    public void btn_5() // кнопка 11
    {
        OnButton11Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_5");
    }
    public void btn_6() // кнопка 12
    {
        OnButton12Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_6");
    }
    public void btn_7() // кнопка 13
    {
        OnButton13Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_7");
    }
    public void btn_8() // кнопка 14
    {
        OnButton14Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_8");
    }
    public void btn_9() // кнопка 15
    {
        OnButton15Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_9");
    }
    public void btn_0() // кнопка 16
    {
        OnButton16Pressed?.Invoke();
       // Debug.Log("Нажата кнопка btn_0");
    }
    public void btn_star() // кнопка 17
    {
        OnButton17Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_star");
    }
    public void btn_dies() // кнопка 18
    {
        OnButton18Pressed?.Invoke();
        //Debug.Log("Нажата кнопка btn_dies");
    }
}
