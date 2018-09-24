using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObtenerDatos : MonoBehaviour {

    public string UrlConsulta = "http://localhost:8000/datos_por_id";

    public string Id;
    public string Tipo;

    public void ObtencionDatos()
    {

        StartCoroutine("Consultar");
    }
    private IEnumerator Consultar()
    {
        
        UrlConsulta = UrlConsulta + "?id=" + Id;
        UrlConsulta = UrlConsulta + "&tipo=" + Tipo;
        WWW ResultadoConsulta = new WWW(UrlConsulta);
        yield return ResultadoConsulta;
        Debug.Log(ResultadoConsulta);

    }
}
