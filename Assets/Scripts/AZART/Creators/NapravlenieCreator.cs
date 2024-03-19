using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using R187_P1;

public class NapravlenieCreator : MonoBehaviour
{
    [SerializeField] private DisplaysLogic _DL;
    [SerializeField] private Creators _Creators;

    [SerializeField] private TextMeshProUGUI _NameRejim;
    [SerializeField] private GameObject _ZapretPPRD;
    [SerializeField] private GameObject _TonVizov;
    [SerializeField] private TextMeshProUGUI _SpisokSkaniroovaniyaText;
    [SerializeField] private TextMeshProUGUI _EkanomaizerText;
    [SerializeField] private TextMeshProUGUI _Name;
    [SerializeField] private TextMeshProUGUI _BackgroundText;
    [SerializeField] private GameObject[] _ImageBackground;

    private string _newNaimenovanieRejima;
    private bool _newZapretPRD;
    private bool _newTonVizov;
    private bool _newSpisokSkanirovaniya;
    private int _newEkanomaizer;

    private string _newNameNapravleniya;
    private int _newNomberBackground;



    private void OnEnable()
    {
        // Добавьте аналогичные подписки для остальных кнопок
        ButtonsController.OnButton1Pressed += Saved;
    }
    private void OnDisable()
    {
        // Добавьте аналогичные отписки для остальных кнопок
        ButtonsController.OnButton1Pressed -= Saved;
    }

    private void Saved()
    {
        SaveDannih();
        _Creators.CreateNewNapravlenie(_newNaimenovanieRejima, _newZapretPRD, _newTonVizov, 
                      _newSpisokSkanirovaniya, _newEkanomaizer, _newNameNapravleniya, _newNomberBackground);
        _DL.ShowTab(9);
    }

    private void SaveDannih()
    {
        _newNaimenovanieRejima = _NameRejim.text;

        if (_ZapretPPRD.activeSelf == false)
        {
            _newZapretPRD = false;
        }
        else
        {
            _newZapretPRD = true;
        }

        if (_TonVizov.activeSelf == false)
        {
            _newTonVizov = false;
        }
        else
        {
            _newTonVizov = true;
        }

        if (_SpisokSkaniroovaniyaText.text == "Нет")
        {
            _newSpisokSkanirovaniya = false;
        }
        else if (_SpisokSkaniroovaniyaText.text == "Да")
        {
            _newSpisokSkanirovaniya = true;
        }

        if (int.TryParse(_EkanomaizerText.text, out int result))
        {
            _newEkanomaizer = result;
        }

        _newNameNapravleniya = _Name.text;

        if (int.TryParse(_BackgroundText.text, out int result1))
        {
            _newNomberBackground = result1;
        }
    }
}
