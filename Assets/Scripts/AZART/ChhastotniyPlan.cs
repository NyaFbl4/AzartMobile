using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChhastotniyPlan : MonoBehaviour
{
    public DisplaysLogic DL;
    public GameObject[] Elements;

    public GameObject MenuPlanov;
    public GameObject[] ElementsMenu;

    public int punkt;
    public int punktMenu;

    private void OnEnable()
    {
        // Добавьте аналогичные подписки для остальных кнопок
        ButtonsController.OnButton1Pressed += Menu;
        ButtonsController.OnButton2Pressed += Nazad;
        ButtonsController.OnButton3Pressed += ScrollPunktUp;
        ButtonsController.OnButton4Pressed += ScrollPunktDawn;
    }
    private void OnDisable()
    {
        // Добавьте аналогичные отписки для остальных кнопок
        ButtonsController.OnButton1Pressed -= Menu;
        ButtonsController.OnButton2Pressed -= Nazad;
        ButtonsController.OnButton3Pressed -= ScrollPunktUp;
        ButtonsController.OnButton4Pressed -= ScrollPunktDawn;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Menu()   //
    {

    }
    private void Nazad()
    {

    }
    private void ScrollPunktUp()
    {
        if (MenuPlanov.activeSelf == false)
        {
            punkt = DL.UpperPunktTest(punkt, Elements);
        }
        else
        {
            punktMenu = DL.UpperPunktTest(punktMenu, ElementsMenu);
        }
    }
    private void ScrollPunktDawn()
    {
        if (MenuPlanov.activeSelf == false)
        {
            punkt = DL.DownPunktTest(punkt, Elements);
        }
        else
        {
            punktMenu = DL.DownPunktTest(punktMenu, ElementsMenu);
        }
    }
}
