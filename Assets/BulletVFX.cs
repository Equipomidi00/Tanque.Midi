using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVFX : MonoBehaviour
{
    [SerializeField] private float timer;
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
