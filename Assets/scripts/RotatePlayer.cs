﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float sensitivity = 3;
    private float rotateY = 0f;
    private float rotateX = 0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks the mause 
    }

    void Update()
    {
        rotateBody();
    }

    private void rotateBody ()
    {
        rotateY -= sensitivity * Input.GetAxis("Mouse Y");
        rotateX += sensitivity * Input.GetAxis("Mouse X");
        rotateY = Mathf.Clamp(rotateY, -80, 80);
        transform.eulerAngles = new Vector3(rotateY, rotateX, 0);
    }
}