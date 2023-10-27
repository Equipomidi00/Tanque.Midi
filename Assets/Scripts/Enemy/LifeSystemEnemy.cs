using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class LifeSystemEnemy : MonoBehaviour
{
    [SerializeField] private AudioClip clipDano;
    [SerializeField] private AudioClip clipMuerte;
    private SalidaSonidoEnemigo _salidaSonidoEnemigo;

    private ContadorEnemigos _contadorEnemigos;

    [SerializeField] private Image barraVida;
    [SerializeField] private float life;
    private float life_total;

    private void Start()
    {
        _salidaSonidoEnemigo=FindObjectOfType<SalidaSonidoEnemigo>();

        _contadorEnemigos=FindObjectOfType<ContadorEnemigos>();

        life_total=life;

    }
    public void SetLife(float damage)
    {

        _salidaSonidoEnemigo.Play(clipDano);

        life -= damage;

        barraVida.fillAmount = life / life_total;


        if (life <= 0)
        {
            _salidaSonidoEnemigo.Play(clipMuerte);

            _contadorEnemigos.Aumentar();

            Destroy(gameObject);
        }
    }
}
