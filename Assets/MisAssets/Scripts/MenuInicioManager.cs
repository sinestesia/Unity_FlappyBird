using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class MenuInicioManager : MonoBehaviour
{

    // -----------------------------------------------------------------
    #region 1) Definicion de Variables

    public static MenuInicioManager instancia;

    #endregion
    // -----------------------------------------------------------------
    #region 2) Funciones Predeterminadas de Unity 
    void Awake (){
        instancia = this;
	}

#endregion
// -----------------------------------------------------------------
#region 3) Metodos Originales

    public void Jugar()
    {
        GameManager.instancia.EstablecerEstado(EstadosJuego.Jugando);
        SoundManager.instancia.SonidoClic();
    }

    public void Salir()
    {
        Application.Quit();
        SoundManager.instancia.SonidoClic();
    }

#endregion
// -----------------------------------------------------------------

}
