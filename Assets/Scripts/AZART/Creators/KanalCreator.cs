using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using R187_P1;
//using static Kanal;

public class KanalCreator : MonoBehaviour
{
    //public static event Action<NewKanal> OnNewKanalCreated; 

    [SerializeField] private DisplaysLogic _DL;
    [SerializeField] private Container _container;
    [SerializeField] private SpisokKanalov _SK;
    [SerializeField] private Creators _Creators;

    //public GameObject kanalSvyaziPrefab;

    [SerializeField] private Transform parentObject;
    [SerializeField] private GameObject newKanalSvyaziPrefab;

    [SerializeField] private GameObject _prefabDlyaMenuNapravleniy;
    [SerializeField] private Transform KudaSummonitObject;

    //[SerializeField] public List<NewKanal> newChannelList = new List<NewKanal>();

    [SerializeField] private TextMeshProUGUI _Rejim;
    [SerializeField] private GameObject _ZapretPPRD;
    [SerializeField] private GameObject _Dvuhchastotniy;  
    [SerializeField] private TextMeshProUGUI _Chastota;
    [SerializeField] private TextMeshProUGUI _Name;
    
    private RejimKanala _newRejim;
    private bool _newZapretPRD;
    private bool _newDvuhchastotniy;
    private int _newChastota;
    private string _newNameKanala;  

    //private string _newNameKanal = "New Kanal";

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
        if (_Rejim.text == "AM25")
        {
            _newRejim = RejimKanala.AM25;
        }

        SaveDannih();
        _Creators.CreateNewKanal(_newRejim, _newZapretPRD, 
                                    _newDvuhchastotniy, _newChastota, _newNameKanala);
        _DL.ShowTab(11);
    }

    private void SaveDannih()
    {
        if (_Rejim.text == "AM25")
        {
            _newRejim = RejimKanala.AM25;
            Debug.Log("режим канала " + _newRejim);

            if (_ZapretPPRD.activeSelf == true)
            {
                _newZapretPRD = false;
                Debug.Log("запрет ПРД " + _newZapretPRD);
            }

            if (_Dvuhchastotniy.activeSelf == true)
            {
                _newDvuhchastotniy = false;
                Debug.Log("двухчастотный " + _newDvuhchastotniy);
            }

            if (int.TryParse(_Chastota.text, out int result))
            {
                _newChastota = result;
                Debug.Log("частота " + _newChastota);
            }

            _newNameKanala = _Name.text;
            Debug.Log("имя канала " + _newNameKanala);
        }
    }

    public void CreateNewKanal()
    {            
        NewKanal newKanal1 = new NewKanal(_newRejim, _newZapretPRD, 
                                    _newDvuhchastotniy, _newChastota, _newNameKanala);
    }

    private void AddNewItemToContainer(string text)
    {
        GameObject newObject = Instantiate(newKanalSvyaziPrefab, parentObject);
        TextMeshPro textComponent = newObject.GetComponentInChildren<TextMeshPro>();
        textComponent.text = "";
        textComponent.text = text;
    }

    private void AddNewNapravlenie(NewKanal kanal)
    {
        GameObject newObject = Instantiate(_prefabDlyaMenuNapravleniy, parentObject);
        TextMeshPro textComponent = newObject.GetComponentInChildren<TextMeshPro>();
        textComponent.text = "";
        textComponent.text = kanal._NameKanala;
    }
}
