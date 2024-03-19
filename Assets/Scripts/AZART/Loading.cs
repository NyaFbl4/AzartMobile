using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public GameObject[] Elements;

    public DisplaysLogic DL;
    public Config config;

    private void OnEnable()
    {
        foreach(GameObject obj in Elements)
        {
            obj.SetActive(false);
        }

        StartScript();

        config.SelectMode(0);
    }

    void Start()
    {
        
    }

    private void StartScript()
    {
        StartCoroutine("LoadingAZART");
    }

    IEnumerator LoadingAZART()
    {
        for (int i = 0; i < Elements.Length; i++)
        {
            yield return new WaitForSeconds(1f);
            Elements[i].gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(1f);

        DL.ShowTab(1);
    }
}
