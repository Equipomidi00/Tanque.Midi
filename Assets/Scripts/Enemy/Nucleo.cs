using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleo : MonoBehaviour
{
    [SerializeField] private float life;

    [Header("Game object que contiene el escript Destroy")]
    public Destroy destroid;

    public void SetLife(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("GameMansager").GetComponent<GameManager>().NucleosEliminados();
        }
    }
}
