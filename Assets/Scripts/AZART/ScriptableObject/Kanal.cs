using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewKanal", menuName = "New Kanal")]
public class Kanal : ScriptableObject
{ 
    public enum RejimKanala
    {
        NeZadano,
        TetraDMO,
        TetraTMO,
        VPD,
        AM25,
        ChM25,
        ChM50,
        OBP,
        FmRadio
    }

    public RejimKanala Rejim;
    public bool ZapretPRD;
    public bool Dvuhchastotniy;
    public string Chastota;
    public string NameKanala;


}
