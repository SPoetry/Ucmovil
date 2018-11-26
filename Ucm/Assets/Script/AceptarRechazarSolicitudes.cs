using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AceptarRechazarSolicitudes : MonoBehaviour {


	[SerializeField]
	private GameObject TextoIdObjeto;

	public static Text Id;


	public void EnvioSolicitudAceptar()
	{
		StartCoroutine("AceptarSolicitud");
	}
	public void EnvioSolicitudRechazar()
	{
		StartCoroutine("RechazarSolicitud");
	}

	public IEnumerator RechazarSolicitud()
	{
		Id = TextoIdObjeto.GetComponent<Text>();
		string GetURL = "http://localhost:8000/secretaria/solicitudesrechazo";

		GetURL = GetURL + "?id=" + Id.text+"&estado=Rechazada";
		WWW getResultado = new WWW(GetURL);
		yield return getResultado;
		Debug.Log(getResultado.text);

		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("NoticiaxAprob");
		}
	}

	public IEnumerator AceptarSolicitud()
	{
		Id = TextoIdObjeto.GetComponent<Text>();
		string GetURL = "http://localhost:8000/secretaria/solicitudesaceptado";

		GetURL = GetURL + "?id=" + Id.text+"&estado=Aceptada";

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
