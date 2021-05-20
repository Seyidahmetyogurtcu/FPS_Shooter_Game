using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera camera;
    public GameObject Player;
     int rangeShotgun=100;
    [Header("Gun Damage On Hit")]
    public int damage;
    public GameObject bloodPrefab;
    public GameObject decayPrefab;
    public ParticleSystem gunMuzzle;
    public float gunCooldown;
    private float gunTimer=0;

    void Update()
    {
        if (Input.GetMouseButton(0) && gunTimer < Time.time)
        { 
            gunTimer = Time.time + gunCooldown;
            Fire();
        }
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

    private void Fire()
    {
        RaycastHit hit;
        Debug.DrawRay(camera.transform.position, camera.transform.forward * rangeShotgun, Color.blue, 100);
        //Debug.DrawRay(Player.transform.position, Player.transform.forward * rangeShotgun, Color.cyan, 100);
        if (Physics.Raycast(camera.transform.position ,camera.transform.forward,out hit, rangeShotgun))
        {
            if (hit.transform.tag == "HumanEnemy")
            {
                hit.transform.GetComponent<EnemyMovement>().Hit(damage);
                GenerateBloodEffect(hit);
            }
            else 
            {
               GenerateHitEffect(hit);
            }
        }
        gunMuzzle.Play();
    }

    private void GenerateHitEffect(RaycastHit hit)
    {
        //TODO :mermi izi
        GameObject hitObject = Instantiate(decayPrefab, hit.point, Quaternion.identity);
        hitObject.transform.rotation = Quaternion.FromToRotation(decayPrefab.transform.forward*-1,hit.normal);
        Destroy(hitObject,5f);
    }

    private void GenerateBloodEffect(RaycastHit hit)
    {
        GameObject gameObject = Instantiate(bloodPrefab, hit.point, hit.transform.rotation);
       
        Debug.Log("kan efekti oluştu");
    }
}
