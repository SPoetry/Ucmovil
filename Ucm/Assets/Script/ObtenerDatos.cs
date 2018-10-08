using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObtenerDatos : MonoBehaviour {

    public string UrlConsulta = "http://localhost:8000/datos_d";

    public Text Dato1;
    public Text Dato2;
    public Text Dato3;
    public Text Dato4;
    public Text Dato5;
    public Text Dato6;

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
        Debug.Log(Tipo);

        if(Tipo == "secretarias"){
            UrlConsulta = "http://localhost:8000/datos_s";
        }
        if(Tipo == "alumnos"){
            UrlConsulta = "http://localhost:8000/datos_a";
        }
        if(Tipo == "profesores"){
            UrlConsulta = "http://localhost:8000/datos_p";
        }

        UrlConsulta = UrlConsulta + "?id=" + Id;
        UrlConsulta = UrlConsulta + "&tipo=" + Tipo;
        WWW ResultadoConsulta = new WWW(UrlConsulta);
        Debug.Log(UrlConsulta);
        yield return ResultadoConsulta;

        string Datos = ResultadoConsulta.text;
        string [] values = Datos.Split(","[0]);

        if(values[0] != null)
        {
            Dato1.text = values[1];
            Dato2.text = values[3];
            Dato3.text = values[2];

            if (Tipo == "directores_escuelas" || Tipo == "profesores")
            {
                Dato4.text = values[0];
            }
            if (Tipo == "alumnos")
            {
                Dato4.text = values[3];
                Dato5.text = values[4];
                Dato6.text = values[5];
            }
        }
        
    }
}
