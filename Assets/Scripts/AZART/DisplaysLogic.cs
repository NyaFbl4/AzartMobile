using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplaysLogic : MonoBehaviour
{
    [SerializeField] private bool WorkAzart = false;

    public GameObject[] tabs;             // ������ �������
    public int currentPunkt = 0;          // ����� ������

    public GameObject[] MassivKanalov;

    private void StartAzart()
    {

    }

    void Start()
    {

    }
    private void Update()
    {
        
    }

    public void LoadingAzart()            // �������� ������������
    {                                     // ������� ���������� ������ 
        if (WorkAzart == false)
        {
            tabs[0].gameObject.SetActive(true);
            WorkAzart = true;
        }
        else if (WorkAzart == true)
        {
            foreach (GameObject tab in tabs)
            {
                tab.SetActive(false);
            }
            WorkAzart = false;
        }
    }

    public void ShowTab(int index)
    {
       // Debug.Log("����������� ������� " + index);
        // ������ ��� �������
        foreach (GameObject tab in tabs)
        {
            tab.SetActive(false);
        }

        tabs[index].SetActive(true);
        //Debug.Log("tabs(�������) " + index);
    }

    // ���� �������� �������
    public int CheckNomberInMassiv(int index, GameObject[] massiv)
    {
        if (index < 0)
        {
            index = massiv.Length - 1;
            //Debug.Log("����� ����� ������ 0");
        }
        else if (index == massiv.Length)
        {
            index = 0;
            //Debug.Log("����� ����� ������ ����.��������");
        }

        return index;
    }

    public void UpdatePunkt(int i, GameObject[] massiv)
    {
        foreach (GameObject tab in massiv)
        {
            tab.SetActive(false);
        }

        massiv[i].SetActive(true);
        //Debug.Log("currentPunkt(�����) " + i);
    }

    public int UpperPunktTest(int i, GameObject[] massiv)
    {
        i--;

        if (i < 0)
        {
            i = massiv.Length - 1;
            //Debug.Log("����� ����� ������ 0");
        }
        else if (i == massiv.Length)
        {
            i = 0;
            //Debug.Log("����� ����� ������ ����.��������");
        }

        foreach (GameObject tab in massiv)
        {
            tab.SetActive(false);
        }

        massiv[i].SetActive(true);
        //Debug.Log("currentPunkt(�����) " + i);

        return i;
    }

    public int DownPunktTest(int i, GameObject[] massiv)
    {
        i++;

        if (i < 0)
        {
            i = massiv.Length - 1;
           // Debug.Log("����� ����� ������ 0");
        }
        else if (i == massiv.Length)
        {
            i = 0;
            //Debug.Log("����� ����� ������ ����.��������");
        }
        else if (i == 0)
        {
            i = 0;
        }

        foreach (GameObject tab in massiv)
        {
            tab.SetActive(false);
        }

        massiv[i].SetActive(true);
        //Debug.Log("currentPunkt(�����) " + i);

        return i;
    }
}
