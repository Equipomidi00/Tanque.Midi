using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttac : MonoBehaviour
{
    [Header("Set Centinella")]
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask layerObjetive;
    private bool isAlert;

    public Movement_Centinela movementCentinela;

    private void Update()
    {
        isAlert = Physics.CheckSphere(transform.position, attackRange, layerObjetive);
        if (isAlert)
        {
            movementCentinela.move = false;
            Debug.Log("Animacion de ataque");
        }
        else
        {
            movementCentinela.move = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<LifeSystem>().SetLife(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
