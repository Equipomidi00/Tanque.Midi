using UnityEngine;

public class victoria : MonoBehaviour
{
    [SerializeField] GameObject nucleo1;
    [SerializeField] GameObject nucleo2;
    [SerializeField] GameObject nucleo3;

    [SerializeField] public Canvas _canvas;

    void Update()
    {
        if (nucleo1==null&&nucleo2==null&&nucleo3==null) {

            Time.timeScale = 0f;
            _canvas.gameObject.SetActive(true);

        }
    }
}
