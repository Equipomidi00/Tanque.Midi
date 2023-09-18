using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravisDamage : MonoBehaviour
{
    [SerializeField] private float damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<LifeSystemPlayer>().SetLife(damage);
        }
    }
}
