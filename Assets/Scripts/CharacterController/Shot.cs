using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class Shot : MonoBehaviour
{
    [Tooltip("Es desde donde see va a disparar la bullet")]
    [SerializeField] Transform controllerShot;
    [SerializeField] GameObject bullet;
    [SerializeField] private float timer;
    [SerializeField] private bool canShot;
    private float saveTimer;
    
    public GameObject vfx;

    [Tooltip("Efectos de sonido")]

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioMixerGroup audioMixerGroup;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip Clip;
    private bool corrutina_activa = false;

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
 
            audioSource.clip = Clip;

            StartCoroutine(ReproducirSonido());

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
            corrutina_activa = false;
        }
    }

    IEnumerator ReproducirSonido()
    {
        if (!corrutina_activa) {
            
            audioSource.Play();
            corrutina_activa = true;

        }
        else
        {

            corrutina_activa = false;

        }

        yield return null;

    }

}
