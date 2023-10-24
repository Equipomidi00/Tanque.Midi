
using UnityEngine;

public class SalidaSonidoEnemigo : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;

    public void Play(AudioClip _audioClip)
    {

        _audioSource.clip = _audioClip;

        _audioSource.Play();
    }

}
