using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateNoticia : MonoBehaviour {

	string postURL2 = ControladorLogin.InicioUrl + "secretaria/editar_noticia";

	public InputField idnoticia;
	public InputField Titulo;
	public InputField Texto;
	public InputField Estado;
	public InputField Propietario;

	public void Editarnoticia()
	{
		StartCoroutine ("EditarNoticia");
	}


	private IEnumerator EditarNoticia()
	{
		postURL2 = postURL2 +"?id_noticia="+ idnoticia.text + "&titulo=" + Titulo.text + "&texto=" + Texto.text +  "&estado=" + Estado.text + "&propietario=" + Propietario.text;
		Debug.Log (postURL2);
		WWW getResultado = new WWW (postURL2);
		yield return getResultado;
		Debug.Log (getResultado.text);
		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("Lobby");
		}
	}
}
