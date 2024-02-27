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
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
#endregion
    // -----------------------------------------------------------------
    #region 3) Metodos Originales
    public void AgregarPuntos(int _puntos)
    {
        datosJugador.puntuacion += _puntos;
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