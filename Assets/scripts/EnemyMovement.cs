using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int startHealth=100;
    int currentHealth;

    void Start()
    {
        currentHealth = startHealth;
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    public void Hit (int damage)
    {
        currentHealth -= damage;
        if (currentHealth <0)
        {
            currentHealth = 0;
            Debug.Log("Enemy has defeated,enemys life is:" + currentHealth);
        }
        Debug.Log("You hit enemy,enemys life is:" + currentHealth);
    }
    
}
