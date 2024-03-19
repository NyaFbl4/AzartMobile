using UnityEngine;

[System.Serializable]
public class Config : MonoBehaviour
{
    public string DejPriyem = "";
    public string OtkrRejim = "";
    public string Naimenovanie = "";
    public string RejimNiz = "";
    public string Error = "";
    public bool LvlAkb = false;
    public bool Akb_L = false;
    public bool Akb_R = false;
    public bool Antenna = false;

    private string _newDejPriyem = "";
    private string _newOtkrRejim = "Открытый режим";
    private string _newNaimenovanie = "";
    private string _newRejimNiz = "Idle";
    private string _newError = "";
    private bool _newLvlAkb = true;
    private bool _newAkb_L = true;
    private bool _newAkb_R = false;
    private bool _newAntenna = false;

    public void SelectMode(int selectMode)
    {
        switch (selectMode)
        {
            case 0:
                DejPriyem = _newDejPriyem;
                OtkrRejim = _newOtkrRejim;
                Naimenovanie = _newNaimenovanie;
                RejimNiz = _newRejimNiz;
                Error = _newError;
                LvlAkb = _newLvlAkb;
                Akb_L = _newAkb_L;
                Akb_R = _newAkb_R;
                Antenna = _newAntenna;
                break;

            case 1:
                DejPriyem = "";
                OtkrRejim = "";
                Naimenovanie = "";
                RejimNiz = "";
                Error = "Ошибка загрузки данных";
                LvlAkb = false;
                Akb_L = false;
                Akb_R = false;
                Antenna = false; 
                break;
        }
    }

    public void AddNewDannie(string newDejPriyem, string newOtkrRejim, string newNaimenovanie, string newRejimNiz, 
                             string newError, bool newLvlAkb, bool newAkb_L, bool newAkb_R, bool newAntenna)
    {
        _newDejPriyem = newDejPriyem;
        _newOtkrRejim = newOtkrRejim;
        _newNaimenovanie = newNaimenovanie;
        _newRejimNiz = newRejimNiz;
        _newError = newError;
        _newLvlAkb = newLvlAkb;
        _newAkb_L = newAkb_L;
        _newAkb_R = newAkb_R;
        _newAntenna = newAntenna;
    }
}
