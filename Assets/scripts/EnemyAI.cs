using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum EnemyStates
{
    Idle =0,
    Walk=1,
    Dead =2,
    Atack=3
}
public class EnemyAI : MonoBehaviour
{
   // Animator animator;
    NavMeshAgent agent;
    GameObject playerObject;
    EnemyStates enemyStates;
    PlayerHealth playerHealth;
    EnemyMovement enemyMovement;
    public int EnemyState { get; private set; }

    private void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        enemyMovement = GetComponent<EnemyMovement>();
    }
    void Start()
    {
      
        enemyStates = EnemyStates.Idle;
        agent = GetComponent<NavMeshAgent>();
        // animator = GetComponent<Animator>();
    }

    private void SetState(EnemyStates state)
    {
        enemyStates = state;
      //  animator.SetInteger("state", (int)state);
    }
    private void MoveToPlayer()
    {
        //  Vector3 p = playerObject.transform.position;
        agent.isStopped = false;
       // agent.Warp(new Vector3(0,0,0));
        agent.SetDestination(playerObject.transform.position);
        SetState(EnemyStates.Walk);
    }
    void Update()
    {
        if (enemyMovement.GetHealth() <= 0)
        {
            SetState(EnemyStates.Dead);
        }
        switch (enemyStates)
        {
            case EnemyStates.Dead:
                KillEnemy();
                break;
            case EnemyStates.Atack:
                EnemyAtack();
                break;
            case EnemyStates.Walk:
                SearchForTaget();
                break;
            case EnemyStates.Idle:
                SearchForTaget();
                break;
            default:
                break;
        }
    }

    private void EnemyAtack()
    {
        MakeAtack(10);
        SetState(EnemyStates.Atack);
        agent.isStopped = true;
        SetState(EnemyStates.Walk);
    }

    public void MakeAtack(int atackValue) //this method can be called from animator
    {
        playerHealth.DeductHealth(atackValue);
    }
    public  void KillEnemy()
    {
        agent.isStopped = true;
        Destroy(gameObject, 5);
        print("Enemy is killed");
    }

    private void SearchForTaget()
    {
        float distance = Vector3.Distance(transform.position, playerObject.transform.position);
        if (distance < 1.5f)
        {
            EnemyAtack();
        }
        else if (distance<20)
        {
            MoveToPlayer();
        }
        else
        {
            SetState(EnemyStates.Idle);
            agent.isStopped = true;
        }
    }
}

