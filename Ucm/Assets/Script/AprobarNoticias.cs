using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AprobarNoticias : MonoBehaviour {

	public string getURL = ControladorLogin.InicioUrl;

	public GameObject Aprobarpref;
	public Text[] Campos;
	public Transform Ubicacion;


	float x = 0, y = -446;

	string id;
	string titulo;
	string texto;
	string propietario;
	string fecha;


	public void Start()
	{
		getURL += "secretaria/mostrar";
		StartCoroutine ("Mostrar");
	}

	public void Cambio() {
		StartCoroutine ("Aseptado");
	}

	private IEnumerator Aseptado()
	{
		string Url = ControladorLogin.InicioUrl;
		Url = Url+"secretaria/aseptar" + "?id_noticia=" + id +"&estado=Aprobado" ; 
		WWW newUrl = new WWW (Url);
		yield return newUrl;
		if (newUrl.text == "ok")
		{
			SceneManager.LoadScene("NoticiaxAprob");
		}

	}





	private IEnumerator Mostrar()
	{
		WWW getNoticia = new WWW (getURL);
		yield return getNoticia;
		Debug.Log (getNoticia.text);
		string JsonNoticia = getNoticia.text;


		ListaNoticia2 lista = JsonUtility.FromJson<ListaNoticia2>(JsonNoticia);
		List<Noticia2> NoticiasLista2 = lista.mostrar();

		foreach(Noticia2 Nota in NoticiasLista2)
		{
			GameObject nuevaNoticia = Instantiate(Aprobarpref, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
			nuevaNoticia.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
			y -= 500;
			Campos = nuevaNoticia.GetComponentsInChildren<Text>();

			foreach(Text Campo in Campos)
			{
				if (Campo.name == "Idnoticia")
				{
					Campo.text = Nota.id_noticia;
				}

				if(Campo.name == "Titulo")
				{
					Campo.text = Nota.titulo;
				}
				if(Campo.name == "Texto")
				{
					Campo.text = Nota.texto;
				}
				if(Campo.name == "propietario")
				{
					Campo.text = Nota.propietario;
				}
				if(Campo.name == "Fecha")
				{
					Campo.text = Nota.updated_at;
				}
			}
		}
	}


}

[System.Serializable]
public class Noticia2
{
	public string id_noticia;
	public string titulo;
	public string texto;
	public string estado;
	public string propietario;
	public object created_at; 
	public string updated_at;

	public override string ToString ()
	{
		return string.Format ("Titulo: {1}   Texto:  {2}   Propietario:  {4}   Fecha:  {7}", titulo, texto, propietario,updated_at);
	}
}

public class ListaNoticia2
{
	public List<Noticia2> noticias;

	public List<Noticia2> mostrar()
	{
		return noticias;
	}
}











