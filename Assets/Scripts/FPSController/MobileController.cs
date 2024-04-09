using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MobileController : MonoBehaviour
{
    [Space(10)] 
    [Header("Move-Info-Mobile")] 
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speedMove;
    private CharacterController _controller;
    [SerializeField] private GameObject TouchRotation;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
      //  YandexGame.EnvironmentData.isMobile = true;
    }

    private void Update()
    {
       // if (YandexGame.EnvironmentData.isMobile == true)
      //  {
            Vector3 Move = transform.right * _joystick.Horizontal + transform.forward * _joystick.Vertical;
            _controller.Move(Move * _speedMove * Time.deltaTime);
      //  }
    }
}
