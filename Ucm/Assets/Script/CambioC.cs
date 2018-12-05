using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioC : MonoBehaviour {

    string UrlCambioC = ControladorLogin.InicioUrl + "cambioC";

    public string Id;
    public string Tipo;
    public string Escena;
    public InputField Dato;

    public void EnvioCambioC()
    {
        StartCoroutine("CambiarC");
    }
    private IEnumerator CambiarC()
    {
        Id = ControladorLogin.Id;
        Tipo = ControladorLogin.Tipo;
        UrlCambioC = UrlCambioC + "?id=" + Id;
        UrlCambioC = UrlCambioC + "&password=" + Dato.text;
        UrlCambioC = UrlCambioC + "&tipo=" + Tipo;
        WWW Respuesta = new WWW(UrlCambioC);
        Dato.text = "";
        UrlCambioC = "";
        yield return Respuesta;

        if (Respuesta.text == "ok")
        {
            SceneManager.LoadScene(Escena);
        }
    }
}
