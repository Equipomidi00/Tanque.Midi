using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOfEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Imput Damge.");  
        }
    }
}
