using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerDatos : MonoBehaviour {

    public string getURL = "http://localhost:8000/tipo_por_id";

    private void Start()
    {
        StartCoroutine("Consulta");
    }

    private IEnumerator Consulta()
    {
        Debug.Log(getURL);
        WWW getResultado = new WWW(getURL);
        yield return getResultado;
        Debug.Log(getResultado.text);
    }
}
