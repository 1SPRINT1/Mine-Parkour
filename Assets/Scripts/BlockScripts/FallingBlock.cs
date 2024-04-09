using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{ 
    [Header("Parametrs")] 
   [SerializeField] private Rigidbody rb;
   [SerializeField] private bool isFall = false;
   [Space(10)]
   [Header("Timer")]
   private float startTimeBTW = 3f;
   [SerializeField] private float timeBTWshots;
   private void Start()
   {
       rb.isKinematic = true;
       timeBTWshots = startTimeBTW;
   }

   private void Update()
   {
       if (isFall == true)
       {
           timeBTWshots -= Time.deltaTime;
           if (timeBTWshots <= 0f)
           {
               rb.isKinematic = false;
           }
       }
   }

   private void OnCollisionEnter(Collision other)
   {
       if (other.gameObject.CompareTag("Player"))
       {
           isFall = true;
       }

       if (other.gameObject.CompareTag("GameOver"))
       {
           Destroy(gameObject);
       }
   }
}
