using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OlderShooterGame
{
    public class PlayerMovement : MonoBehaviour
    {
        Vector3 movePlayer, moveVector;
        public int speed = 10;
        CharacterController characterController;

        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }


        void Update()
        {
            playermovement();

        }
        private void playermovement()
        {

            movePlayer = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
            movePlayer = transform.TransformDirection(movePlayer);
            characterController.Move(movePlayer);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 50;
            }
            else
            {
                speed = 10;
            }
        }


    }
}

