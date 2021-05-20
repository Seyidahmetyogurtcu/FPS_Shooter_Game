using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHeralth;
    private int currentHealth;  
    void Start()
    {
        currentHealth = maxHeralth;
    }
    public void DeductHealth(int damage)
    {
        Debug.Log("Player health: "+ currentHealth);
        currentHealth -= damage;
        if (currentHealth<=0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        print("Player is killed");
    }
    
    public void AddHeatht(int value)
    {
        currentHealth += value;
        if (currentHealth>maxHeralth)
        {
            currentHealth = maxHeralth;
        }
    }
   void Update()
    {
        
    }
}
