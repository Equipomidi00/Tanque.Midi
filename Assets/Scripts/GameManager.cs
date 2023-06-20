using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int cantidadDeNucleos;
    [SerializeField] private int nucleosEliminados;
    [SerializeField] private GameObject MenuWiner;

    private void Start()
    {
        cantidadDeNucleos = GameObject.FindGameObjectsWithTag("Nucleo").Length; //Busca todos los game objects que tengan ese tag
    }

    public void ActivarWin()
    {
        MenuWiner.SetActive(true);
    }

    public void NucleosEliminados()
    {
        nucleosEliminados += 1;

        if (nucleosEliminados == cantidadDeNucleos)
        {
            ActivarWin();
        }
    }
}
