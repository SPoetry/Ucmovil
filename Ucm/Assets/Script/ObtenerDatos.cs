using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObtenerDatos : MonoBehaviour {

    public string UrlDatos = ControladorLogin.InicioUrl + "datos_d";

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
            UrlDatos = ControladorLogin.InicioUrl + "datos_s";
        }
        if(Tipo == "alumnos"){
            UrlDatos = ControladorLogin.InicioUrl + "datos_a";
        }
        if(Tipo == "profesores"){
            UrlDatos = ControladorLogin.InicioUrl + "datos_p";
        }

        UrlDatos = UrlDatos + "?id=" + Id;
        UrlDatos = UrlDatos + "&tipo=" + Tipo;
        WWW ResultadoConsulta = new WWW(UrlDatos);

        yield return ResultadoConsulta;

        string Datos = ResultadoConsulta.text;
        string [] values = Datos.Split(","[0]);

        if(values[0] != null)
        {
            Dato1.text = values[0];
            Dato2.text = values[1];
            Dato3.text = values[2];

            if (Tipo == "directores_escuelas" || Tipo == "profesores")
            {
                Dato4.text = values[4];
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
