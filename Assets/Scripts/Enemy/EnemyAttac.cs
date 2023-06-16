using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttac : MonoBehaviour
{
    [Header("Set Centinella")]
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask layerObjetive;
    private bool isAlert;

    [Header("Game object que contiene el escript")]
    public Movement_Centinela movementCentinela;

    [Header("Variables de Animación")]
    public Animator animator;
    public string variableAtack;

    private void Update()
    {
        isAlert = Physics.CheckSphere(transform.position, attackRange, layerObjetive);
        if (isAlert)
        {
            movementCentinela.move = false;
            Debug.Log("Animacion de ataque");
            animator.SetBool(variableAtack, true);
        }
        else
        {
            animator.SetBool(variableAtack, false);
            movementCentinela.move = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
