using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class LoadMEnu : MonoBehaviour
{
    public DisplaysLogic DL;
    public GameObject[] Elements;

    public int punkt;

    private void OnEnable()
    {
        // Добавьте аналогичные подписки для остальных кнопок
        ButtonsController.OnButton1Pressed  += OpenNextTab;
        ButtonsController.OnButton2Pressed  += PerformAction2;
        ButtonsController.OnButton3Pressed  += ScrollPunktUp;
        ButtonsController.OnButton4Pressed  += ScrollPunktDawn;
        ButtonsController.OnButton16Pressed += OpenRejim;
    }
    private void OnDisable()
    {        
        // Добавьте аналогичные отписки для остальных кнопок
        ButtonsController.OnButton1Pressed  -= OpenNextTab;
        ButtonsController.OnButton2Pressed  -= PerformAction2;
        ButtonsController.OnButton3Pressed  -= ScrollPunktUp;
        ButtonsController.OnButton4Pressed  -= ScrollPunktDawn;
        ButtonsController.OnButton16Pressed -= OpenRejim;
    }

    private void OpenNextTab()
    {
        if (punkt == 0)
        {
            DL.ShowTab(2);
        }
        else if (punkt == 1)
        {
            Debug.Log("Понял прикол 1");
        }
    }
    private void PerformAction2()
    {
        Debug.Log("Понял прикол 2");
    }
    private void ScrollPunktUp()
    {
        punkt--;
        CheckNomber(punkt);
        UpdatePunkt(punkt);
    }
    private void ScrollPunktDawn()
    {
        punkt++;
        CheckNomber(punkt);
        UpdatePunkt(punkt);
    }
    // Start is called before the first frame update
    void Start()
    {
        punkt = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void CheckNomber(int i)
    {
        if(punkt < 0)
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

    private void OpenRejim()
    {
        DL.ShowTab(2);
    }
}
