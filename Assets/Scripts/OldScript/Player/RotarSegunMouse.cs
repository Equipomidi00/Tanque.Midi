using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Descripcion:
 * Se encarga de rotar al objeto que lo contega,
 * segun el mouse.
 */
public class RotarSegunMouse : MonoBehaviour
{
    private void Update()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);                //toma posicion del jugador.
        Vector3 mouseOneScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);       //toma posicion del mouse.

        Vector3 direction = mouseOneScreen - positionOnScreen;                                          //calcula el vector o la distancia entre ambos puntos.

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;                       //calcula los radianes y lo cmobierte a angulo.
        transform.rotation = Quaternion.Euler(0, -angle, 0);                                            //Modifica la rotacion.
    }
}
