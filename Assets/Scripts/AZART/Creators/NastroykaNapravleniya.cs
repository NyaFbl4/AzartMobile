using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using R187_P1;

public class NastroykaNapravleniya : MonoBehaviour
{
    [SerializeField] private DisplaysLogic _DL;
    [SerializeField] private RedaktorNapravleniya _RN;

    [SerializeField] private GameObject[] _Elements;
    private int _punkt;

    [SerializeField] private int indexSimvola = 0;
    [SerializeField] private float[] lastClickTime = { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };

    private float clickDelay = 5f;

    [SerializeField] private TextMeshProUGUI _NameRejim;
    [SerializeField] private GameObject      _ZapretPPRD;
    [SerializeField] private GameObject      _TonVizov;
    [SerializeField] private TextMeshProUGUI _SpisokSkaniroovaniyaText;
    [SerializeField] private TextMeshProUGUI _EkanomaizerText;
    [SerializeField] private TextMeshProUGUI _Name;
    [SerializeField] private TextMeshProUGUI _BackgroundText;
    [SerializeField] private GameObject[]    _ImageBackground;

    private int _EkanomizerNomer;
    private int _BackgroundNumber;
    private bool _SpisokSkaniroovaniyaBool;

    private void OnEnable()
    {
        // Добавьте аналогичные подписки для остальных кнопок
        ButtonsController.OnButton1Pressed += BTN_1;
        ButtonsController.OnButton2Pressed += BTN_2;
        ButtonsController.OnButton3Pressed += ScrollPunktUp;
        ButtonsController.OnButton4Pressed += ScrollPunktDawn;

        ButtonsController.OnButton7Pressed += Vvod_1;
        ButtonsController.OnButton8Pressed += Vvod_2;
        ButtonsController.OnButton9Pressed += Vvod_3;
        ButtonsController.OnButton10Pressed += Vvod_4;
        ButtonsController.OnButton11Pressed += Vvod_5;
        ButtonsController.OnButton12Pressed += Vvod_6;
        ButtonsController.OnButton13Pressed += Vvod_7;
        ButtonsController.OnButton14Pressed += Vvod_8;
        ButtonsController.OnButton15Pressed += Vvod_9;
        ButtonsController.OnButton16Pressed += Vvod_0;
        ButtonsController.OnButton17Pressed += Vvod_star;
        ButtonsController.OnButton18Pressed += Vvod_dies;
    }
    private void OnDisable()

