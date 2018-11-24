using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioEscena : MonoBehaviour {

    public InputField MensajeInput;
    public Text Mensaje;

    public void CambioE()
    {
        SceneManager.LoadScene("Perfil");
    }

    public void CambioVista(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }

    public void EnviarMensaje()
    {
        string URLmensaje = ControladorLogin.InicioUrl + "Mensaje";
        StartCoroutine(EnvioMensaje(URLmensaje));
    }

    public IEnumerator EnvioMensaje(string UrlMensaje)
    {
        UrlMensaje += "?id_remitente=" + ControladorLogin.Id + "&id_destinatario=" + Mensajeria.id_destinatario + "&texto=" + MensajeInput.text;
        WWW ResultadoMensaje = new WWW(UrlMensaje);
        Debug.Log(UrlMensaje);
        MensajeInput.text = "";
        yield return ResultadoMensaje;
        //LimpiarInput();
    }

}
