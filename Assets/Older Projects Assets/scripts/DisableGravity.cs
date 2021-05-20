using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OlderShooterGame
{
    public class DisableGravity : MonoBehaviour
    {
        Rigidbody rigidbody;
        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}