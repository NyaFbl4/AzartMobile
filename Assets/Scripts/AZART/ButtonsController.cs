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

    public void btn_up_L() // ������ 1
    {
        OnButton1Pressed?.Invoke();
        //Debug.Log("������ ������ btn_up_L");
    }
    public void btn_up_R() // ������ 2
    {
        OnButton2Pressed?.Invoke();
        //Debug.Log("������ ������ btn_up_R");
    }
    public void btn_up()  // ������ 3
    {
        OnButton3Pressed?.Invoke();
        //Debug.Log("������ ������ btn_up");
    }
    public void btn_down() // ������ 4
    {
        OnButton4Pressed?.Invoke();
        //Debug.Log("������ ������ btn_down");
    }
    public void btn_phone_up() // ������ 5
    {
        OnButton5Pressed?.Invoke();
        //Debug.Log("������ ������ btn_phone_up");
    }
    public void btn_phone_down() // ������ 6
    {
        OnButton6Pressed?.Invoke();
        //Debug.Log("������ ������ btn_phone_down");
    }
    public void btn_1() // ������ 7
    {
        OnButton7Pressed?.Invoke();
        //Debug.Log("������ ������ btn_1");
    }
    public void btn_2() // ������ 8
    {
        OnButton8Pressed?.Invoke();
        //Debug.Log("������ ������ btn_2");
    }
    public void btn_3() // ������ 9
    {
        OnButton9Pressed?.Invoke();
        //Debug.Log("������ ������ btn_3");
    }
    public void btn_4() // ������ 10
    {
        OnButton10Pressed?.Invoke();
        //Debug.Log("������ ������ btn_4");
    }
    public void btn_5() // ������ 11
    {
        OnButton11Pressed?.Invoke();
        //Debug.Log("������ ������ btn_5");
    }
    public void btn_6() // ������ 12
    {
        OnButton12Pressed?.Invoke();
        //Debug.Log("������ ������ btn_6");
    }
    public void btn_7() // ������ 13
    {
        OnButton13Pressed?.Invoke();
        //Debug.Log("������ ������ btn_7");
    }
    public void btn_8() // ������ 14
    {
        OnButton14Pressed?.Invoke();
        //Debug.Log("������ ������ btn_8");
    }
    public void btn_9() // ������ 15
    {
        OnButton15Pressed?.Invoke();
        //Debug.Log("������ ������ btn_9");
    }
    public void btn_0() // ������ 16
    {
        OnButton16Pressed?.Invoke();
       // Debug.Log("������ ������ btn_0");
    }
    public void btn_star() // ������ 17
    {
        OnButton17Pressed?.Invoke();
        //Debug.Log("������ ������ btn_star");
    }
    public void btn_dies() // ������ 18
    {
        OnButton18Pressed?.Invoke();
        //Debug.Log("������ ������ btn_dies");
    }
}
