using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int cantidadDeNucleos;
    [SerializeField] private int nucleosEliminados;
    [SerializeField] private GameObject MenuWiner;
    [SerializeField] private GameObject MenuPausa;
    private bool juegoPausado = false;
    private bool juegoGanado = false;

    private void Start()
    {
        Cursor.visible = false; //Ocultra
        cantidadDeNucleos = GameObject.FindGameObjectsWithTag("Nucleo").Length; //Busca todos los game objects que tengan ese tag
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado && juegoGanado == false)
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
        MenuPausa.gameObject.SetActive(true);
        juegoPausado = true;
        Time.timeScale = 0f;

    }

    public void Reanudar()
    {
        MenuPausa.gameObject.SetActive(false);
        juegoPausado = false;
        Time.timeScale = 1f;

    }

    public void ActivarWin()
    {
        if (juegoPausado == false)
        {
            MenuWiner.SetActive(true);
        }

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
