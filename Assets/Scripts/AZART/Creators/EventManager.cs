using UnityEngine;
using System;

public static class EventManager
{
    //public static event Action<NewKanal> NewKanalCreated;
    //public static event EventHandler<NewKanalEventArgs> NewKanalCreated;
    //public delegate NewKanal NewKanalDelegate();
    //public event NewKanalDelegate MyDeleg;

    //public static EventManager instance;
    //public event Action<NewKanal> OnInstanceCreated;

    public static void OnNewKanalCreated()
    {
        //OnInstanceCreated?.Invoke(this);
        //NewKanalCreated?.Invoke(NewKanal);
        //NewKanalCreated?.Invoke();
    }
}
