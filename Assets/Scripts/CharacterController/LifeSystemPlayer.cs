using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*Life system Player
 Este sistema de vide esta diseñado 
para el avatar del jugador.
 */
public class LifeSystemPlayer : MonoBehaviour
{
    [SerializeField] private float life;

    [Tooltip("Efecto de sonido")]

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioMixerGroup audioMixerGroup;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipDano;
    [SerializeField] private AudioClip clipMuerte;

    public void SetLife(float damage)
    {

        audioSource.clip = clipDano;

        life -= damage;

        audioSource.Play();

        if (life <= 0)
        {
            audioSource.clip = clipMuerte;

            audioSource.Play();

            Destroy(gameObject);
        }
    }
}
