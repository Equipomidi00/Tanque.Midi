using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [Tooltip ("Es desde donde see va a disparar la bullet")]
    [SerializeField] Transform controllerShot;
    [SerializeField] GameObject bullet;

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
