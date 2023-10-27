using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/*Life system Player
 Este sistema de vide esta diseñado 
para el avatar del jugador.
 */
public class LifeSystemPlayer : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private float life_total;

    [Tooltip("Efecto de sonido")]

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioMixerGroup audioMixerGroup;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipDano;
    [SerializeField] private AudioClip clipMuerte;

    [SerializeField] private Image barraVida;

    private void Start()
    {
        life_total = life;
    }

    public void SetLife(float damage)
    {

        audioSource.clip = clipDano;

        life -= damage;

        barraVida.fillAmount = life / life_total;

        audioSource.Play();

        if (life <= 0)
        {
            audioSource.clip = clipMuerte;

            audioSource.Play();

            Destroy(gameObject);
        }
    }
}
