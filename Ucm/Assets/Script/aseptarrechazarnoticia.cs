using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class aseptarrechazarnoticia : MonoBehaviour {


	[SerializeField]
	private GameObject TextoId;



	public static Text Id;



	public void EnvioAseptar()
	{
		StartCoroutine("EnvioNoticiasAseptar");

	}

	public void Enviorechazo()
	{
		StartCoroutine("EnvioNoticiasrechaza");

	}


	public IEnumerator EnvioNoticiasAseptar()
	{
		Id = TextoId.GetComponent<Text>();
		string GetURL = "http://localhost:8000/secretaria/aceptar" + "?id_noticia="+ Id.text+"&estado=Aceptado";
		WWW getResultado = new WWW(GetURL);
		yield return getResultado;
		Debug.Log(getResultado.text);

		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("NoticiaxAprob");
		}
	}


	public IEnumerator EnvioNoticiasrechazada()
	{
		Id = TextoId.GetComponent<Text>();
		string GetURL = "http://localhost:8000/secretaria/rechazo" + "?id_noticia="+ Id.text+"&estado=Rechazada";
		WWW getResultado = new WWW(GetURL);
		yield return getResultado;
		Debug.Log(getResultado.text);

		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("NoticiaxAprob");
		}
	}





}
