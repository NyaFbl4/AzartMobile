using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplaysLogic : MonoBehaviour
{
    [SerializeField] private bool WorkAzart = false;

    public GameObject[] tabs;             // Массив вкладок
    public int currentPunkt = 0;          // Номер пункта

    public GameObject[] MassivKanalov;

    private void StartAzart()
    {

    }

    void Start()
    {

    }
    private void Update()
    {
        
    }

    public void LoadingAzart()            // Загрузка радиостанции
    {                                     // Сделать выключение азарта 
        if (WorkAzart == false)
        {
            tabs[0].gameObject.SetActive(true);
            WorkAzart = true;
        }
        else if (WorkAzart == true)
        {
            foreach (GameObject tab in tabs)
            {
                tab.SetActive(false);
            }
            WorkAzart = false;
        }
    }

    public void ShowTab(int index)
    {
       // Debug.Log("Открывается вкладка " + index);
        // Скрыть все вкладки
        foreach (GameObject tab in tabs)
        {
            tab.SetActive(false);
        }

        tabs[index].SetActive(true);
        //Debug.Log("tabs(вкладка) " + index);
    }

    // пока тестовые функции
    public int CheckNomberInMassiv(int index, GameObject[] massiv)
    {
        if (index < 0)
        {
            index = massiv.Length - 1;
            //Debug.Log("пункт будет меньше 0");
        }
        else if (index == massiv.Length)
        {
            index = 0;
            //Debug.Log("пукнт будет больше макс.элемента");
        }

        return index;
    }

    public void UpdatePunkt(int i, GameObject[] massiv)
    {
        foreach (GameObject tab in massiv)
        {
            tab.SetActive(false);
        }

        massiv[i].SetActive(true);
        //Debug.Log("currentPunkt(пункт) " + i);
    }

    public int UpperPunktTest(int i, GameObject[] massiv)
    {
        i--;

        if (i < 0)
        {
            i = massiv.Length - 1;
            //Debug.Log("пункт будет меньше 0");
        }
        else if (i == massiv.Length)
        {
            i = 0;
            //Debug.Log("пукнт будет больше макс.элемента");
        }

        foreach (GameObject tab in massiv)
        {
            tab.SetActive(false);
        }

        massiv[i].SetActive(true);
        //Debug.Log("currentPunkt(пункт) " + i);

        return i;
    }

    public int DownPunktTest(int i, GameObject[] massiv)
    {
        i++;

        if (i < 0)
        {
            i = massiv.Length - 1;
           // Debug.Log("пункт будет меньше 0");
        }
        else if (i == massiv.Length)
        {
            i = 0;
            //Debug.Log("пукнт будет больше макс.элемента");
        }
        else if (i == 0)
        {
            i = 0;
        }

        foreach (GameObject tab in massiv)
        {
            tab.SetActive(false);
        }

        massiv[i].SetActive(true);
        //Debug.Log("currentPunkt(пункт) " + i);

        return i;
    }
}
