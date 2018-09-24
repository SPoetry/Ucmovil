using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioE : MonoBehaviour {


    public string UrlCaE = "http://localhost:8000/cambioE";
    public string Id;
    public string Tipo;
    public string Escena;
    public InputField Dato;

    public void EnvioCambioE()
    {
        StartCoroutine("CambiarE");
    }
    private IEnumerator CambiarE()
    {
        Id = ControladorLogin.Id;
        Tipo = ControladorLogin.Tipo;
        UrlCaE = UrlCaE + "?id=" + Id;
        UrlCaE = UrlCaE + "&email=" + Dato.text;
        UrlCaE = UrlCaE + "&tipo=" + Tipo;
        WWW RespuestaE = new WWW(UrlCaE);
        Dato.text = "";
        UrlCaE = "";
        yield return RespuestaE;

        if (RespuestaE.text == "ok")
        {
            SceneManager.LoadScene(Escena);
        }
    }
}