    {
        // Добавьте аналогичные отписки для остальных кнопок
        ButtonsController.OnButton1Pressed -= BTN_1;
        ButtonsController.OnButton2Pressed -= BTN_2;
        ButtonsController.OnButton3Pressed -= ScrollPunktUp;
        ButtonsController.OnButton4Pressed -= ScrollPunktDawn;

        ButtonsController.OnButton7Pressed -= Vvod_1;
        ButtonsController.OnButton8Pressed -= Vvod_2;
        ButtonsController.OnButton9Pressed -= Vvod_3;
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
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartNastroykaNapravleniy(NewKanal kanal)
    {
        _NameRejim.text = "";
        _NameRejim.text += kanal._NameKanala;
        _ZapretPPRD.SetActive(false);
        _TonVizov.SetActive(false);
        _SpisokSkaniroovaniyaText.text = "Нет";
        _EkanomaizerText.text = "0";
        _Name.text = "Направление 1";
    }

    private void FixedUpdate()
    {
        if (_Elements[0].activeSelf == true)
        {
            foreach (GameObject item in _RN._ElementsLowerRigth)
            {
                item.SetActive(false);
            }
            _RN._ElementsLowerRigth[0].SetActive(true);
        }
        else if (_Elements[5].activeSelf == true)
        {
            foreach (GameObject item in _RN._ElementsLowerRigth)
            {
                item.SetActive(false);
            }
            _RN._ElementsLowerRigth[3].SetActive(true);
        }
        else
        {
            foreach (GameObject item in _RN._ElementsLowerRigth)
            {
                item.SetActive(false);
            }
            _RN._ElementsLowerRigth[2].SetActive(true);
        }
    }

    private void BTN_1()
    {

    }
    private void BTN_2()
    {
        if (_Elements[1].activeSelf == true)
        {
            if (_ZapretPPRD.activeSelf == true)
            {
                _ZapretPPRD.SetActive(false);
            }
            else
            {
                _ZapretPPRD.SetActive(true);
            }
        }

        if (_Elements[2].activeSelf == true)
        {
            if (_TonVizov.activeSelf == true)
            {
                _TonVizov.SetActive(false);
            }
            else
            {
                _TonVizov.SetActive(true);
            }
        }

        if (_Elements[3].activeSelf == true)
        {
            if (_SpisokSkaniroovaniyaText.text == "да")
            {
                _SpisokSkaniroovaniyaText.text = "нет";
            }
            else if (_SpisokSkaniroovaniyaText.text == "нет")
            {
                _SpisokSkaniroovaniyaText.text = "да";
            }
        }

        if (_Elements[4].activeSelf == true)
        {
            _EkanomizerNomer++;
            if (_EkanomizerNomer > 5)
            {
                _EkanomizerNomer = 0;
            }

            _EkanomaizerText.text = _EkanomizerNomer.ToString();

            /*
            string originalText = _Name.text;
            string modifiedText = originalText.Substring(0, originalText.Length - 1);
            _Name.text = modifiedText;
            */
        }

        if (_Elements[5].activeSelf == true)
        {
            string originalText = _Name.text;
            string modifiedText = originalText.Substring(0, originalText.Length - 1);
            _Name.text = modifiedText;
        }

        if (_Elements[6].activeSelf == true)
        {
            _BackgroundNumber++;

            if (_BackgroundNumber == _ImageBackground.Length)
            {
                _BackgroundNumber = 0;
            }

            _BackgroundText.text = _BackgroundNumber.ToString();

            foreach (GameObject item in _ImageBackground)
            {
                item.SetActive(false);
            }
            _ImageBackground[_BackgroundNumber].SetActive(true);
        }
    }
    private void ScrollPunktUp()
    {
        _punkt = _DL.UpperPunktTest(_punkt, _Elements);
    }
    private void ScrollPunktDawn()
    {
        _punkt = _DL.DownPunktTest(_punkt, _Elements);
    }

    private void Vvod_1()
    {
        if (_Elements[5].activeSelf == true)
        {
            _Name.text += "1";
        }
    }
    private void Vvod_2()
    {
        string[] simvoli = { "А", "Б", "В", "2" };

        if (_Elements[5].activeSelf == true)
        {
            if (lastClickTime[1] == 0f || (Time.time - lastClickTime[1] > clickDelay))
            {
                Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[1] < clickDelay)
            {
                Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli[indexSimvola];
                _Name.text = modifiedText;
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }

            lastClickTime[0] = 0f;
            lastClickTime[1] = Time.time;
            lastClickTime[2] = 0f;
            lastClickTime[3] = 0f;
            lastClickTime[4] = 0f;
            lastClickTime[5] = 0f;
            lastClickTime[6] = 0f;
            lastClickTime[7] = 0f;
            lastClickTime[8] = 0f;
            lastClickTime[9] = 0f;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;
        }
    }
    private void Vvod_3()
    {
        string[] simvoli3 = { "Г", "Д", "Е", "Ё", "3" };

        if (_Elements[5].activeSelf == true)
        {
            if (lastClickTime[2] == 0f || (Time.time - lastClickTime[2] > clickDelay))
            {
                Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli3[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli3.Length;
            }
            else if (Time.time - lastClickTime[2] < clickDelay)
            {
                Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli3[indexSimvola];
                _Name.text = modifiedText;
                indexSimvola = (indexSimvola + 1) % simvoli3.Length;
            }

            lastClickTime[0] = 0f;
            lastClickTime[1] = 0f;
            lastClickTime[2] = Time.time;
            lastClickTime[3] = 0f;
            lastClickTime[4] = 0f;
            lastClickTime[5] = 0f;
            lastClickTime[6] = 0f;
            lastClickTime[7] = 0f;
            lastClickTime[8] = 0f;
            lastClickTime[9] = 0f;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;
        }
    }
    private void Vvod_4()
    {
        string[] simvoli = { "Ж", "З", "И", "Й", "4" };

        if (_Elements[5].activeSelf == true)
        {
            if (lastClickTime[3] == 0f || (Time.time - lastClickTime[3] > clickDelay))
            {
                Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[3] < clickDelay)
            {
                Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli[indexSimvola];
                _Name.text = modifiedText;
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }

            lastClickTime[0] = 0f;
            lastClickTime[1] = 0f;
            lastClickTime[2] = 0f;
            lastClickTime[3] = Time.time;
            lastClickTime[4] = 0f;
            lastClickTime[5] = 0f;
            lastClickTime[6] = 0f;
            lastClickTime[7] = 0f;
            lastClickTime[8] = 0f;
            lastClickTime[9] = 0f;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;
        }
    }
    private void Vvod_5()
    {
        string[] simvoli = { "К", "Л", "М", "Н", "5" };

        if (_Elements[5].activeSelf == true)
        {
            if (lastClickTime[4] == 0f || (Time.time - lastClickTime[4] > clickDelay))
            {
                Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[4] < clickDelay)
            {
                Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli[indexSimvola];
                _Name.text = modifiedText;
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }

            lastClickTime[0] = 0f;
            lastClickTime[1] = 0f;
            lastClickTime[2] = 0f;
            lastClickTime[3] = 0f;
            lastClickTime[4] = Time.time;
            lastClickTime[5] = 0f;
            lastClickTime[6] = 0f;
            lastClickTime[7] = 0f;
            lastClickTime[8] = 0f;
            lastClickTime[9] = 0f;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;
        }
    }
    private void Vvod_6()
    {
        string[] simvoli = { "О", "П", "Р", "С", "6" };

        if (_Elements[5].activeSelf == true)
        {
            if (lastClickTime[5] == 0f || (Time.time - lastClickTime[5] > clickDelay))
            {
                Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[5] < clickDelay)
            {
                Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli[indexSimvola];
                _Name.text = modifiedText;
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }

            lastClickTime[0] = 0f;
            lastClickTime[1] = 0f;
            lastClickTime[2] = 0f;
            lastClickTime[3] = 0f;
            lastClickTime[4] = 0f;
            lastClickTime[5] = Time.time;
            lastClickTime[6] = 0f;
            lastClickTime[7] = 0f;
            lastClickTime[8] = 0f;
            lastClickTime[9] = 0f;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;
        }
    }
    private void Vvod_7()
    {
        string[] simvoli = { "Т", "У", "Ф", "Ч", "7" };

        if (_Elements[5].activeSelf == true)
        {
            if (lastClickTime[6] == 0f || (Time.time - lastClickTime[6] > clickDelay))
            {
                Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[6] < clickDelay)
            {
                Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli[indexSimvola];
                _Name.text = modifiedText;
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }

            lastClickTime[0] = 0f;
            lastClickTime[1] = 0f;
            lastClickTime[2] = 0f;
            lastClickTime[3] = 0f;
            lastClickTime[4] = 0f;
            lastClickTime[5] = 0f;
            lastClickTime[6] = Time.time;
            lastClickTime[7] = 0f;
            lastClickTime[8] = 0f;
            lastClickTime[9] = 0f;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;
        }
    }
    private void Vvod_8()
    {
        string[] simvoli = { "Ц", "Ч", "Ш", "8" };

        if (_Elements[5].activeSelf == true)
        {
            if (lastClickTime[7] == 0f || (Time.time - lastClickTime[7] > clickDelay))
            {
                Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[7] < clickDelay)
            {
                Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli[indexSimvola];
                _Name.text = modifiedText;
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }

            lastClickTime[0] = 0f;
            lastClickTime[1] = 0f;
            lastClickTime[2] = 0f;
            lastClickTime[3] = 0f;
            lastClickTime[4] = 0f;
            lastClickTime[5] = 0f;
            lastClickTime[6] = 0f;
            lastClickTime[7] = Time.time;
            lastClickTime[8] = 0f;
            lastClickTime[9] = 0f;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;
        }
    }
    private void Vvod_9()
    {
        string[] simvoli = { "Щ", "Ъ", "Ы", "9" };

        if (_Elements[5].activeSelf == true)
        {
            if (lastClickTime[8] == 0f || (Time.time - lastClickTime[8] > clickDelay))
            {
                Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[8] < clickDelay)
            {
                Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli[indexSimvola];
                _Name.text = modifiedText;
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }

            lastClickTime[0] = 0f;
            lastClickTime[1] = 0f;
            lastClickTime[2] = 0f;
            lastClickTime[3] = 0f;
            lastClickTime[4] = 0f;
            lastClickTime[5] = 0f;
            lastClickTime[6] = 0f;
            lastClickTime[7] = 0f;
            lastClickTime[8] = Time.time;
            lastClickTime[9] = 0f;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;
        }
    }
    private void Vvod_0()
    {
        string[] simvoli = { "Ь", "Э", "Ю", "Я", "0" };

        if (_Elements[5].activeSelf == true)
        {
            if (lastClickTime[9] == 0f || (Time.time - lastClickTime[9] > clickDelay))
            {
                Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[9] < clickDelay)
            {
                Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli[indexSimvola];
                _Name.text = modifiedText;
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }

            lastClickTime[0] = 0f;
            lastClickTime[1] = 0f;
            lastClickTime[2] = 0f;
            lastClickTime[3] = 0f;
            lastClickTime[4] = 0f;
            lastClickTime[5] = 0f;
            lastClickTime[6] = 0f;
            lastClickTime[7] = 0f;
            lastClickTime[8] = 0f;
            lastClickTime[9] = Time.time;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;
        }
    }
    private void Vvod_star()
    {
        if (_Elements[5].activeSelf == true)
        {
            _Name.text += "*";
        }
    }
    private void Vvod_dies()
    {
        if (_Elements[5].activeSelf == true)
        {
            _Name.text += "#";
        }
    }
}
