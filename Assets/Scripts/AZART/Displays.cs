using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine.UIElements;
using TMPro;
//using static UnityEditor.Progress;
using System.Xml.Linq;
using System.Reflection;
using UnityEditor.UIElements;

public class Displays : MonoBehaviour
{
    public GameObject[] tabs; // Массив вкладок
    private int currentTab = 0; // Индекс текущей вкладки

    //перечень всех вкладок
    public GameObject[] PoryadokZagruzki; // Порядок загрузки азарта
    public GameObject[] Loading; //Массив загрузки азарта
    public GameObject[] ViborRejimov; //Массив режимов работы азарта

    public GameObject[] OstovnoeMenu; // Массив пунктов основного списка меню
    public GameObject[] ServisMenu; //Массив пунктов сервисного меню
    public GameObject[] RedaktorDannih; //Массив пунктов редактора данных

    public GameObject[] ChastotniePlaniPPRch; // Массив пунктов списка частотных планов ППРЧ
    public GameObject MenuChastotnihPlanov;
    public GameObject[] MenuVChastotnihPlanah;

    public GameObject[] SpisokDiapaazonov;
    public GameObject MenuSpiska;
    public GameObject[] MenuSpiskaDiapazonov;
    public GameObject oknoChastot;

    public GameObject[] RedaktorChastoti;                                        

    private int currentPunkt = 0; // Индекс текущего пункта списка
    private bool punktSelected = false; // Флаг, указывающий, был ли выбран пункт списка

    public GameObject password; //Окно ввода пароля
    public TextMeshProUGUI data; //Вывод текущей даты 
    public TextMeshProUGUI time; //вывод текущего времени
    public TextMeshProUGUI time1; //вывод текущего времени в другом месте)))

    public TextMeshProUGUI nijnieChastoti;
    public TextMeshProUGUI verhnieChastoti;
    public TextMeshProUGUI sohranennieChastoti;

    // Start is called before the first frame update
    void Start()
    {
        LoadingAzart();
    }

    // Update is called once per frame
    void Update()
    {
        Time();

        for (int i = 0; i < tabs.Length; i++)
        {
            if (tabs[i].activeSelf)
            {
                currentTab = i; // Сохраняем индекс активного объекта
                break; // Прерываем цикл, если найден активный объект
            }
        }

        string text = nijnieChastoti.text;
        string text1 = verhnieChastoti.text;
        
        if(text != "" && text1 != "")
        {
            sohranennieChastoti.text = text + ".000-" + text1 + ".000 МГц";
            //SpisokDiapaazonov[2].SetActive(false);
            oknoChastot.SetActive(true);
            Debug.Log(sohranennieChastoti.text);
        }
    }

    IEnumerator LoadingText()
    {
        for (int i = 0; i < Loading.Length; i++)
        {
            yield return new WaitForSeconds(1f);
            Loading[i].gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(1f);

        ShowTab(0);
    }
    //функция получения реального времени из системы
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
        time1.text = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();
        data.text = day.ToString() + ":" + month.ToString() + ":" + year.ToString();
    }

    public void LoadingAzart()// Загрузка радиостанции
    {
        PoryadokZagruzki[0].gameObject.SetActive(true);

        StartCoroutine("LoadingText");
        Debug.Log("азарт загружается");
    }

    private void ShowTab(int index)
    {
        // Скрыть все вкладки
        foreach (GameObject tab in tabs)
        {
            tab.SetActive(false);
        }

        // Отобразить указанную вкладку
        if (index >= tabs.Length)
        {
            tabs[index - 1].SetActive(true);
            Debug.Log("ошибка");
        }
        else
        {
            tabs[index].SetActive(true);
            Debug.Log("tabs(вкладка) " + index);
        }
        // Сбросить текущий выбранный пункт списка и флаг itemSelected
        currentPunkt = 0;
        ViborPunkta(currentPunkt);
        punktSelected = true;
    }

