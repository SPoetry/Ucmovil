using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Solicitud : MonoBehaviour {

    string Id;
    public Text Texto;
    public Text Solicitar;
    string estado = "Pendiente";
    string UrlSolicitud;

    void Start () {
        Id = ControladorLogin.Id;
	}
	
    public void EnviarSolicitud()
    {
        UrlSolicitud = ControladorLogin.InicioUrl + "Solicitud?id=" + Id +"&solicitud="+ Solicitar.text + "&texto=" +Texto.text + "&estado=" + estado;

        StartCoroutine("SolicitudNoticia");
    }
    public IEnumerator SolicitudNoticia()
    {
        WWW getResultado = new WWW(UrlSolicitud);
        Debug.Log(UrlSolicitud);
        yield return getResultado;
        Debug.Log(getResultado.text);

        if (getResultado.text == "ok")
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
