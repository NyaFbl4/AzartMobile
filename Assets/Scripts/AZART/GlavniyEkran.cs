using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlavniyEkran : MonoBehaviour, IStarted
{
    //[SerializeField] public Config config;

    public DisplaysLogic DL;
    public GameObject[] Elements;

    public TextMeshProUGUI DejPriem;
    public TextMeshProUGUI Rejim;
    public TextMeshProUGUI Naimenovanie;
    public TextMeshProUGUI RejimNiz;
    public TextMeshProUGUI Error;
    public GameObject LvlAkb;
    public GameObject Akb;
    public GameObject Akb1;
    public GameObject Antenna;

    public TextMeshProUGUI data; //Вывод текущей даты 
    public TextMeshProUGUI time; //вывод текущего времени

    public Config config;

    private void OnEnable()
    {
        // Добавьте аналогичные подписки для остальных кнопок
        ButtonsController.OnButton1Pressed += Menu;
        ButtonsController.OnButton2Pressed += Napravlenie;

        Started();
    }
    private void OnDisable()
    {
        // Добавьте аналогичные отписки для остальных кнопок
        ButtonsController.OnButton1Pressed -= Menu;
        ButtonsController.OnButton2Pressed -= Napravlenie;
    }

    // Start is called before the first frame update
    public void Started()
    {
        //config.SelectMode(0);
        DejPriem.text = config.DejPriyem;
        Rejim.text = config.OtkrRejim;
        Naimenovanie.text = config.Naimenovanie;
        RejimNiz.text = config.RejimNiz;
        Error.text = config.Error;
    }

    // Update is called once per frame
    void Update()
    {
        Time();
    }

    private void Menu()
    {
        DL.ShowTab(3);
    }
    private void Napravlenie()
    {
        DL.ShowTab(9);
    }
    private void Time()
    {
        int hour, minute, second, day, month, year;

        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;
        second = System.DateTime.Now.Second;

        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;

        time.text = (hour / 10).ToString() + (hour % 10).ToString() + ":"
                  + (minute / 10).ToString() + (minute % 10).ToString() + ":" 
                  + (second / 10).ToString() + (second % 10).ToString();

        data.text = (day / 10).ToString()  + (day % 10).ToString() + ":" 
                  + (month / 10).ToString() + (month % 10).ToString() + ":" 
                  + year.ToString();
    }
}