    // на вход идет номер массива(из списка меню) и номер пункта массива
    public void ViborPunkta(int nomerPunkta)
    {
        switch(currentTab)
        {
            case 1:
                Debug.Log("открыто основное меню");
                foreach (GameObject item in OstovnoeMenu)
                {
                    item.SetActive(false);
                }
                if (nomerPunkta < 0)
                {
                    nomerPunkta = OstovnoeMenu.Length - 1;
                    currentPunkt = nomerPunkta;
                    //OstovnoeMenu[nomerPunkta].SetActive(true);
                }
                else if (nomerPunkta == OstovnoeMenu.Length)
                {
                    nomerPunkta = 0;
                    currentPunkt = nomerPunkta;
                    //OstovnoeMenu[nomerPunkta].SetActive(true);
                }

                OstovnoeMenu[nomerPunkta].SetActive(true);
                break;
            case 2:
                Debug.Log("открыто сервисное меню");
                foreach (GameObject item in ServisMenu)
                {
                    item.SetActive(false);
                }
                if (nomerPunkta < 0)
                {
                    nomerPunkta = ServisMenu.Length - 1;
                    currentPunkt = nomerPunkta;
                    //OstovnoeMenu[nomerPunkta].SetActive(true);
                }
                else if (nomerPunkta == ServisMenu.Length)
                {
                    nomerPunkta = 0;
                    currentPunkt = nomerPunkta;
                    //OstovnoeMenu[nomerPunkta].SetActive(true);
                }

                ServisMenu[nomerPunkta].SetActive(true);
                break;
            case 3:
                Debug.Log("открыт редактор данных");
                foreach (GameObject item in RedaktorDannih)
                {
                    item.SetActive(false);
                }
                if (nomerPunkta < 0)
                {
                    nomerPunkta = RedaktorDannih.Length - 1;
                    currentPunkt = nomerPunkta;
                    //OstovnoeMenu[nomerPunkta].SetActive(true);
                }
                else if (nomerPunkta == RedaktorDannih.Length)
                {
                    nomerPunkta = 0;
                    currentPunkt = nomerPunkta;
                    //OstovnoeMenu[nomerPunkta].SetActive(true);
                }

                RedaktorDannih[nomerPunkta].SetActive(true);
                break;
            case 4:
                Debug.Log("открыто частотные планы ППРЧ");
                if (MenuChastotnihPlanov.activeSelf == false)
                {
                    Debug.Log("Меню выключено");
                    foreach (GameObject item in ChastotniePlaniPPRch)
                    {
                        item.SetActive(false);
                    }
                    if (nomerPunkta < 0)
                    {
                        nomerPunkta = ChastotniePlaniPPRch.Length - 1;
                        currentPunkt = nomerPunkta;
                    }
                    else if (nomerPunkta == ChastotniePlaniPPRch.Length)
                    {
                        nomerPunkta = 0;
                        currentPunkt = nomerPunkta;
                    }

                    ChastotniePlaniPPRch[nomerPunkta].SetActive(true);
                }
                else if (MenuChastotnihPlanov.activeSelf == true) 
                {
                    Debug.Log("Меню включено");
                    foreach (GameObject item in MenuVChastotnihPlanah)
                    {
                        item.SetActive(false);
                    }
                    if (nomerPunkta < 0)
                    {
                        nomerPunkta = MenuVChastotnihPlanah.Length - 1;
                        currentPunkt = nomerPunkta;
                    }
                    else if (nomerPunkta == MenuVChastotnihPlanah.Length)
                    {
                        nomerPunkta = 0;
                        currentPunkt = nomerPunkta;
                    }

                    MenuVChastotnihPlanah[nomerPunkta].SetActive(true);
                }
                break;
            case 5:
                Debug.Log("открыт список диапазонов");
                if (MenuSpiska.activeSelf == false)
                {
                    Debug.Log("Меню выключено");
                    foreach (GameObject item in SpisokDiapaazonov)
                    {
                        item.SetActive(false);
                    }
                    if (nomerPunkta < 0)
                    {
                        nomerPunkta = SpisokDiapaazonov.Length - 1;
                        currentPunkt = nomerPunkta;
                    }
                    else if (nomerPunkta == SpisokDiapaazonov.Length)
                    {
                        nomerPunkta = 0;
                        currentPunkt = nomerPunkta;
                    }

                    SpisokDiapaazonov[nomerPunkta].SetActive(true);
                }
                else if (MenuSpiska.activeSelf == true)
                {
                    Debug.Log("Меню включено");
                    foreach (GameObject item in MenuSpiskaDiapazonov)
                    {
                        item.SetActive(false);
                    }
                    if (nomerPunkta < 0)
                    {
                        nomerPunkta = MenuSpiskaDiapazonov.Length - 1;
                        currentPunkt = nomerPunkta;
                    }
                    else if (nomerPunkta == MenuSpiskaDiapazonov.Length)
                    {
                        nomerPunkta = 0;
                        currentPunkt = nomerPunkta;
                    }

                    MenuSpiskaDiapazonov[nomerPunkta].SetActive(true);
                }
                break;
            case 6:
                Debug.Log("открыт редактор частоты");
                foreach (GameObject item in RedaktorChastoti)
                {
                    item.SetActive(false);
                }
                if (nomerPunkta < 0)
                {
                    nomerPunkta = RedaktorChastoti.Length - 1;
                    currentPunkt = nomerPunkta;
                    RedaktorChastoti[nomerPunkta].SetActive(true);
                }
                else if (nomerPunkta == RedaktorChastoti.Length)
                {
                    nomerPunkta = 0;
                    currentPunkt = nomerPunkta;
                    RedaktorChastoti[nomerPunkta].SetActive(true);
                }

                RedaktorChastoti[nomerPunkta].SetActive(true);

                break;
        }
    }

