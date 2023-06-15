using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Centinela : MonoBehaviour
{
    [Header("Set Objetive")]
    [SerializeField] private Transform objetive;

    [Header("Set Centinella")]
    [SerializeField] private float alertRange;
    [SerializeField] private LayerMask layerObjetive;
    [SerializeField] private float movementSpeed;
    private bool isAlert;
    public bool move;

    private Vector3 positionOrigin;

    private void Start()
    {
        move = true;
        positionOrigin = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    private void Update()
    {
        isAlert = Physics.CheckSphere(transform.position, alertRange, layerObjetive);
        if (isAlert && move)
        {
            Vector3 positionObjetive = new Vector3(objetive.position.x, transform.position.y, objetive.position.z);
            //transform.LookAt(positionObjetive);
            Rotar();
            transform.position = Vector3.MoveTowards(transform.position, positionObjetive, movementSpeed * Time.deltaTime);
        }
        else if (isAlert == false && move)
        {
            RotarRetorno();
            transform.position = Vector3.MoveTowards(transform.position, positionOrigin, movementSpeed * Time.deltaTime);
        }
    }

    private void Rotar()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);                    //toma posicion del jugador.
        Vector3 objetiveOneScreen = (Vector2)Camera.main.WorldToViewportPoint(objetive.position);           //toma posicion del objetivo.

        Vector3 direction = objetiveOneScreen - positionOnScreen;                                           //calcula el vector o la distancia entre ambos puntos.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;                        //calcula los radianes y lo cmobierte a angulo.

        transform.rotation = Quaternion.Euler(0, -angle, 0);                                                 //Modifica la rotacion.
    }
    private void RotarRetorno()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);                    //toma posicion del jugador.
        

        Vector3 direction = positionOrigin - positionOnScreen;                                           //calcula el vector o la distancia entre ambos puntos.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;                        //calcula los radianes y lo cmobierte a angulo.

        transform.rotation = Quaternion.Euler(0, -angle, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);
    }
}
