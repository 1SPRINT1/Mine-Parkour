using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour , IPointerDownHandler , IPointerUpHandler
{
   [HideInInspector] public Vector2 TouchDist;
   [HideInInspector] public Vector2 PointerOld;
   [HideInInspector] protected int PointerID;
   [HideInInspector] public bool Pressed;

   private void Update()
   {
      if (Pressed)
      {
         if (PointerID >= 0 && PointerID < Input.touches.Length)
         {
            TouchDist = Input.touches[PointerID].position - PointerOld;
            PointerOld = Input.touches[PointerID].position;
         }
         else
         {
            TouchDist = new Vector2(Input.mousePosition.x,Input.mousePosition.y) - PointerOld;
            PointerOld = Input.mousePosition;
         }
      }
      else
      {
         TouchDist = new Vector2();
      }
   }

   public void OnPointerDown(PointerEventData eventData)
   {
      Pressed = true;
      PointerID = eventData.pointerId;
      PointerOld = eventData.position;
   }

   public void OnPointerUp(PointerEventData eventData)
   {
      Pressed = false;
   }
}
