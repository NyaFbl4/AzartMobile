using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class NastroykaAM25 : MonoBehaviour, IStarted
{
    [SerializeField] private DisplaysLogic _DL;
    [SerializeField] private RedaktorKanala _RK;

    [SerializeField] private GameObject[] _Elements;
    private int _punkt;

    [SerializeField] private int indexSimvola = 0;
    [SerializeField] private float[] lastClickTime = { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };

    private float clickDelay = 5f;

    [SerializeField] private GameObject _ChastotaText;
    [SerializeField] private GameObject _ZapretPPRD;
    [SerializeField] private GameObject _Dvuhchastotniy;
    [SerializeField] private TextMeshProUGUI _Chastota;
    [SerializeField] private TextMeshProUGUI _Name;

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

        Started();
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


    public void Started()
    {
        foreach (GameObject item in _RK._ElementsLowerLeft)
        {
            item.SetActive(false);
        }
        _RK._ElementsLowerLeft[0].SetActive(true);

        _punkt = 0;
        _punkt = _DL.UpperPunktTest(_punkt, _Elements);
        Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach (GameObject item in _RK._ElementsLowerLeft)
        {
            item.SetActive(false);
        }
        _RK._ElementsLowerLeft[0].SetActive(true);

        Clear();
        */
    }

    public void Clear()
    {
        _ZapretPPRD.SetActive(false);
        _Dvuhchastotniy.SetActive(false);
        _Chastota.text = "";
        _Name.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_Elements[2].activeSelf == true || _Elements[3].activeSelf == true)
        {
            foreach (GameObject item in _RK._ElementsLowerRigth)
            {
                item.SetActive(false);
            }
            _RK._ElementsLowerRigth[1].SetActive(true);
        }
        else
        {
            foreach (GameObject item in _RK._ElementsLowerRigth)
            {
                item.SetActive(false);
            }
            _RK._ElementsLowerRigth[0].SetActive(true);
        }

        if (_Elements[2].activeSelf == true)
        {
            _ChastotaText.SetActive(true);
        }
        else
        {
            _ChastotaText.SetActive(false);
        }
    }

    private void BTN_1()   
    {
    
    }
    private void BTN_2()
    {
        if (_Elements[0].activeSelf == true)
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

        if (_Elements[1].activeSelf == true)
        {
            if (_Dvuhchastotniy.activeSelf == true)
            {
                _Dvuhchastotniy.SetActive(false);
            }
            else
            {
                _Dvuhchastotniy.SetActive(true);
            }
        }

        if (_Elements[2].activeSelf)
        {
            string originalText = _Chastota.text;
            string modifiedText = originalText.Substring(0, originalText.Length - 1);
            _Chastota.text = modifiedText;
        }

        if (_Elements[3].activeSelf)
        {
            string originalText = _Name.text;
            string modifiedText = originalText.Substring(0, originalText.Length - 1);
            _Name.text = modifiedText;
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
        if (_Elements[2].activeSelf == true)
        {
            _Chastota.text += "1";
        }
    }
    private void Vvod_2()
    {
        string[] simvoli = { "А", "Б", "В", "2" };

        if (_Elements[2].activeSelf == true)
        {
            _Chastota.text += "2";
        }

        if (_Elements[3].activeSelf == true)
        {
            if (lastClickTime[1] == 0f || (Time.time - lastClickTime[1] > clickDelay))
            {
               // Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;              
            }
            else if (Time.time - lastClickTime[1] < clickDelay)
            {
                //Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli[indexSimvola]; 
                _Name.text = modifiedText; 
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }

            lastClickTime[0]  = 0f;
            lastClickTime[1]  = Time.time;
            lastClickTime[2]  = 0f;
            lastClickTime[3]  = 0f;
            lastClickTime[4]  = 0f;
            lastClickTime[5]  = 0f;
            lastClickTime[6]  = 0f;
            lastClickTime[7]  = 0f;
            lastClickTime[8]  = 0f;
            lastClickTime[9]  = 0f;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;          
        }
    }
    private void Vvod_3()
    {
        string[] simvoli3 = { "Г", "Д", "Е", "Ё", "3" };

        if (_Elements[2].activeSelf == true)
        {
            _Chastota.text += "3";
        }

        if (_Elements[3].activeSelf == true)
        {
            if(lastClickTime[2] == 0f || (Time.time - lastClickTime[2] > clickDelay))
            {
                //Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli3[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli3.Length;
            }
            else if (Time.time - lastClickTime[2] < clickDelay)
            {
                //Debug.Log("2 true");
                string originalText = _Name.text;
                string modifiedText = originalText.Substring(0, originalText.Length - 1) + simvoli3[indexSimvola];
                _Name.text = modifiedText;
                indexSimvola = (indexSimvola + 1) % simvoli3.Length;
            }

            lastClickTime[0]  = 0f;
            lastClickTime[1]  = 0f;
            lastClickTime[2]  = Time.time;
            lastClickTime[3]  = 0f;
            lastClickTime[4]  = 0f;
            lastClickTime[5]  = 0f;
            lastClickTime[6]  = 0f;
            lastClickTime[7]  = 0f;
            lastClickTime[8]  = 0f;
            lastClickTime[9]  = 0f;
            lastClickTime[10] = 0f;
            lastClickTime[11] = 0f;

            /* что-то тут не работает (вообще не ебу что)
            foreach (int i in lastClickTime)
            {
                lastClickTime[i] = 0f;
            }

            lastClickTime[2] = Time.time;
            
            if (lastClickTime3 == 0f || Time.time - lastClickTime3 > clickDelay)
            {
                indexSimvola3 = 0;
                _Name.text += simvoli3[indexSimvola3];
                indexSimvola3 = (indexSimvola2 + 1) % simvoli3.Length;
            }
            else if (Time.time - lastClickTime3 < clickDelay)
            {
                _Name.text = _Chastota.text.Remove(_Chastota.text.Length - 1, 1);
                _Name.text += simvoli3[indexSimvola3];  
                indexSimvola3 = (indexSimvola3 + 1) % simvoli3.Length;
            }

            
            foreach (int i in lastClickTime)
            {
                lastClickTime[i] = 0f;
            }
            

            lastClickTime3 = Time.time;
            */
        }
    }
    private void Vvod_4()
    {
        string[] simvoli = { "Ж", "З", "И", "Й", "4" };

        if (_Elements[2].activeSelf == true)
        {
            _Chastota.text += "4";
        }

        if (_Elements[3].activeSelf == true)
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

        if (_Elements[2].activeSelf == true)
        {
            _Chastota.text += "5";
        }

        if (_Elements[3].activeSelf == true)
        {
            if (lastClickTime[4] == 0f || (Time.time - lastClickTime[4] > clickDelay))
            {
                //Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[4] < clickDelay)
            {
                //Debug.Log("2 true");
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

        if (_Elements[2].activeSelf == true)
        {
            _Chastota.text += "6";
        }

        if (_Elements[3].activeSelf == true)
        {
            if (lastClickTime[5] == 0f || (Time.time - lastClickTime[5] > clickDelay))
            {
                //Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[5] < clickDelay)
            {
                //Debug.Log("2 true");
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

        if (_Elements[2].activeSelf == true)
        {
            _Chastota.text += "7";
        }

        if (_Elements[3].activeSelf == true)
        {
            if (lastClickTime[6] == 0f || (Time.time - lastClickTime[6] > clickDelay))
            {
                //Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[6] < clickDelay)
            {
                //Debug.Log("2 true");
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

        if (_Elements[2].activeSelf == true)
        {
            _Chastota.text += "8";
        }

        if (_Elements[3].activeSelf == true)
        {
            if (lastClickTime[7] == 0f || (Time.time - lastClickTime[7] > clickDelay))
            {
               // Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[7] < clickDelay)
            {
                //Debug.Log("2 true");
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

        if (_Elements[2].activeSelf == true)
        {
            _Chastota.text += "9";
        }

        if (_Elements[3].activeSelf == true)
        {
            if (lastClickTime[8] == 0f || (Time.time - lastClickTime[8] > clickDelay))
            {
                //Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[8] < clickDelay)
            {
                //Debug.Log("2 true");
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

        if (_Elements[2].activeSelf == true)
        {
            _Chastota.text += "0";
        }

        if (_Elements[3].activeSelf == true)
        {
            if (lastClickTime[9] == 0f || (Time.time - lastClickTime[9] > clickDelay))
            {
               // Debug.Log("1 true");
                indexSimvola = 0;
                _Name.text += simvoli[indexSimvola];
                indexSimvola = (indexSimvola + 1) % simvoli.Length;
            }
            else if (Time.time - lastClickTime[9] < clickDelay)
            {
                //Debug.Log("2 true");
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
        if (_Elements[3].activeSelf == true)
        {
            _Name.text += "*";
        }
    }
    private void Vvod_dies()
    {
        if (_Elements[3].activeSelf == true)
        {
            _Name.text += "#";
        }
    }
}
