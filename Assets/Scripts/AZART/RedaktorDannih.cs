using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedaktorDannih : MonoBehaviour, IStarted
{
    public DisplaysLogic DL;
    public GameObject[] Elements;

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
    // Start is called before the first frame update

    public void Started()
    {
        punkt = 0;
        UpdatePunkt(punkt);
    }

    void Start()
    {
        //punkt = 0;
        //UpdatePunkt(punkt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Vibrat()   //
    {
        if (punkt == 1)
        {
            DL.ShowTab(9);
        }
        else if (punkt == 2)
        {
            DL.ShowTab(11);
        }
        else if (punkt == 4)
        {
            DL.ShowTab(6);
        }
        else if (punkt == 1)
        {
            DL.ShowTab(8);
        }
        else if (punkt == 2)
        {
            DL.ShowTab(10);
        }
    }
    private void Nazad()
    {
        DL.ShowTab(4);
    }
    private void ScrollPunktUp()
    {
        punkt--;
        //UpdatePunkt(DL.CheckNomberInMassiv(punkt, Elements), Elements);
        CheckNomber(punkt);
        UpdatePunkt(punkt);
    }
    private void ScrollPunktDawn()
    {
        punkt++;
        //UpdatePunkt(DL.CheckNomberInMassiv(punkt, Elements), Elements);
        CheckNomber(punkt);
        UpdatePunkt(punkt);
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