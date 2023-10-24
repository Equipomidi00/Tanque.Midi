
using UnityEngine;

public class Nucleo : MonoBehaviour
{
    [SerializeField] private float life;

    [Header("Game object que contiene el escript Destroy")]
    public Destroy destroid;

    [SerializeField] private AudioClip clipDano;
    [SerializeField] private AudioClip clipMuerte;

    private SalidaSonidoEnemigo _salidaSonidoEnemigo;

    private void Start()
    {
        _salidaSonidoEnemigo = FindObjectOfType<SalidaSonidoEnemigo>();
    }

    public void SetLife(float damage)
    {
        _salidaSonidoEnemigo.Play(clipDano);

        life -= damage;

        if (life <= 0)
        {
            _salidaSonidoEnemigo.Play(clipMuerte);
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().NucleosEliminados();
        }
    }
}
