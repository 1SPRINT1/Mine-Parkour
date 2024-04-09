using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveblePlatforms : MonoBehaviour
{
   [Header("Transforms")]
   public Transform targetPoint1;
   public Transform targetPoint2;
   public float speed = 5f;

   private bool movingToTarget1 = true;

   private void Update()
   {
       if (movingToTarget1)
       {
           transform.position = Vector3.MoveTowards(transform.position, targetPoint1.position, speed * Time.deltaTime);
           if (transform.position == targetPoint1.position)
           {
               movingToTarget1 = false;
           }
       }
       else
       {
           transform.position = Vector3.MoveTowards(transform.position, targetPoint2.position, speed * Time.deltaTime);
           if (transform.position == targetPoint2.position)
           {
               movingToTarget1 = true;
           }
       }
   }
}
