using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuInicial : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void Jugar(string scena_nombre)
    {
        SceneManager.LoadScene(scena_nombre);       
    }

    public void Salir()
    {
        Debug.Log("Salir..."); 
        Application.Quit();
    }
}
