using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OstovnoeMenu : MonoBehaviour, IStarted
{
    public DisplaysLogic DL;
    public GameObject[] Elements;
    public TextMeshProUGUI time; //вывод текущего времени
    public int punkt;

    private void OnEnable()
    {
        // Добавьте аналогичные подписки для остальных кнопок
        ButtonsController.OnButton1Pressed += Vibrat;
        ButtonsController.OnButton2Pressed += Nazad;
        ButtonsController.OnButton3Pressed += ScrollPunktUp;
        ButtonsController.OnButton4Pressed += ScrollPunktDawn;

        Started();
    }
    private void OnDisable()
    {
        // Добавьте аналогичные отписки для остальных кнопок
        ButtonsController.OnButton1Pressed -= Vibrat;
        ButtonsController.OnButton2Pressed -= Nazad;
        ButtonsController.OnButton3Pressed -= ScrollPunktUp;
        ButtonsController.OnButton4Pressed -= ScrollPunktDawn;
    }

    public void Started()
    {
        punkt = 0;
        UpdatePunkt(punkt);
    }

    // Start is called before the first frame update
    void Start()
    {
        //punkt = 0;
        //UpdatePunkt(punkt);
    }

    // Update is called once per frame
    void Update()
    {
        Time();
    }
    private void Time()
    {
        int hour, minute, second;

        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;
        second = System.DateTime.Now.Second;

        time.text = (hour / 10).ToString() + (hour % 10).ToString() + ":"
                  + (minute / 10).ToString() + (minute % 10).ToString() + ":"
                  + (second / 10).ToString() + (second % 10).ToString();
    }
    private void Vibrat()
    {
        if (punkt == 4)
        {
            DL.ShowTab(4);
        }
    }
    private void Nazad()
    {
        DL.ShowTab(2);
    }
    private void ScrollPunktUp()
    {
        //punkt = UpperPunkt(punkt, Elements);
        punkt = DL.UpperPunktTest(punkt, Elements);
        //punkt--;
        //CheckNomber(punkt);
        //UpdatePunkt(punkt);
    }
    private void ScrollPunktDawn()
    {
        //punkt = DownPunkt(punkt, Elements);
        punkt = DL.DownPunktTest(punkt, Elements);
        //punkt++;
        //CheckNomber(punkt);
        //UpdatePunkt(punkt);
    }
    private void CheckNomber(int i)
    {
        if (punkt < 0)
        {
            punkt = Elements.Length - 1;
            Debug.Log("пункт будет меньше 0");
        }
        else if (punkt == Elements.Length)
        {
            punkt = 0;
            Debug.Log("пукнт будет больше макс.элемента");
        }
    }
    private void UpdatePunkt(int i)
    {
        foreach (GameObject tab in Elements)
        {
            tab.SetActive(false);
        }

        Elements[i].SetActive(true);
        Debug.Log("currentPunkt(пункт) " + i);
    }
}
