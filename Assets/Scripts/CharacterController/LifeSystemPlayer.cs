using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LifeSystemPlayer : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private float life_total;

    [Tooltip("Efecto de sonido")]

    [SerializeField] AudioMixerGroup audioMixerGroupDano;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipDano;

    [SerializeField] private Image barraVida;

    [SerializeField] Canvas _canvas;

    private void Start()
    {
        life_total = life;
    }

    public void SetLife(float damage)
    {

        life -= damage;

        barraVida.fillAmount = life / life_total;

        audioSource.outputAudioMixerGroup = audioMixerGroupDano;

        StartCoroutine(ReproducirSonidos(clipDano));

        if (life <= 0)
        {

            Destroy(gameObject);

            Time.timeScale = 1f;

            Cursor.visible = true;

            _canvas.gameObject.SetActive(true);

        }
    }

    IEnumerator ReproducirSonidos(AudioClip clip)
    {
        audioSource.clip = clip;

        audioSource.Play();

        yield return new WaitWhile(()=>audioSource.isPlaying);

    }

}
