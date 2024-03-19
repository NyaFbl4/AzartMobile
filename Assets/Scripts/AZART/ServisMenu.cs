using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ServisMenu : MonoBehaviour, IStarted
{
    public DisplaysLogic DL;
    public GameObject[] Elements;

    public int punkt;

    public GameObject password;
    public TextMeshProUGUI passwordText;
    [SerializeField] public string passwordTrue = "";

    private void OnEnable()
    {
        // Добавьте аналогичные подписки для остальных кнопок
        ButtonsController.OnButton1Pressed += Vibrat;
        ButtonsController.OnButton2Pressed += Nazad;
        ButtonsController.OnButton3Pressed += ScrollPunktUp;
        ButtonsController.OnButton4Pressed += ScrollPunktDawn;

        ButtonsController.OnButton7Pressed  += Vvod_1;       
        ButtonsController.OnButton8Pressed  += Vvod_2;
        ButtonsController.OnButton9Pressed  += Vvod_3;
        ButtonsController.OnButton10Pressed += Vvod_4;
        ButtonsController.OnButton11Pressed += Vvod_5;
        ButtonsController.OnButton12Pressed += Vvod_6;
        ButtonsController.OnButton13Pressed += Vvod_7;
        ButtonsController.OnButton14Pressed += Vvod_8;
        ButtonsController.OnButton15Pressed += Vvod_9;
        ButtonsController.OnButton16Pressed += Vvod_0;
        ButtonsController.OnButton17Pressed += Vvod_star;
        ButtonsController.OnButton18Pressed += Vvod_dies;

        Started();
    }
    private void OnDisable()
    {
        // Добавьте аналогичные отписки для остальных кнопок
        ButtonsController.OnButton1Pressed -= Vibrat;
        ButtonsController.OnButton2Pressed -= Nazad;
        ButtonsController.OnButton3Pressed -= ScrollPunktUp;
        ButtonsController.OnButton4Pressed -= ScrollPunktDawn;

        ButtonsController.OnButton7Pressed  -= Vvod_1;
        ButtonsController.OnButton8Pressed  -= Vvod_2;
        ButtonsController.OnButton9Pressed  -= Vvod_3;
        ButtonsController.OnButton10Pressed -= Vvod_4;
        ButtonsController.OnButton11Pressed -= Vvod_5;
        ButtonsController.OnButton12Pressed -= Vvod_6;
        ButtonsController.OnButton13Pressed -= Vvod_7;
        ButtonsController.OnButton14Pressed -= Vvod_8;
        ButtonsController.OnButton15Pressed -= Vvod_9;
        ButtonsController.OnButton16Pressed -= Vvod_0;
        ButtonsController.OnButton17Pressed -= Vvod_star;
        ButtonsController.OnButton18Pressed -= Vvod_dies;
    }

    public void Started()
    {
        punkt = 0;
        UpdatePunkt(punkt);
        password.SetActive(false);
        passwordText.text = "";
    }
    // Start is called before the first frame update
    void Start()
    {
        //punkt = 0;
        //UpdatePunkt(punkt);
        //password.SetActive(false);
        //passwordText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Vibrat()   //
    {
        if (password.activeSelf == true && passwordText.text == passwordTrue)
        {
            DL.ShowTab(5);
        }
        if (punkt == 6)
        {
            password.SetActive(true);
        }
    }
    private void Nazad()
    {
        if (password.activeSelf == true)
        {
            password.SetActive(false);
            passwordText.text = "";
        }
        else
        {
            DL.ShowTab(3);
        }
    }

    private void Vvod(string cifra)
    {
        if (password.activeSelf == true)
        {
            passwordText.text += cifra;
        }
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
    private void Vvod_1()
    {
        Vvod("1");
    }
    private void Vvod_2()
    {
        Vvod("2");
    }
    private void Vvod_3()
    {
        Vvod("3");
    }
    private void Vvod_4()
    {
        Vvod("4");
    }
    private void Vvod_5()
    {
        Vvod("5");
    }
    private void Vvod_6()
    {
        Vvod("6");
    }
    private void Vvod_7()
    {
        Vvod("7");
    }
    private void Vvod_8()
    {
        Vvod("8");
    }
    private void Vvod_9()
    {
        Vvod("9");
    }
    private void Vvod_0()
    {
        Vvod("0");
    }
    private void Vvod_star()
    {
        Vvod("*");
    }
    private void Vvod_dies()
    {
        Vvod("#");
    }











}
