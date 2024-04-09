using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldingButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] UnityEvent OnClickEvent;
    [SerializeField] UnityEvent OnClickUpEvent;
    bool isPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnClickUpEvent?.Invoke();
        isPressed = false;
    }

    void Update()
    {
        if (isPressed) OnClickEvent?.Invoke();
    }
}
