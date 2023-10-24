
using UnityEngine;
public class LifeSystemEnemy : MonoBehaviour
{
    [SerializeField] private float life;

    [SerializeField] private AudioClip clipDano;
    [SerializeField] private AudioClip clipMuerte;

    private SalidaSonidoEnemigo _salidaSonidoEnemigo;

    private void Start()
    {
       _salidaSonidoEnemigo=FindObjectOfType<SalidaSonidoEnemigo>();
    }

    public void SetLife(float damage)
    {

        _salidaSonidoEnemigo.Play(clipDano);

        life -= damage;

        if (life <= 0)
        {
            _salidaSonidoEnemigo.Play(clipMuerte);

            Destroy(gameObject);
        }
    }
}
