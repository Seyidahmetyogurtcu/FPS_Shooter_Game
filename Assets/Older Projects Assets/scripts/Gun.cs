using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OlderShooterGame
{
    public class Gun : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            gunSellecter();
        }
        private void gunSellecter()
        {
            GameObject[] Shotgun = GameObject.FindGameObjectsWithTag("Shotgun");
            GameObject[] Laser = GameObject.FindGameObjectsWithTag("Laser");
            GameObject[] Rocket = GameObject.FindGameObjectsWithTag("Rocket");

            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                for (int i = 0; i < Shotgun.Length; i++)
                {
                    Laser[i].gameObject.SetActive(false);
                    Rocket[i].gameObject.SetActive(false);
                    Shotgun[i].gameObject.SetActive(true);
                }

            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                for (int i = 0; i < Shotgun.Length; i++)
                {
                    Laser[i].gameObject.SetActive(false);
                    Shotgun[i].gameObject.SetActive(false);
                    Rocket[i].gameObject.SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                for (int i = 0; i < Shotgun.Length; i++)
                {
                    Shotgun[i].gameObject.SetActive(false);
                    Rocket[i].gameObject.SetActive(false);
                    Laser[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
