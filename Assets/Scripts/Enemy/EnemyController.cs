using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Select Layers")]
    [SerializeField] private LayerMask whatIsGround, whatIsTarget;
    private NavMeshAgent agent;
    private Transform target;

    //Patroling.
    [Header("Set Patroling")]
    [SerializeField] private float walkPointRange;
    [SerializeField] private Vector3 walkPoint;
    [SerializeField] private bool walkPointSet;

    //Attack
    [Header("Set Attack")]
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private bool alreadyAttacked;
    [SerializeField] Transform controllerShot;
    [SerializeField] GameObject bullet;

    //State.
    [Header("Set Range")]
    [SerializeField] private float sightRange, attackRange;
    [Header("State range")]
    [SerializeField] private bool targetInSightRange, targetInAttackRange;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        //Check for sight and attack range.
        targetInSightRange = Physics.CheckSphere(this.transform.position, sightRange, whatIsTarget);
        targetInAttackRange = Physics.CheckSphere(this.transform.position, attackRange, whatIsTarget);

        if (!targetInSightRange && !targetInAttackRange) Patroling();

        if (targetInSightRange && !targetInAttackRange) ChaseTarget();

        if (targetInSightRange && targetInAttackRange) AttackTarget();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceWalkPoint = this.transform.position - walkPoint;

        //Walkpoint reached
        if (distanceWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    
    private void SearchWalkPoint()
    {
        //Calculate range point.
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(this.transform.position.x + randomX, this.transform.position.y, this.transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) 
            walkPointSet = true;
    }

    private void ChaseTarget()
    {
        //agent.SetDestination(target.position);
        agent.destination = target.position;
    }
    
    private void AttackTarget()
    {
        /// Attack code here
        Debug.Log("Attacked");
        Instantiate(bullet, controllerShot.transform.position, this.transform.rotation);
         

        /// 


        //Make sure enemy doesn´t move
        agent.SetDestination(this.transform.position);

        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, sightRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}
