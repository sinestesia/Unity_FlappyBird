using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instancia;

  
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI puntuacionMaxima;

    private void Awake()
    {
        instancia = this;
        ActualizarPuntuacion();
        ActualizarPuntuacionMaxima();
    }

    public void ActualizarPuntuacionMaxima()
    {
        puntuacionMaxima.text = PlayerDataManager.instancia.datosJugador.record.ToString();
    }

    public void ActualizarPuntuacion()
    {
        puntuacion.text = PlayerDataManager.instancia.datosJugador.puntuacion.ToString();
    }
}
