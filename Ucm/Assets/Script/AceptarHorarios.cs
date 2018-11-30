using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AceptarHorarios : MonoBehaviour {

	[SerializeField]
	private GameObject TextoIdObjeto;
	[SerializeField]
	private GameObject TextoModuloObjeto;

	public static Text Id;
	public static Text Modulo;


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
		Modulo= TextoModuloObjeto.GetComponent<Text>();
		string GetURL = ControladorLogin.InicioUrl + "secretaria/rechazar_horarios";
		GetURL = GetURL + "?id_ramo=" + Id.text +"&modulo="+ Modulo.text +"&estado=Rechazada";
		WWW getResultado = new WWW(GetURL);
		yield return getResultado;
		Debug.Log(getResultado.text);

		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("AceptarReHorario");
		}
	}

	public IEnumerator AceptarSolicitud()
	{
		Id = TextoIdObjeto.GetComponent<Text>();
		Modulo= TextoModuloObjeto.GetComponent<Text>();
		string GetURL = ControladorLogin.InicioUrl + "secretaria/aceptar_horarios";

		GetURL = GetURL + "?id_ramo=" + Id.text+"&modulo="+ Modulo.text +"&estado=Aceptada";

		Debug.Log (GetURL);
		WWW getResultado = new WWW(GetURL);
		yield return getResultado;
		Debug.Log(getResultado.text);

		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("AceptarReHorario");
		}
	}
}
