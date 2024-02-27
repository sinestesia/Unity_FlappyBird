using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class PlayerDataManager : MonoBehaviour
{
    // -----------------------------------------------------------------
    #region 1) Definicion de Variables
    public static PlayerDataManager instancia;

    public PlayerData datosJugador; // contiene toda la info que se va a guardar/cargar
    #endregion
    // -----------------------------------------------------------------
    #region 2) Funciones Predeterminadas de Unity 
    void Awake (){
        instancia = this;
        datosJugador.puntuacion = 0;
        datosJugador.record = 0;
	}

#endregion
    // -----------------------------------------------------------------
    #region 3) Metodos Originales
    public void AgregarPuntos(int _puntos)
    {
        datosJugador.puntuacion += _puntos;
        HUDManager.instancia.ActualizarPuntuacion();
        Debug.Log(datosJugador.puntuacion);
    }

    public bool RecordSuperado()
    {
        if (datosJugador.puntuacion > datosJugador.record) return true;
        else return false;
    }
    #endregion
    // -----------------------------------------------------------------
}


// Se definen los datos que van a ser exportados o importados en un sistema de guardado de partidas
[Serializable]
public class PlayerData
{
    public string nombre;

    public int puntuacion;
    public int record;

}