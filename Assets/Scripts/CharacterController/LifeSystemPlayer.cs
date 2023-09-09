using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Life system Player
 Este sistema de vide esta diseñado 
para el avatar del jugador.
 */
public class LifeSystemPlayer : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private GameObject MenuGameOver;

    [Header("Game object que contiene el escript Destroy")]
    public Destroy destroid;

    public void SetLife(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Cursor.visible = true;
            destroid.destroid = true;
            MenuGameOver.SetActive(true);
        }
    }
}
