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
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);       
    }

    public void Salir()
    {
        Debug.Log("Salir..."); 
        Application.Quit();
    }
}
