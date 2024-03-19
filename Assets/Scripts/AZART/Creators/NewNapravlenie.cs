using UnityEngine;

namespace R187_P1
{
    [System.Serializable]
    public class NewNapravlenie 
    {
        public delegate void KanalCreatedEventHandler(NewNapravlenie napravlenie);
        public static event KanalCreatedEventHandler NapravlenieCreated;

        public string _NaimenovanieRejima;
        public bool _ZapretPRD;
        public bool _TonVizov;
        public bool _SpisokSkanirovaniya;
        public int _Ekanomaizer;
        public string _NameNapravleniya;
        public int _NomberBackground;

        public NewNapravlenie(string naimenovanieRejima, bool zapretPRD, bool tonVizov, bool spisokSkanirovaniya,
                              int ekanomaizer, string nameNapravleniya, int nomberBackground)
        {
            _NaimenovanieRejima = naimenovanieRejima;
            _ZapretPRD = zapretPRD;
            _TonVizov = tonVizov;
            _SpisokSkanirovaniya = spisokSkanirovaniya;
            _Ekanomaizer = ekanomaizer;
            _NameNapravleniya = nameNapravleniya;
            _NomberBackground = nomberBackground;

            NapravlenieCreated?.Invoke(this);
            Debug.Log("создано направление");
        }
    }
}
