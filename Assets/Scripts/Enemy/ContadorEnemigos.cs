using UnityEngine;
using UnityEngine.UI;

public class ContadorEnemigos : MonoBehaviour
{
    [SerializeField] private Text contador;
    private float auxiliar;
    
    public void Aumentar()
    {

        auxiliar=float.Parse(contador.text);

        auxiliar = auxiliar + 1;

        contador.text=auxiliar.ToString();

    }

}
