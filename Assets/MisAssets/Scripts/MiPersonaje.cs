using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class MiPersonaje : MonoBehaviour
{
    // -----------------------------------------------------------------
    #region 1) Definicion de Variables
    public static MiPersonaje instancia;

    Rigidbody2D rb;

    [Range(0f, 2f)]
    public float alturaMax;
    #endregion
    // -----------------------------------------------------------------
    #region 2) Funciones Predeterminadas de Unity 
    void Awake (){

        instancia = this;
        rb = GetComponent<Rigidbody2D> ();
	}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { 
            Saltar();
            SoundManager.instancia.SonidoVolar();
        } 

        Rotacion();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstaculos") && GameManager.instancia.estadoActual != EstadosJuego.JuegoFinalizado)
        {
            GameManager.instancia.EstablecerEstado(EstadosJuego.JuegoFinalizado);
            SoundManager.instancia.SonidoMorir();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puntos"))
        {
            Debug.Log("Puntua");
            PlayerDataManager.instancia.AgregarPuntos(5);
            SoundManager.instancia.SonidoTuberiaSuperada();
        }
    }
    #endregion
    // -----------------------------------------------------------------
    #region 3) Metodos Originales
    void Saltar()
    {
        rb.velocity = Vector2.zero;

        float _fuerzaSalto = Mathf.Sqrt(alturaMax * -3 * (Physics2D.gravity.y * rb.gravityScale));
        rb.AddForce(Vector2.up * _fuerzaSalto, ForceMode2D.Impulse);

    }

    public void DesactivarPersonaje()
    {
        gameObject.SetActive(false);
    }

    void Rotacion()
    {
        float _rot = rb.velocity.y * 30f;
        _rot = Mathf.Clamp(_rot, -30f, 30f);

        Quaternion _rotActual = transform.rotation;
        Quaternion _rotFinal = Quaternion.Euler(Vector3.forward * _rot);

        Quaternion _rotGradual = Quaternion.RotateTowards(_rotActual, _rotFinal, 650f * Time.deltaTime);

        transform.rotation = _rotGradual;
    }
    #endregion
    // -----------------------------------------------------------------
}
