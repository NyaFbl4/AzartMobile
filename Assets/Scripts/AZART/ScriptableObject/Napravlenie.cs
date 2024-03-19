using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Napravlenie", menuName = "New Napravlenie")]
public class Napravlenie : ScriptableObject
{
    public GameObject Kanal;
    public bool ZapretPRD;
    public bool TonVizov;
    public bool SpisokSkanirovaniya;
    public int Ekanomaizer;
    public string NameNapravleniya;
    public Image ImageBackground;
    public int NumberImageBackground;
}
