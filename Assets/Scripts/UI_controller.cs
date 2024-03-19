using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_controller : MonoBehaviour
{
    public GameObject uiPanel;
    private bool isUIActive = false; // ‘лаг дл€ отслеживани€ состо€ни€ UI

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
            // ≈сли панель видима, скрываем ее; иначе отображаем
            //uiPanel.SetActive(!uiPanel.activeSelf);
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
