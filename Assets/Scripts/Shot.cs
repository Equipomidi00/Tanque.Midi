using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] Transform controllerShot;
    [SerializeField] GameObject bullet;
    public float targetTime = 2.0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShotBullet();
        }
    }

    public void ShotBullet()
    {
        Instantiate(bullet, controllerShot.position, controllerShot.rotation); 
    }
}
