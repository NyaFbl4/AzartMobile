using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using R187_P1;

public class SpisokKanalov : MonoBehaviour, IStarted
{
    public DisplaysLogic DL;
    
    public GameObject[] Elements;
    public GameObject[] ElementsMenu;

    public GameObject[] ElementsMassivaKanalov;

    [SerializeField] private Transform parentObject;
    [SerializeField] private GameObject newKanalSvyaziPrefab;

    [SerializeField] private GameObject _default;

    public int punkt;
    public int punktMenu;

    [SerializeField] private GameObject menu;

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
        menu.SetActive(false);
        punkt = 0;
        //DL.UpperPunktTest(punkt, Elements);
        punktMenu = 0;
        //DL.UpperPunktTest(punktMenu, ElementsMenu);
    }
    // Start is called before the first frame update
    void Start()
    {
        //menu.SetActive(false);
        //punkt = 0;
        //punktMenu = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ElementsMassivaKanalov.Length == 0)
        {
            _default.SetActive(true);
        }
        else
        {
            _default.SetActive(false);
        }
    }

    private void Vibrat()   //
    {
        if (menu.activeSelf == false)
        {
            menu.SetActive(true);
        }
        else if (menu.activeSelf == true && punktMenu == 1)
        {
            DL.ShowTab(12);
        }
    }
    private void Nazad()
    {
        if (menu.activeSelf == true)
        {
            menu.SetActive(false);
        }
        else
        {
            DL.ShowTab(5);
        }

        if (menu.activeSelf == true)
        {
            menu.SetActive(false);
        }
    }
    private void ScrollPunktUp()
    {
        if (menu.activeSelf == false)
        {
            punkt = DL.UpperPunktTest(punkt, ElementsMassivaKanalov);
        }
        else if (menu.activeSelf == true)
        {
            punktMenu = DL.UpperPunktTest(punktMenu, ElementsMenu);
        }
    }
    private void ScrollPunktDawn()
    {
        if (menu.activeSelf == false)
        {
            punkt = DL.DownPunktTest(punkt, ElementsMassivaKanalov);
        }
        else if (menu.activeSelf == true)
        {
            punktMenu = DL.DownPunktTest(punktMenu, ElementsMenu);
        }
    }
}
