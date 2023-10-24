using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*Gravis controller
 Este es el controlador de Gravis. Se encarga de estar dormido 
hasta que de tecte al jugador, en ese momento se despierta y lo 
va a perseguir hasta que lo maten. Va disparar Mortems, pequeñas maquinas 
que se van a hacercar al jugador para reventar y quitarle vida.
 */

public class GravisController : MonoBehaviour
{
    [Header("Select Layers")]
    [SerializeField] private LayerMask whatIsGround, whatIsTarget;
    private NavMeshAgent agent;
    private Transform target;

    //Detect.
    [Header("Detect target")]
    [SerializeField] private bool initChaseTarget;
    [SerializeField] private bool sleep;

    //Attack
    [Header("Set Attack")]
    [SerializeField] Transform controllerShot;
    [SerializeField] GameObject bullet;
    [SerializeField] private float timer;
    [SerializeField] private bool canShot;
    private float saveTimer;

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

    private void Start()
    {
        sleep = true;   
        initChaseTarget = false;
        canShot = true;
        saveTimer = timer;
    }

    private void Update()
    {
        //Check for sight and attack range.
       // targetInSightRange = Physics.CheckSphere(this.transform.position, sightRange, whatIsTarget);
        targetInAttackRange = Physics.CheckSphere(this.transform.position, attackRange, whatIsTarget);

       // ChaseTarget();

        if (targetInAttackRange)
        {
            sleep = false;
        }

        if (!sleep)
        {
            if (agent!=null && target!=null)
            {
                agent.destination = target.position;
            }

            if (canShot)
            {
                AttackTarget();
                canShot = false;
            }
            else
            {
                Timer();
            }
        }

    }

    private void ChaseTarget()
    {
        if (!initChaseTarget)
        {
            if (targetInSightRange && !targetInAttackRange) 
                initChaseTarget = true;
        }

        else agent.destination = target.position;
    }

    private void AttackTarget()
    {
        /// Attack code here
        Debug.Log("Attacked");
        agent.SetDestination(this.transform.position);
        transform.LookAt(target);

        Instantiate(bullet, controllerShot.transform.position, this.transform.rotation);
    }

    void Timer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = saveTimer;
            canShot = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, sightRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}
