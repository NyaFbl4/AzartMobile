using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpisokNapravleniy : MonoBehaviour, IStarted
{
    public DisplaysLogic DL;
    public GameObject[] Elements;
    public GameObject[] ElementsMenu;

    public GameObject[] ElementsMassivaKanalov;

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
        punktMenu = 0;
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

    }
    private void Vibrat()   //
    {
        if (menu.activeSelf == false)
        {
            menu.SetActive(true);
        }
        else if (menu.activeSelf == true && punktMenu == 1)
        {
            DL.ShowTab(10);
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
    }
    private void ScrollPunktUp()
    {
        if (menu.activeSelf == false)
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
        if (menu.activeSelf == false)
        {
            punkt = DL.DownPunktTest(punkt, Elements);
        }
        else
        {
            punktMenu = DL.DownPunktTest(punktMenu, ElementsMenu);
        }
    }
}
