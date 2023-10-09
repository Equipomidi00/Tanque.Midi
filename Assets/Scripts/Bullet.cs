using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private float targetTime = 2f;

    public GameObject vfx;


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
        if (other.tag == "Enemy")
        {
            vfx.transform.position = this.transform.position;
            other.GetComponent<LifeSystemEnemy>().SetLife(damage);
            vfx.SetActive (true);
            Destroy(gameObject);
        }

        if (other.CompareTag("Nucleo"))
        {
            vfx.transform.position = this.transform.position;
            vfx.SetActive(true);
            other.GetComponent<Nucleo>().SetLife(damage);
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Nucleo>().SetLife(damage);
            vfx.SetActive(true);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
