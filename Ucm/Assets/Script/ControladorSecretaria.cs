using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorSecretaria : MonoBehaviour {


	public string getURL = "http://localhost:8000/secretaria/mostrar_noticia";

	public Text noticiasmuestra;


	public void Start()
	{
		StartCoroutine ("MostrarNoticias");

	}

	private IEnumerator MostrarNoticias()
	{
		WWW getNoticia = new WWW (getURL);
		yield return getNoticia;
		Debug.Log (getNoticia.text);
		string JsonNoticia = getNoticia.text;


		ListaNoticia lista = JsonUtility.FromJson<ListaNoticia> (JsonNoticia);

		noticiasmuestra.text = lista.mostrar ();

	}

	public void CambioEscena(string escena) {
		SceneManager.LoadScene(escena);
	}
}

[System.Serializable]
public class Noticia
{
	public int id_noticia;
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

public class ListaNoticia
{
	public List<Noticia> noticias;

	public string mostrar()
	{
		string texto="";

		foreach (Noticia listaN in noticias)
		{
			texto = texto+"\n Titulo : "+listaN.titulo+"\n Texto: "+listaN.texto+"  \n Propietario:"+listaN.propietario+" \n   Fecha: "+listaN.updated_at+"\n" ;
		}

		return texto;
	}
}
