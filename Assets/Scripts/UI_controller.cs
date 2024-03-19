using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_controller : MonoBehaviour
{
    public GameObject uiPanel;
    private bool isUIActive = false; // ���� ��� ������������ ��������� UI

    // Start is called before the first frame update
    void Start()
    {
        isUIActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isUIActive)
            {
                uiPanel.SetActive(false);
                isUIActive = false;
            }
            else
            {
                uiPanel.SetActive(true);
                isUIActive = true;
            }
            // ���� ������ ������, �������� ��; ����� ����������
            //uiPanel.SetActive(!uiPanel.activeSelf);
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
