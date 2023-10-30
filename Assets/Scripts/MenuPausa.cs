using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private bool juegoPausado = false;
    public Canvas _canvas;
    public Canvas winCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& winCanvas==false)
        {
            if (juegoPausado)
            {
                Reanudar();
                Cursor.visible = false;
            }
            else
            {
                Pausa();
                Cursor.visible = true; 
            }
        }
    }

    public void Pausa()
    {
        _canvas.gameObject.SetActive(true);   
        juegoPausado = true;
        Time.timeScale = 0f;

    }

    public void Reanudar()
    {
        _canvas.gameObject.SetActive(false);
        juegoPausado = false;
        Time.timeScale = 1f;

    }
}
