using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//using UnityEngine.UI;

public class TesoroFinal : MonoBehaviour
{
    public GameObject panelMensaje;
    public Text mensajeText;

    private bool tesoroEncontrado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !tesoroEncontrado)
        {
            tesoroEncontrado = true;
            MostrarMensaje();
        }
    }

    private void MostrarMensaje()
    {
        panelMensaje.SetActive(true);
        mensajeText.text = "Muy bien pirata has cumplido con todos los objetivos, eliminado a todos tus enemigos y salvado al mundo por medio de la reducción de la contaminación y la huella de carbono";
    }

    public void OcultarMensaje()
    {
        panelMensaje.SetActive(false);
    }

    public class Text
    {
        public string text { get; internal set; }
    }
}

