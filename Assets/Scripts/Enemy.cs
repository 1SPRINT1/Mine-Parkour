using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
  [Header("NavMesh")]
  [SerializeField] private NavMeshAgent agent;
  [SerializeField] private Transform player;
  [SerializeField] private int health;
  public LayerMask ThisGround,ThisPlayer;
  [Space(20)] 
  [Header("Patrolling")] 
  private Vector3 walkPoint;
  [SerializeField] private bool walkPointSet;
  [SerializeField] private float walkPointRange;

  [Space(20)]
  [Header("Attacking")]
  [SerializeField] private float timeBTWAttacks;
  [SerializeField] private bool alreadyAttacked;
  [SerializeField] private GameObject projectile;
  [Space(20)]
  [Header("States")]
  [SerializeField] private float sightRange,AttackRange;
  public bool playerSightRange, playerAttckRange;
    Vector3 startPos;

  private void Awake()
  {
      agent = GetComponent<NavMeshAgent>();
        startPos = transform.position;
  }

  private void Update()
  {
      playerSightRange = Physics.CheckSphere(transform.position, sightRange, ThisPlayer);
      playerAttckRange = Physics.CheckSphere(transform.position, AttackRange, ThisPlayer);

      if (!playerSightRange && !playerAttckRange)
      {
          Patroling();
      }

      if (playerSightRange && !playerAttckRange)
      {
          Chasing();
      }

      if (playerAttckRange && playerSightRange)
      {
          Attack();
      }
  }

  public void Patroling()
  {
      if (!walkPointSet)
      {
          SearchWalkPoint();
      }

      if (walkPointSet)
      {
            agent.SetDestination(walkPoint);
      }

      Vector3 distanceToWalkPoint = transform.position - walkPoint;
        Debug.Log(distanceToWalkPoint.magnitude);

      if (distanceToWalkPoint.magnitude < 1f)
      {
          walkPointSet = false;
      }
  }

  public void Chasing()
  {
      agent.SetDestination(player.position);
  }

  public void Attack()
  {
      agent.SetDestination(transform.position);
      transform.LookAt(player);

      if (!alreadyAttacked)
      {
          //transform.position = Vector3.MoveTowards(transform.position,player.transform.position,);
          Chasing();
          alreadyAttacked = true;
          Invoke(nameof(ResetAttack),timeBTWAttacks);
      }
  }

  private void ResetAttack()
  {
      alreadyAttacked = false;
  }
  public void SearchWalkPoint()
  {
      float randomZ = Random.Range(-walkPointRange, walkPointRange);
      float randomX = Random.Range(-walkPointRange, walkPointRange);
      
      walkPoint = new Vector3(startPos.x+ randomX,transform.position.y, startPos.z + randomZ);
        walkPointSet = true;
  }

  public void TakeDamage(int damage)
  {
      health -= damage;
      if (health <= 0)
      {
          Invoke(nameof(DestroyEnemy),0.5f);
      }
  }

  private void DestroyEnemy()
  {
      Destroy(gameObject);
  }

  private void OnDrawGizmosSelected()
  {
     Gizmos.color = Color.red;
     Gizmos.DrawWireSphere(transform.position,AttackRange);
     Gizmos.color = Color.yellow;
     Gizmos.DrawWireSphere(transform.position,sightRange);
  }
}
