using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class nuevosoli : MonoBehaviour {

	public string getURL = ControladorLogin.InicioUrl;

	public GameObject solicitudesprefab;
	public Text[] Campos;
	public Transform Ubicacion;


	float x = 0, y = 1280;

	string id;
	string solicitud;
	string texto;
	string fecha;


	public void Start()
	{
		getURL += "secretaria/solicitudes";
		StartCoroutine ("Solicitudes");
	}




	private IEnumerator Solicitudes()
	{
		WWW getSolicitud = new WWW (getURL);
		yield return getSolicitud;
		Debug.Log (getSolicitud.text);
		string JsonSolicitud = getSolicitud.text;


		ListaSolicitud lista = JsonUtility.FromJson<ListaSolicitud>(JsonSolicitud);
		List<Solicitudes> listaSolicituds = lista.mostrar();


		foreach(Solicitudes Solic in listaSolicituds)
		{
			Debug.Log ("entro");

			GameObject nuevaSolicitud = Instantiate(solicitudesprefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
			nuevaSolicitud.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
			y -= 313;
			Campos = nuevaSolicitud.GetComponentsInChildren<Text>();

			foreach(Text Campo in Campos)
			{
				if (Campo.name == "Id")
				{
					Campo.text = Solic.id_solicitante;
				}

				if(Campo.name == "Solicitud")
				{
					Campo.text = Solic.solicitud;
				}
				if(Campo.name == "Texto")
				{
					Campo.text = Solic.texto;
				}
				if(Campo.name == "Fecha")
				{
					Campo.text = Solic.updated_at;
				}
			}
		}
	}


}

[System.Serializable]
public class Solicitudes
	{
		public string id;
		public string id_solicitante;
		public string solicitud;
		public string texto;
		public object created_at; 
		public string updated_at;

		public override string ToString ()
		{
			return string.Format ("id_solicitante: {1}   Solicitud:  {2}   Texto:  {3}   Fecha:  {4}", id_solicitante, solicitud, texto,updated_at);
		}
	}

	public class ListaSolicitud
	{
	public List<Solicitudes> solicitudes;

	public List<Solicitudes> mostrar()
		{
			return solicitudes;
		}
	}

