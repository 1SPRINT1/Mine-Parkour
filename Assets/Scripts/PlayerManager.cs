using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.iOS;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    private Color platformRenderer;
    [SerializeField] private GameObject Effect1;
    [SerializeField] private GameObject Effect2;
    [SerializeField] private GameObject FinishEffects;
    [Space(20)]
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private float xForce;
    [SerializeField] private GameObject StartPosition;
    [SerializeField] private GameObject GameCompletePanels;
    [SerializeField] private GameObject MobilePanel;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip ExplossionAudio, WinAudio;
    FirstPersonController fpc;
    private void Start()
    {
        fpc = GetComponent<FirstPersonController>();
        fpc.Mobile = Application.isMobilePlatform;
        if (fpc.Mobile)
        {
            MobilePanel.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Instantiate(Effect1, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(ExplossionAudio);
        }

        if (other.gameObject.CompareTag("Trampoline"))
        {
            playerRB.AddForce(0f,xForce,0f);
            platformRenderer = GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
            Instantiate(Effect2, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(ExplossionAudio);
        }

        if (other.gameObject.CompareTag("GameOver"))
        {
            transform.position = StartPosition.transform.position;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            GameCompletePanels.SetActive(true);
            fpc.playerCanMove = false;
            fpc.cameraCanMove = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            audioSource.PlayOneShot(WinAudio);
            Instantiate(FinishEffects, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag.Equals("MovingPlatform"))
        {
            this.transform.parent = other.transform;
        } 
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag.Equals("MovingPlatform"))
        {
            this.transform.parent = null;
        } 
    }
}
