using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttac : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<LifeSystem>().SetLife(damage);
        }
    }
}
