using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cambio : MonoBehaviour {

    string UrlCambioC = ControladorLogin.InicioUrl + "cambioC";
    string UrlCA = ControladorLogin.InicioUrl + "cambioA";
    string UrlCaE = ControladorLogin.InicioUrl + "cambioE";

    public string Id;
    public string Tipo;
    public string Escena;
    public InputField Dato;

    public void EnvioCambioA()
    {
        StartCoroutine("CambiarA");
    }
    private IEnumerator CambiarA()
    {
        Id = ControladorLogin.Id;
        Tipo = ControladorLogin.Tipo;
        UrlCA = UrlCA + "?id=" + Id;
        UrlCA = UrlCA + "&apodo=" + Dato.text;
        UrlCA = UrlCA + "&tipo=" + Tipo;
        WWW RespuestaA = new WWW(UrlCA);
        Debug.Log(UrlCA);
        Dato.text = "";
        UrlCA = "";
        yield return RespuestaA;

        if (RespuestaA.text == "ok")
        {
            SceneManager.LoadScene(Escena);
        }
    }
    
    
}
