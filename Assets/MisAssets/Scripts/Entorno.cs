using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// DESCRIPCION:
///
/// </summary>

public class Entorno : MonoBehaviour
{

    // -----------------------------------------------------------------
    #region 1) Definicion de Variables

    Vector3 posInicial;

#endregion
// -----------------------------------------------------------------
#region 2) Funciones Predeterminadas de Unity 
void Awake (){

        posInicial = transform.position;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -100f) transform.Translate(Vector3.left * Time.deltaTime);
        else transform.position += Vector3.right * transform.position.x;
        
    }
#endregion
// -----------------------------------------------------------------
#region 3) Metodos Originales

#endregion
// -----------------------------------------------------------------

}
