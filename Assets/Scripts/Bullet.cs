using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private float targetTime = 0.80f;

    void Update()
    {
        transform.Translate(Vector3.fwd * speed * Time.deltaTime);

        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<LifeSystem>().SetLife(damage);
            Destroy(gameObject);
        }

        if (other.CompareTag("Nucleo"))
        {
            other.GetComponent<Nucleo>().SetLife(damage);
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Nucleo>().SetLife(damage);
            Destroy(gameObject);
        }
    }
}
