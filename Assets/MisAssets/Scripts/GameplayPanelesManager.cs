using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class GameplayPanelesManager : MonoBehaviour
{

    // -----------------------------------------------------------------
    #region 1) Definicion de Variables
    public static GameplayPanelesManager instancia;

    public GameObject[] paneles;
#endregion
// -----------------------------------------------------------------
#region 2) Funciones Predeterminadas de Unity 
void Awake (){
        instancia = this;

        paneles = new GameObject[transform.childCount];

        for(int i = 0; i < paneles.Length; i++)
        {
            paneles[i] = transform.GetChild(i).gameObject;
            VisibilidadPanel(i, false);
        }
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
    public void VisibilidadPanel (int _indice, bool _estado)
    {
        paneles[_indice].SetActive(_estado);
    }

    public void Boton_Reanudar()
    {
        GameManager.instancia.EstablecerEstado(EstadosJuego.Jugando);
    }

    public void Boton_ReJugar()
    {
        GameManager.instancia.EstablecerEstado(EstadosJuego.Jugando);
    }

    public void Boton_VolverMenuInicio()
    {
        GameManager.instancia.EstablecerEstado(EstadosJuego.MenuInicio);
    }
#endregion
// -----------------------------------------------------------------

}
