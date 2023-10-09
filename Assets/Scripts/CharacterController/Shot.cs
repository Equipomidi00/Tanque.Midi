using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [Tooltip("Es desde donde see va a disparar la bullet")]
    [SerializeField] Transform controllerShot;
    [SerializeField] GameObject bullet;
    [SerializeField] private float timer;
    [SerializeField] private bool canShot;
    private float saveTimer;

    public GameObject vfx;

    private void Start()
    {
        canShot = true;
        saveTimer = timer;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShot)
        {
            canShot = false;
            ShotBullet();
        }

        if (canShot == false)
        {
            Timer();
        }
    }

    public void ShotBullet()
    {
        Instantiate(bullet, controllerShot.position, controllerShot.rotation);
        vfx.transform.position = controllerShot.position;
        vfx.SetActive(true);
    }

    void Timer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
             vfx.SetActive(false);
            timer = saveTimer;
            canShot = true;
        }
    }
}
