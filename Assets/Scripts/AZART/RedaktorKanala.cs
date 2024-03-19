using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class RedaktorKanala : MonoBehaviour, IStarted
{
    [SerializeField] private DisplaysLogic _DL;

    [SerializeField] private GameObject   _menuRejimov;
    [SerializeField] private GameObject[] _ElementsMenuRejimov;

    [SerializeField] private TextMeshProUGUI _NameRejima;

    [SerializeField] public GameObject[]  _ElementsLowerLeft;
    [SerializeField] public GameObject[]  _ElementsLowerRigth;

    [SerializeField] private GameObject _AM25;

    private int _punktMenuRejimov;
    private bool _blockButtons = false;

    private void OnEnable()
    {
        // Добавьте аналогичные подписки для остальных кнопок
        ButtonsController.OnButton1Pressed += BTN_1;
        ButtonsController.OnButton2Pressed += BTN_2;
        ButtonsController.OnButton3Pressed += ScrollPunktUp;
        ButtonsController.OnButton4Pressed += ScrollPunktDawn;

        Started();
    }
    private void OnDisable()
    {
        // Добавьте аналогичные отписки для остальных кнопок
        ButtonsController.OnButton1Pressed -= BTN_1;
        ButtonsController.OnButton2Pressed -= BTN_2;
        ButtonsController.OnButton3Pressed -= ScrollPunktUp;
        ButtonsController.OnButton4Pressed -= ScrollPunktDawn;
    }
    public void Started()
    {
        _punktMenuRejimov = 1;
        _DL.UpperPunktTest(_punktMenuRejimov, _ElementsMenuRejimov);
        _blockButtons = false;
        _AM25.SetActive(false);
    }
    void Start()
    {
        /*Debug.Log("START");

        _punktMenuRejimov = 1;
        _DL.UpperPunktTest(_punktMenuRejimov, _ElementsMenuRejimov);
        _blockButtons = false;
        _AM25.SetActive(false);
        */
    }

    private void BTN_1()   //
    {
        if (_blockButtons == false)
        {
            if (_menuRejimov.activeSelf == true && _ElementsMenuRejimov[4].activeSelf == true)
            {
                _NameRejima.text = "AM25";
                _menuRejimov.SetActive(false);
                _AM25.SetActive(true);
                //_AM25.Clear();
                _blockButtons = true;
            }
        }
    }
    private void BTN_2()
    {
        if (_blockButtons == false)
        {
            if (_menuRejimov.activeSelf == false)
            {
                _menuRejimov.SetActive(true);
                _ElementsLowerLeft[0].SetActive(false);
                _ElementsLowerLeft[1].SetActive(true);

                foreach (GameObject item in _ElementsLowerRigth)
                {
                    item.SetActive(false);
                }
                _ElementsLowerRigth[2].SetActive(true);
            }
            else
            {
                _menuRejimov.SetActive(false);
                foreach (GameObject item in _ElementsLowerRigth)
                {
                    item.SetActive(false);
                }

                foreach (GameObject item in _ElementsLowerRigth)
                {
                    item.SetActive(false);
                }
                _ElementsLowerRigth[0].SetActive(true);

                _blockButtons = false;
            }
        }
    }
    private void ScrollPunktUp()
    {
        if (_menuRejimov.activeSelf == true)
        {
            _punktMenuRejimov = _DL.UpperPunktTest(_punktMenuRejimov, _ElementsMenuRejimov);
        }
    }
    private void ScrollPunktDawn()
    {
        if (_menuRejimov.activeSelf == true)
        {
            _punktMenuRejimov = _DL.DownPunktTest(_punktMenuRejimov, _ElementsMenuRejimov);
        }
    }
}

/*
private KanalCreator _kanalCreator;

[SerializeField] private DisplaysLogic _DL;
[SerializeField] private GameObject[] _Elements;

[SerializeField] private GameObject _menuRejimov;
[SerializeField] private GameObject[] _ElementsMenuRejimov;

[SerializeField] private GameObject[] _ElementsLowerLeft;
[SerializeField] private GameObject[] _ElementsLowerRigth;

public bool _rejimVibran = false;

private int _punkt;
private int _punktMenuRejimov;

private void Start()
{
_kanalCreator = GetComponent<KanalCreator>();

_punkt = 0;
_DL.UpdatePunkt(_punkt, _Elements);

_punktMenuRejimov = 0;
_DL.UpperPunktTest(_punktMenuRejimov, _ElementsMenuRejimov);
_menuRejimov.SetActive(false);
}
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

private void Vvod(string simvol)
{

}

private void Vibrat()   //
{
Debug.Log("создание канала");
//_kanalCreator.CreateNewKanal();
/*Kanal newKanal1 = creator.CreateNewKanal("kanal1");
nameKanala = "123";
Kanal NewKanal1 = ScriptableObject.CreateInstance<Kanal>();
AssetDatabase.CreateAsset(NewKanal1, "Assets/Resources/Objects/Kanali/" + nameKanala + ".asset");
AssetDatabase.SaveAssets();

Kanal NewKanal2 = ScriptableObject.CreateInstance<Kanal>();
nameKanala = "321";
AssetDatabase.CreateAsset(NewKanal2, "Assets/Resources/Objects/Kanali/" + nameKanala + ".asset");
AssetDatabase.SaveAssets();



}
private void Nazad()
{
if (_menuRejimov.activeSelf == false)
{
    _menuRejimov.SetActive(true);
    _ElementsLowerLeft[0].SetActive(false);
    _ElementsLowerLeft[1].SetActive(true);

    _ElementsLowerRigth[0].SetActive(false);
    _ElementsLowerRigth[2].SetActive(true);
}
else if (_menuRejimov.activeSelf == true)
{
    _menuRejimov.SetActive(false);
    _ElementsLowerLeft[1].SetActive(false);
    _ElementsLowerLeft[0].SetActive(true);

    _ElementsLowerRigth[2].SetActive(false);
    _ElementsLowerRigth[0].SetActive(true);
}
}
private void ScrollPunktUp()
{
if (_menuRejimov.activeSelf == false)
{
    _punkt = _DL.UpperPunktTest(_punkt, _Elements);
}
else
{
    _punkt = _DL.UpperPunktTest(_punktMenuRejimov, _ElementsMenuRejimov);
}
}
private void ScrollPunktDawn()
{
if (_menuRejimov.activeSelf == false)
{
    _punkt = _DL.DownPunktTest(_punkt, _Elements);
}
else
{
    _punkt = _DL.DownPunktTest(_punktMenuRejimov, _ElementsMenuRejimov);
}
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
*/