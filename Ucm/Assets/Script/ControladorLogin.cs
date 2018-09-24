using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorLogin : MonoBehaviour {

    public string getURL = "http://localhost:8000/log";

    public InputField Correo;
    public InputField Contrasena;

    public void EnvioDatos()
    {
        StartCoroutine("Logear");
    }
    private IEnumerator Logear()
    {
        getURL = getURL + "?email=" + Correo.text;
        getURL = getURL + "&password=" + Contrasena.text;
        WWW getResultado = new WWW(getURL);
        yield return getResultado;
        Debug.Log(getResultado.text);
        if (getResultado.text == "director_carrera")
        {
            SceneManager.LoadScene(1);
        }
    }
}
