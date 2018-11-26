using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorSecretaria : MonoBehaviour {

    public string getURL = ControladorLogin.InicioUrl;

    public GameObject NoticiaPrefab;
    public Text[] Campos;
    public Transform Ubicacion;


    float x = 0, y = 1280;

    string titulo;
    string texto;
    string propietario;
    string fecha;

	public void Start()
	{
        getURL += "secretaria/mostrar_noticia";
        StartCoroutine ("MostrarNoticias");
	}

	private IEnumerator MostrarNoticias()
	{
		WWW getNoticia = new WWW (getURL);
		yield return getNoticia;
		Debug.Log (getNoticia.text);
		string JsonNoticia = getNoticia.text;


		ListaNoticia lista = JsonUtility.FromJson<ListaNoticia>(JsonNoticia);
        List<Noticia> NoticiasLista = lista.mostrar();

        foreach(Noticia Nota in NoticiasLista)
        {
            GameObject nuevaNoticia = Instantiate(NoticiaPrefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
            nuevaNoticia.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
            y -= 500;
            Campos = nuevaNoticia.GetComponentsInChildren<Text>();

            foreach(Text Campo in Campos)
            {
                if(Campo.name == "Titulo")
                {
                    Campo.text = Nota.titulo;
                }
                if(Campo.name == "Texto")
                {
                    Campo.text = Nota.texto;
                }
                if(Campo.name == "Propietario")
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

	public List<Noticia> mostrar()
	{
        return noticias;
	}
}
