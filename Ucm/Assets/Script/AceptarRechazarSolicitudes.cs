using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AceptarRechazarSolicitudes : MonoBehaviour {


	[SerializeField]
	private GameObject TextoId;



	public static Text Id;


	public void EnvioAseptarSoli()
	{
		StartCoroutine("EnvioSolicitudesAseptar");

	}

	public void EnviorechazoSoli()
	{
		StartCoroutine("EnvioSolicitudesrechaza");

	}


	public IEnumerator EnvioSolicitudesAseptar()
	{
		Id = TextoId.GetComponent<Text>();
		string GetURL = "http://localhost:8000/secretaria/solicitudesaceptado" + "?id="+ Id.text+"&estado=Aceptada";
		WWW getResultado = new WWW(GetURL);
		yield return getResultado;
		Debug.Log(getResultado.text);

		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("Solicitudes");
		}
	}


	public IEnumerator EnvioSolicitudesrechazada()
	{
		Id = TextoId.GetComponent<Text>();
		string GetURL = "http://localhost:8000/secretaria/solicitudesrechazo" + "?id="+ Id.text+"&estado=Rechazada";
		WWW getResultado = new WWW(GetURL);
		yield return getResultado;
		Debug.Log(getResultado.text);

		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("Solicitudes");
		}
	}





}
