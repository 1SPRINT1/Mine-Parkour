using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
   [SerializeField] private TouchHandler TH;
   [SerializeField] private MobileCameraLook _mobileCameraLook;

   private void Update()
   {
       _mobileCameraLook.LockAxis = TH.TouchDist;
   }
}
