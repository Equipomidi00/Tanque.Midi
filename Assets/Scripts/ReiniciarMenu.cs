using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarMenu : MonoBehaviour
{
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
