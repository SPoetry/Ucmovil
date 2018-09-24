using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObtenerDatos : MonoBehaviour {

    public string UrlConsulta = "http://localhost:8000/datos_por_id";

    public Text Especialidad;
    public Text Nombre;
    public Text Telefono;

    public string Id;
    public string Tipo;

    void Start()
    {

        StartCoroutine("Consultar");
    }
    private IEnumerator Consultar()
    {
        Id = ControladorLogin.Id;
        Tipo = ControladorLogin.Tipo;
        UrlConsulta = UrlConsulta + "?id=" + Id;
        UrlConsulta = UrlConsulta + "&tipo=" + Tipo;
        WWW ResultadoConsulta = new WWW(UrlConsulta);
        yield return ResultadoConsulta;

        string Datos = ResultadoConsulta.text;
        string[] values = Datos.Split(","[0]);

        Especialidad.text = values[0];
        Nombre.text = values[1];
        Telefono.text = values[2];
    }
}
