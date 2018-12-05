using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HorariosporAprobar : MonoBehaviour {

	string getURL = ControladorLogin.InicioUrl;

	public GameObject horariosPrefab;
	public Text[] Campos;
	public Transform Ubicacion;


	float x = 0, y = 1280;

	string id;
	string modulo;
	string sala;
	string dia;
	string fecha;

	public void Start()
	{
		getURL += "secretaria/mostrar_horarios";
		StartCoroutine ("MostrarHorarios");
	}

	private IEnumerator MostrarHorarios()
	{
		WWW getHorarios = new WWW (getURL);
		yield return getHorarios;
		Debug.Log (getHorarios.text);
		string JsonHorarios = getHorarios.text;


		ListaHorarios lista = JsonUtility.FromJson<ListaHorarios>(JsonHorarios);
		List<Horarios> HorariosLista2 = lista.mostrar();

		foreach(Horarios Secre in HorariosLista2)
		{
			Debug.Log("entro");
			GameObject nuevaHorario = Instantiate(horariosPrefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
			nuevaHorario.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
			y -= 135;
			Campos = nuevaHorario.GetComponentsInChildren<Text>();

			foreach(Text Campo in Campos)
			{
				if(Campo.name == "idramo")
				{
					Campo.text = Secre.id_ramo;
				}
				if(Campo.name == "modulo")
				{
					Campo.text = Secre.modulo;
				}
				if(Campo.name == "dia")
				{
					Campo.text = Secre.dia;
				}
				if(Campo.name == "Sala")
				{
					Campo.text = Secre.sala;
				}

			}
		}
	}

	public void CambioEscena(string escena) {
		SceneManager.LoadScene(escena);
	}
}

[System.Serializable]
public class Horarios
{
	public string id_ramo;
	public string modulo;
	public string dia;
	public string sala;


}

public class ListaHorarios
{
	public List<Horarios> horarios;

	public List<Horarios> mostrar()
	{
		return horarios;
	}
}

