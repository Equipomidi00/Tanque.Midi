using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private Vector3 offset;
    
    [Range(0.01f, 1), SerializeField] private float lerp;
    [Range(0.01f, 10), SerializeField] private float mousSensitivity;
    

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + offset, lerp); //La camara se posiciona en donde esta el player.

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mousSensitivity, Vector3.up) * offset; //Funcion de rotacion con el mouse en el eje X.

        this.transform.LookAt(player.transform); //Se mantiene mirando al player.
    }
}
