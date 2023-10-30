using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirMenu : MonoBehaviour
{
    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicial 1");
    }
}
