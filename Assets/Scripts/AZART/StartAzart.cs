using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StartAzart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPointerDown = false;
    private float pointerDownTime = 0f;


    public float longPressDuration = 2f;
    public UnityEvent onLongPress;



    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        pointerDownTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }

    private void Update()
    {
        if (isPointerDown && Time.time - pointerDownTime > longPressDuration)
        {
            onLongPress.Invoke();
            isPointerDown = false; // Останавливаем вызов, чтобы событие на кнопке не вызывалось каждый кадр
        }
    }
}
