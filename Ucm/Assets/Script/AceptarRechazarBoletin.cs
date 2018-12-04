using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AceptarRechazarBoletin : MonoBehaviour {

	[SerializeField]
	private GameObject TextoIdObjeto;

	public static Text Id;


	public void EnvioBoletinAceptar()
	{
		StartCoroutine("AceptarBoletin");
	}


	public IEnumerator AceptarBoletin()
	{
		Id = TextoIdObjeto.GetComponent<Text>();
		string GetURL = ControladorLogin.InicioUrl + "secretaria/aceptarboletines";

		GetURL = GetURL + "?id=" + Id.text+"&estado=1";

		Debug.Log (GetURL);
		WWW getResultado = new WWW(GetURL);
		yield return getResultado;
		Debug.Log(getResultado.text);

		if (getResultado.text == "ok")
		{
			SceneManager.LoadScene("Boletines");
		}
	}
}
