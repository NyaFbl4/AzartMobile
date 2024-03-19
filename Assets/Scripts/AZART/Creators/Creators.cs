using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using R187_P1;

public class Creators : MonoBehaviour
{
    [SerializeField] private Container _container;
    [SerializeField] private SpisokKanalov _SK;
    //�������� ������ ������
    public void CreateNewKanal(RejimKanala _newRejim, bool _newZapretPRD, 
                               bool _newDvuhchastotniy, int _newChastota, string _newNameKanala)
    {
        NewKanal newKanal = new NewKanal(_newRejim, _newZapretPRD, _newDvuhchastotniy, 
                                          _newChastota, _newNameKanala);        
    }
    public GameObject CreatePrefabNewKanalOnTransform(NewKanal newKanal, GameObject prefab, Transform mestoPrefaba)
    {
        GameObject newObject = Instantiate(prefab, mestoPrefaba);// �������� (�������, ��� �������);

        TextMeshProUGUI textComponent = newObject.GetComponentInChildren<TextMeshProUGUI>();
        textComponent.text = "";
        textComponent.text = newKanal._NameKanala;

        Debug.Log("�������� ������ " + prefab + " � " + mestoPrefaba);
        return newObject;
    }

    public GameObject[] AddGameObjectInArray(GameObject NewObject, GameObject[] massivObjectov)
    {
        GameObject childObject = NewObject.transform.Find("Image").gameObject;

        GameObject[] newArray = new GameObject[massivObjectov.Length + 1]; // ������� ����� ������ � ����������� ������
        for (int i = 0; i < massivObjectov.Length; i++)
        {
            newArray[i] = massivObjectov[i]; // �������� �������� �� ������� ������� � �����
        }
        newArray[newArray.Length - 1] = childObject; // ��������� ����� ������� � ����� ������
        massivObjectov = newArray; // ����������� ����� ������

        return massivObjectov;
    }
    //�������� ������ �����������
    public void CreateNewNapravlenie(string naimenovanieRejima, bool zapretPRD, bool tonVizov, bool spisokSkanirovaniya,
                          int ekanomaizer, string nameNapravleniya, int nomberBackground)
    {
        NewNapravlenie newNapravlenie = new NewNapravlenie(naimenovanieRejima, zapretPRD, tonVizov,
                                        spisokSkanirovaniya, ekanomaizer, nameNapravleniya, nomberBackground);
    }

    public GameObject CreatePrefabNewNapravleniyaOnTransform(NewNapravlenie newNapravlenie, 
                                        int nomerBackgroud, GameObject prefab, Transform mestoPrefaba)
    {
        GameObject newObject = Instantiate(prefab, mestoPrefaba);// �������� (�������, ��� �������);


        //TextMeshProUGUI text1 = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI textComponent = newObject.GetComponentInChildren<TextMeshProUGUI>();
        //TextMeshProUGUI textComponent = prefab.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        textComponent.text = "";
        textComponent.text = newNapravlenie._NameNapravleniya;

        TextMeshProUGUI text2 = prefab.transform.Find("Rejim").GetComponent<TextMeshProUGUI>();
        text2.text = "";
        text2.text = newNapravlenie._NaimenovanieRejima;

        //GameObject background = prefab.transform.Find(nomerBackgroud.ToString());
        //prefab.transform.GetChild(nomerBackgroud).gameObject.SetActive(true);
        //background.SetActive(true);

        //prefab.transform.GetChild(nomerBackgroud).gameObject.SetActive(true);

        Debug.Log("�������� ������ " + prefab + " � " + mestoPrefaba);
        return newObject;
    }
}