    private bool Logic()
    {
        if(currentTab == 1 && currentPunkt == 4)
        { 
            return true; 
        }

        if (currentTab == 2 && currentPunkt == 6 && password.activeSelf == false)
        {
            password.SetActive(true);
            Debug.Log("открыто окно с вводом пароля");
            return false;
        }
        if (currentTab == 2 && currentPunkt == 6 && password.activeSelf == true)
        {
            password.SetActive(false);
            return true;
        }

        if (currentTab == 3 && currentPunkt == 4)
        {
            return true;
        }

        if(currentTab == 4)
        {
            MenuChastotnihPlanov.SetActive(true);
        }

        if (currentTab == 4 && currentPunkt == 1 && MenuChastotnihPlanov.activeSelf == true)
        {
            MenuChastotnihPlanov.SetActive(false);
            return true;
        }

        if (currentTab == 5 && currentPunkt == 1 && MenuSpiska.activeSelf == true)
        {
            MenuSpiska.SetActive(false);
            return true;
        }
        if( currentTab == 5 )
        {
            MenuSpiska.SetActive(true);
            currentPunkt = 0;
            return false;
        }
        if (currentTab == 6)
        {
            return true;
        }

        string text = nijnieChastoti.text;
        string text1 = verhnieChastoti.text;
        if (currentTab == 7 && text != "" && text1 != "")
        {
            currentTab = 6;
            sohranennieChastoti.text = text + ".000 - " + text1 + ".000 МГц";
            SpisokDiapaazonov[3].SetActive(false);
            oknoChastot.SetActive(true);
            Debug.Log(sohranennieChastoti.text);
            return false;
            //sohranennieChastoti.text = text + ".000 - " + text1 + ".000 МГц";
        }


        return false;
    }

    public void BTN_up_L()
    {
        if (currentTab == 0)
        {
            currentTab = 1;
            currentPunkt = 0;
            ShowTab(currentTab);
        }
        else if (Logic() == true)
        {
            currentTab++;
            currentPunkt = 0;
            ShowTab(currentTab);
        }
        //else if (currentTab > 0)
        else if(currentTab == tabs.Length - 1)
        {
            Debug.Log("больше нет страниц");
        }
        //else if (password.activeSelf == true)
    }

    public void BTN_up_R()
    {
        if (MenuChastotnihPlanov.activeSelf == true)
        {
            MenuChastotnihPlanov.SetActive(false);
        }
        if (currentTab > 0)
        {
            currentTab--;
            currentPunkt = 0;
            ShowTab(currentTab);
        }
    }

    public void BTN_up()
    {
        if (punktSelected)
        {
            // Если пункт списка уже выбран, переключиться на следующий пункт
            currentPunkt--;
            Debug.Log("currentItem(пункт из списка) " + currentPunkt);
            ViborPunkta(currentPunkt);        
        }
        else
        {
            // Если пункт списка не выбран, выбрать текущий пункт
            punktSelected = true;
            Debug.Log("currentItem не выбран");
        }
    }

    public void BTN_down()
    {
        if (punktSelected)
        {
            // Если пункт списка уже выбран, переключиться на следующий пункт
            currentPunkt++;
            Debug.Log("currentItem(пункт из списка) " + currentPunkt);
            ViborPunkta(currentPunkt);
        }
        else
        {
            // Если пункт списка не выбран, выбрать текущий пункт
            punktSelected = true;
            Debug.Log("currentItem не выбран");
        }
    }

    public void ButtonPressed(int number)
    {
        if (RedaktorChastoti[0].activeSelf)
        {            
            nijnieChastoti.text += number.ToString();
        }
        else if (RedaktorChastoti[1].activeSelf)
        {            
            verhnieChastoti.text += number.ToString();
        }
    }
}

