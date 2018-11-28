using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AprobarRechazarNoticia : MonoBehaviour {

	[SerializeField]
	private GameObject TextoIdObjeto;

	public static Text Id;


	public void EnvioNoticiaAceptar()
	{
		StartCoroutine("AceptarNoticia");
	}
	public void EnvioNoticiaRechazar()
	{
		StartCoroutine("RechazarNoticia");
	}

	public IEnumerator RechazarNoticia()
	{
		Id = TextoIdObjeto.GetComponent<Text>();
		string GetURL = ControladorLogin.InicioUrl + "secretaria/rechazar";

		GetURL = GetURL + "?id_noticia=" + Id.text+"&estado=Rechazada";
		WWW getResultado = new WWW(GetURL);
		yield return getResultado;
		Debug.Log(getResultado.text);

		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("NoticiaxAprob");
		}
	}

	public IEnumerator AceptarNoticia()
	{
		Id = TextoIdObjeto.GetComponent<Text>();
		string GetURL = ControladorLogin.InicioUrl + "secretaria/aceptar";

		GetURL = GetURL + "?id_noticia=" + Id.text+"&estado=Aceptada";

		Debug.Log (GetURL);
		WWW getResultado = new WWW(GetURL);
		yield return getResultado;
		Debug.Log(getResultado.text);

		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("NoticiaxAprob");
		}
	}


}
