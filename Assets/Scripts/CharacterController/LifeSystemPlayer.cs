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
  
    public void SetLife(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
