using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnviarBoletin : MonoBehaviour {

    public InputField texto;
    public InputField asunto;
    public string UrlEnvioBoletin = ControladorLogin.InicioUrl + "profesor/enviar_boletin";
    private string Id;
    

    public void EnvioBoletin()
    {
        Id = ControladorLogin.Id;
        Debug.Log(Id);
        UrlEnvioBoletin = UrlEnvioBoletin + "?asunto=" + asunto.text + "&contenido=" + texto.text + "&id_profe=" + Id;
        WWW ingreso = new WWW(UrlEnvioBoletin);
        Debug.Log(UrlEnvioBoletin);
        StartCoroutine(IngresoBoletin(ingreso));
    }

    public IEnumerator IngresoBoletin(WWW ingreso)
    {
        yield return ingreso;
        SceneManager.LoadScene("Lobby");
    }
}
