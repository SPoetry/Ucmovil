using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorLogin : MonoBehaviour {

    public string getURL = "http://localhost:8000/log";

    public InputField Correo;
    public InputField Contrasena;

    public static string Id;
    public static string Tipo;

    public void EnvioDatos()
    {
        StartCoroutine("Logear");
    }
    private IEnumerator Logear()
    {
        getURL = getURL + "?email=" + Correo.text;
        getURL = getURL + "&password=" + Contrasena.text;
        Correo.text = "";
        Contrasena.text = "";
        WWW getResultado = new WWW(getURL);
        Debug.Log(getURL);
        yield return getResultado;
        Debug.Log(getResultado.text);
        string Datos = getResultado.text;
        string[] values = Datos.Split(","[0]);

        if (values[0] != "no")
        {
            Id = values[0];
            if (values[1] == "alumno")
            {
                Tipo = "alumnos";
            }
            else if (values[1] == "secretaria")
            {
                Tipo = "secretarias";
            }
            else if (values[1] == "profesor")
            {
                Tipo = "profesores";
            }
            else if (values[1] == "director_carrera")
            {
                Tipo = "directores_carreras";
            }


            if (values[1] == "director_carrera")
            {
                SceneManager.LoadScene(1);
            }
            if (values[1] == "secretaria")
            {
                SceneManager.LoadScene(2);
            }
            if (values[1] == "profesor")
            {
                SceneManager.LoadScene(3);
            }
            if (values[1] == "alumno")
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
