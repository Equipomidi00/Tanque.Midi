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
    [SerializeField] private GameObject MenuDerrota;

    [SerializeField] public LifeSystemPlayer _player;

    private bool juegoPausado = false;
    private bool juegoGanado = false;
    private bool juegoPerdido = false;

    private void Start()
    {
        Cursor.visible = false; //Ocultra
        cantidadDeNucleos = GameObject.FindGameObjectsWithTag("Nucleo").Length; //Busca todos los game objects que tengan ese tag
    }

    private void Update()
    {
        if (_player.life <= 0)
        {
            ActivarDerrota();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
                Cursor.visible = false;
            }
            else
            {
                if (juegoGanado == false && juegoPerdido == false)
                {

                    Pausa();
                    Cursor.visible = true;

                }

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
        MenuWiner.SetActive(true);
        Time.timeScale = 0f;
        juegoGanado = true;

    }

    public void ActivarDerrota()
    {
        MenuDerrota.SetActive(true);
        Time.timeScale = 0f;
        juegoPerdido = true;


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