using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public GameObject[] Dislays;
    public GameObject[] Loading;
    public GameObject[] LoadedMenu;
    public GameObject[] ChooseMenus;
    public GameObject[] Menus;

    public List<GameObject> tabs;
    
    public TextMeshProUGUI data;
    public TextMeshProUGUI time;
    public int parametr = 0;

    

    void Start()
    {

    }

    void Update()
    {
        Time();

        if (parametr == 1)
        {
            ChooseMenus[1].gameObject.SetActive(false);
            ChooseMenus[0].gameObject.SetActive(true);
        }
        else if (parametr == 2)
        {
            ChooseMenus[0].gameObject.SetActive(false);
            ChooseMenus[1].gameObject.SetActive(true);
        }
    }
    
    public void ShowMenu(GameObject menu)
    {
        menu.gameObject.SetActive(true);
    }

    public void LoadMenu()
    {
       if (parametr == 1)
       {
            Debug.Log(parametr); 
            Dislays[3].gameObject.SetActive(true);
       }
    }
    public void LoadMenuUp()
    {
        parametr = 1;

        //parametr--;

        Debug.Log(parametr);
    }

    public void LoadMenuDown()
    {
        parametr = 2;

        //parametr++;

        Debug.Log(parametr);
    }
    void Time()
    {
        int hour, minute, second, day, month, year;

        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;
        second = System.DateTime.Now.Second;

        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;

        time.text = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();
        data.text = day.ToString() + ":" + month.ToString() + ":" + year.ToString();
    }

    public void Button(int index)
    {
        int prew = index - 1;

        Debug.Log(index);

        Dislays[0].gameObject.SetActive(false);
        Dislays[index].gameObject.SetActive(true);
        Dislays[0] = Dislays[index];
    }

}
