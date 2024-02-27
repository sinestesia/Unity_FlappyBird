using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class GameManager : MonoBehaviour
{

    // -----------------------------------------------------------------
    #region 1) Definicion de Variables
    public static GameManager instancia;

    public EstadosJuego estadoPrevio;
    public EstadosJuego estadoActual;
#endregion
    // -----------------------------------------------------------------
    #region 2) Funciones Predeterminadas de Unity 
void Awake (){

        if (instancia == null)
        {
            // Se crea la figura del GameManager en mi juego
            instancia = this;
            DontDestroyOnLoad(gameObject);

            // una vez creado, se activa su primer hijo en la jerarquía para
            // que se crean el resto de gestores
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else Destroy(gameObject);
	}

    // Start is called before the first frame update
    void Start()
    {
        EstablecerEstadoActualSegunEscena();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (estadoActual == EstadosJuego.Jugando)
            {
                EstablecerEstado(EstadosJuego.JuegoPausado);
            }
            else if (estadoActual == EstadosJuego.JuegoPausado) EstablecerEstado(EstadosJuego.Jugando);
        }
    }
#endregion
    // -----------------------------------------------------------------
    #region 3) Metodos Originales
    public void EstablecerEstado (EstadosJuego _nuevoEstado)
    {
        estadoPrevio = estadoActual;
        estadoActual = _nuevoEstado;

        switch (estadoActual)
        {
            // -----------------------------------------------------------------
            case EstadosJuego.Ninguno:

                break;
            // -----------------------------------------------------------------
            case EstadosJuego.MenuInicio:

                Time.timeScale = 1f;

                if (estadoPrevio == EstadosJuego.JuegoFinalizado) SceneManager.LoadScene(0);

                break;
            // -----------------------------------------------------------------
            case EstadosJuego.Jugando:

                Time.timeScale = 1f;

                if (estadoPrevio == EstadosJuego.MenuInicio || estadoPrevio == EstadosJuego.JuegoFinalizado) SceneManager.LoadScene(1);
                break;
            // -----------------------------------------------------------------
            case EstadosJuego.JuegoPausado:

                Time.timeScale = 0f;

                break;
            // -----------------------------------------------------------------
            case EstadosJuego.JuegoFinalizado:

                Time.timeScale = 0f;
                MiPersonaje.instancia.DesactivarPersonaje();

                if (PlayerDataManager.instancia.RecordSuperado())
                {
                    Debug.Log("Enhorabuena, record superado");
                }
                else
                {
                    Debug.Log("Record no superado, sigue intentandolo");
                }

                GameplayPanelesManager.instancia.VisibilidadPanel(0, false);
                GameplayPanelesManager.instancia.VisibilidadPanel(1, true);

                break;
            // -----------------------------------------------------------------
        }
    }

    void EstablecerEstadoActualSegunEscena()
    {
        int indexEscena = SceneManager.GetActiveScene().buildIndex;

        if (indexEscena == 0) EstablecerEstado(EstadosJuego.MenuInicio);
        else EstablecerEstado(EstadosJuego.Jugando);
    }


    #endregion
    // -----------------------------------------------------------------
}

public enum EstadosJuego
{
    Ninguno,
    MenuInicio,
    Jugando,
    JuegoPausado,
    JuegoFinalizado
}
