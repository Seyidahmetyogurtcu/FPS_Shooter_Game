using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OlderShooterGame
{
    public class ChangeTrigerState : MonoBehaviour
    {
        public bool isTrigger;
        Collider collider;
        // Start is called before the first frame update
        void Start()
        {
            collider = GetComponent<Collider>();
            collider.isTrigger = isTrigger;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}