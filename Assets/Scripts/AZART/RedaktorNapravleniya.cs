using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using R187_P1;

public class RedaktorNapravleniya : MonoBehaviour, IStarted
{
    [SerializeField] private DisplaysLogic _DL;
    [SerializeField] private Container _C;
    [SerializeField] private NastroykaNapravleniya _NN;

    [SerializeField] private GameObject _VIborKanalov;
    [SerializeField] private GameObject _Defolt;
    [SerializeField] private GameObject _RedaktorNapravleniiya;
    [SerializeField] public GameObject[] ElementsViboraKanalov;

    [SerializeField] public GameObject[] _ElementsLowerLeft;
    [SerializeField] public GameObject[] _ElementsLowerRigth;

    private bool _blockButtons = false;
    private int _punktViboraKanalov;

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

    private void Start()
    {
        //StartRedaktorNapravleniya();
    }

    public void Started()
    {
        if (ElementsViboraKanalov.Length != 0)
        {
            _punktViboraKanalov = 1;
            _DL.UpperPunktTest(_punktViboraKanalov, ElementsViboraKanalov);
        }

        _blockButtons = false;
        _VIborKanalov.SetActive(false);
    }

    private void Update()
    {
        
    }

    private void BTN_1()   
    {
        if(_VIborKanalov.activeSelf == true)
        {
            _VIborKanalov.SetActive(false);
            _Defolt.SetActive(false);          
            _RedaktorNapravleniiya.SetActive(true);

            NewKanal kanal = _C.ReturnKanal(_punktViboraKanalov);

            _NN.StartNastroykaNapravleniy(kanal);

            _blockButtons = true;
        }
    }
    private void BTN_2()
    {
        if (_blockButtons == false)
        {
            if(_VIborKanalov.activeSelf == false)
            {
                _VIborKanalov.SetActive(true);
                _ElementsLowerLeft[0].SetActive(false);
                _ElementsLowerLeft[1].SetActive(true);

                foreach (GameObject item in _ElementsLowerRigth)
                {
                    item.SetActive(false);
                }
                _ElementsLowerRigth[1].SetActive(true);
            }
        }
    }
    private void ScrollPunktUp()
    {
        if (_VIborKanalov.activeSelf == true)
        {
            _punktViboraKanalov = _DL.UpperPunktTest(_punktViboraKanalov, ElementsViboraKanalov);
        }
    }
    private void ScrollPunktDawn()
    {
        if (_VIborKanalov.activeSelf == true)
        {
            _punktViboraKanalov = _DL.DownPunktTest(_punktViboraKanalov, ElementsViboraKanalov);
        }
    }

    private void ShowLitsKanalov()
    {

    }
}