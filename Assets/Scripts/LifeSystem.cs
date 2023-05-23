using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private float life;

    public void SetLife(float damage)
    {
        life -= damage;
        if (life <= 0)
            Destroy(gameObject);
    }
}
