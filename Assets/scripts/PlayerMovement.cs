using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 moveVector;
    public int speed = 10;
    const float gravity = 9.81f;
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

        moveVector = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        moveVector = transform.TransformDirection(moveVector);  

        if (!characterController.isGrounded)
        {
            moveVector.y -= Time.deltaTime * gravity;
        }  //saçma
        characterController.Move(moveVector);

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

