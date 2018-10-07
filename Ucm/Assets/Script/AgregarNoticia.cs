﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AgregarNoticia : MonoBehaviour {

	public string postURL2 = "http://localhost:8000/secretaria/agregar_noticia";

	public InputField Titulo;
	public InputField Texto;
	public InputField Estado;
	public InputField Propietario;

	public void Enviodedatos()
	{
		StartCoroutine ("GuardarNoticia");
	}
	public void mostrar()
	{
		StartCoroutine ("MostrarNoticia");
	}

	private IEnumerator GuardarNoticia()
	{
		postURL2 = postURL2 + "?titulo=" + Titulo.text + "&texto=" + Texto.text +  "&estado=" + Estado.text + "&propietario=" + Propietario.text;
		Debug.Log (postURL2);
		WWW getResultado = new WWW (postURL2);
		yield return getResultado;
		Debug.Log (getResultado.text);
		postURL2 = "http://localhost:8000/secretaria/agregar_noticia";

        if (getResultado.text == "ok")
        {
            SceneManager.LoadScene("Lobby");
        }
	}




}