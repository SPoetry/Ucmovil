using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MostrarBoletin : MonoBehaviour {



	public string getURL = ControladorLogin.InicioUrl;

	public GameObject BoletinPrefab;
	public Text[] Campos;
	public Transform Ubicacion;


	float x = 0, y = 1280;


	string id;
	string asunto;
	string contenido;
	string propietario;
	string fecha;

	public void Start()
	{
		getURL += "secretaria/mostrar_boletin";
		StartCoroutine ("MostrarBoletinSecre");

	}

	private IEnumerator MostrarBoletinSecre()
	{
		WWW getBoletin = new WWW (getURL);
		yield return getBoletin;
		Debug.Log (getBoletin.text);
		string JsonBoletin = getBoletin.text;


		ListaBoletin2 lista = JsonUtility.FromJson<ListaBoletin2>(JsonBoletin);
		List<Boletin2> BoletinLista = lista.mostrar();

		foreach(Boletin2 Nota in BoletinLista)
		{
			GameObject nuevoBoletin = Instantiate(BoletinPrefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
			nuevoBoletin.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
			y -= 500;
			Campos = nuevoBoletin.GetComponentsInChildren<Text>();

			foreach(Text Campo in Campos)
			{
				if(Campo.name == "Id")
				{
					Campo.text = Nota.id;
				}
				if(Campo.name == "Asunto")
				{
					Campo.text = Nota.asunto;
				}
				if(Campo.name == "Propietario")
				{
					Campo.text = Nota.propietario;
				}
				if(Campo.name == "Contenido")
				{
					Campo.text = Nota.contenido;
				}

				if(Campo.name == "Fecha")
				{
					Campo.text = Nota.updated_at;
				}
			}
		}
	}

	public void CambioEscena(string escena) {
		SceneManager.LoadScene(escena);
	}
}

[System.Serializable]
public class Boletin2
{
	public string id;

	public string asunto;
	public string contenido;
	public string propietario;
	public string updated_at;


	public override string ToString ()
	{
		return string.Format ("Titulo: {1}   Texto:  {2}   Propietario:  {4}   Fecha:  {7}", asunto, contenido, propietario,updated_at);
	}
}

public class ListaBoletin2
{
	public List<Boletin2> boletiness;

	public List<Boletin2> mostrar()
	{
		return boletiness;
	}



}
