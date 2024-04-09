using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCameraLook : MonoBehaviour
{
   private float XMove;
   private float YMove;
   private float XRotation;
   [SerializeField] private Transform PlayerBody;
   public Vector2 LockAxis;

   private void Update()
   {
      XMove = LockAxis.x;
      YMove = LockAxis.y;
      XRotation -= YMove;
      XRotation = Mathf.Clamp(XRotation, -90f, 90f);
      transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
      PlayerBody.Rotate(Vector3.up * XMove);
   }
}
