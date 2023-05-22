using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleShader : MonoBehaviour
{
    private Camera mainCamera; //La camara es para que se haga traasparente solo los objetos que se encuentren entre la camara y el jugador.
    private new Rigidbody rigidbody;

    [Header ("Set cut")]
    public float holeSize = 0.1f; //Es el valor que tiene el Step del Shader Hole.

    void Awake()
    {
        mainCamera = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(rigidbody.transform.position, 5f); //Creamos una spher invisible de nombre hitCollider.
        foreach (var hitCollider in hitColliders) //Verificamos todos los collider con los que estamos chocando segun la esfera creada.
        {
            float x = 0f;

            /* Lo que hacemos es verificar la posicion del objeto y del player segun la distancia de la camara.
             * if la distancia del objeto que esta al rededor de nuestro personaje(La esfera minvisible que creamos), respecto de la camara, esta mas serca de la camara que el propio jugador, realiza el corte;
             */
            //                   la posicion del objeto        , respecto a la camara     es menor que la              posicion desde el cecntro de masa del jugador, respecto a la camara 
            if (Vector3.Distance(hitCollider.transform.position, mainCamera.transform.position) < Vector3.Distance(rigidbody.centerOfMass + rigidbody.transform.position, mainCamera.transform.position))
            {
                x = holeSize;
            }

            try
            {
                Material[] materials = hitCollider.transform.GetComponent<Renderer>().materials;
                for (int m = 0; m < materials.Length; m++)
                {
                    materials[m].SetFloat("_Step", x);
                }
            }
            catch { }
        }
    }
}
