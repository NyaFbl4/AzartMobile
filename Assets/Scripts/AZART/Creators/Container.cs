using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R187_P1;

public class Container : MonoBehaviour
{
    //public GameObject[] MassivKanalov;

    [SerializeField] public List<NewKanal>        ContainerKanalov     = new List<NewKanal>();
    [SerializeField] private List<NewNapravlenie> ContainerNapravleniy = new List<NewNapravlenie>();
    [SerializeField] private Creators _creators;
    [SerializeField] private SpisokKanalov _SK;
    [SerializeField] private SpisokNapravleniy _SN;
    [SerializeField] private RedaktorNapravleniya _RN;

    private GameObject newGameObject;

    [Header("Префаб нового канала и место его создания в списке каналов")]
    [SerializeField] private Transform parentObjectSpiskaKanala;
    [SerializeField] private GameObject newKanalSvyaziPrefab;

    [Header("Префаб нового канала и место его создания в редакторе направлений")]
    [SerializeField] private Transform parentObjectViboraKanala;
    [SerializeField] private GameObject newKanalSvyaziViboraKanalaPrefab;

    [Header("Префаб нового напрачления и место его создания в списке направлений")]
    [SerializeField] private Transform parentObjectSpisokNapravleniya;
    [SerializeField] private GameObject newNapravlenielSvyaziSpiskaKanalovPrefab;

    public Config config;

    public List<NewKanal> AddListKanalov()
    {
        //newList = new List<NewKanal>(ContainerKanalov);
        Debug.Log("Перенесли в лист");
        return ContainerKanalov;
    }
    private void OnEnable()
    {
        NewKanal.KanalCreated += OnNewKanalCreated;
        NewNapravlenie.NapravlenieCreated += OnNewNapravlenieCreated;
    }
    private void OnDisable()
    {
        NewKanal.KanalCreated -= OnNewKanalCreated;
        NewNapravlenie.NapravlenieCreated -= OnNewNapravlenieCreated;
    }

    public NewKanal ReturnKanal(int index)
    {
        if (index >= 0 && index < ContainerKanalov.Count)
        {
            return ContainerKanalov[index];
        }
        else
        {
            return null; // Возвращайте null, если список пуст
        }
    }

    private void OnNewKanalCreated(NewKanal newKanal)
    {
        ContainerKanalov.Add(newKanal);

        newGameObject = _creators.CreatePrefabNewKanalOnTransform(newKanal, newKanalSvyaziPrefab, parentObjectSpiskaKanala);
        _SK.ElementsMassivaKanalov = _creators.AddGameObjectInArray(newGameObject, _SK.ElementsMassivaKanalov);

        newGameObject = _creators.CreatePrefabNewKanalOnTransform(newKanal, newKanalSvyaziViboraKanalaPrefab, parentObjectViboraKanala);
        _RN.ElementsViboraKanalov = _creators.AddGameObjectInArray(newGameObject, _RN.ElementsViboraKanalov);         
    }

    private void OnNewNapravlenieCreated(NewNapravlenie newNapravlenie) 
    {
        ContainerNapravleniy.Add(newNapravlenie);

        newGameObject = _creators.CreatePrefabNewNapravleniyaOnTransform(newNapravlenie, 
            newNapravlenie._NomberBackground, newNapravlenielSvyaziSpiskaKanalovPrefab, parentObjectSpisokNapravleniya);
        _SN.Elements = _creators.AddGameObjectInArray(newGameObject, _SN.Elements);

        //config.AddNewDannie(newNapravlenie._NaimenovanieRejima, newNapravlenie.);

        config.AddNewDannie("Дежурный прием", "Открытый режим", newNapravlenie._NaimenovanieRejima,
            newNapravlenie._NameNapravleniya, "", true, true, true, true);
        config.SelectMode(1);
    }
}
