using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OlderShooterGame
{
    public class RotatePlayer : MonoBehaviour
    {
        public float sensitivity = 3;
        private float rotateY = 0f;
        private float rotateX = 0f;
        void Update()
        {
            //rotate playerBody---------------
            rotateY += sensitivity * Input.GetAxis("Mouse Y");
            rotateX += sensitivity * Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(rotateX, rotateY, 0);
            //---------------------------------------------------------
        }
    }
}