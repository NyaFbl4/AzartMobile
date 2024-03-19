using UnityEngine;
using System;


namespace R187_P1
{
    [System.Serializable]
    public class NewKanal
        //public class NewKanal : MonoBehaviour
    {
        public delegate void KanalCreatedEventHandler(NewKanal kanal);
        public static event KanalCreatedEventHandler KanalCreated;

        //public static event Action<NewKanal> OnNewKanalCreated;

        public RejimKanala _Rejim;
        public bool _ZapretPRD;
        public bool _Dvuhchastotniy;
        public int _Chastota;
        public string _NameKanala;

        public NewKanal(RejimKanala rejim, bool zapretPRD, bool dvuhchastotniy, int chastota, string nameKanala)
        {
            _Rejim = rejim;
            _ZapretPRD = zapretPRD;
            _Dvuhchastotniy = dvuhchastotniy;
            _Chastota = chastota;
            _NameKanala = nameKanala;

            //OnNewKanalCreated1?.Invoke(this);
            KanalCreated?.Invoke(this);
            Debug.Log("создан канал");
        }
    }

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
}
