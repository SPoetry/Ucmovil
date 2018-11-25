using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mensajeria : MonoBehaviour {

    public static string id_destinatario;
    public GameObject ChatPrefab;
    public Transform Ubicacion;
    public Text[] Componentes;
    
    string nombre;
    int id;

    float x = 0, y = 1434;
    string URLChats = ControladorLogin.InicioUrl;
    
	void Start () {
        URLChats += ControladorLogin.Tipo + "/Mensajeria?id=" + ControladorLogin.Id;
        StartCoroutine("CargaMensajeria");
	}

    public IEnumerator CargaMensajeria()
    {
        WWW ResultadoMensajeria = new WWW(URLChats);
        yield return ResultadoMensajeria;
        string JsonProfesores = ResultadoMensajeria.text;
        Listaprofesores ListaProfes = JsonUtility.FromJson<Listaprofesores>(JsonProfesores);
        List<Profesores> Profes = ListaProfes.mostrar();

        foreach(Profesores Profe in Profes)
        {
            GameObject NuevoChat = Instantiate(ChatPrefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
            NuevoChat.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
            y -= 200;

            Componentes = NuevoChat.GetComponentsInChildren<Text>();

            foreach(Text Componente in Componentes)
            {
                if(Componente.name == "Nombre")
                {
                    Componente.text += Profe.nombre;
                }
                if(Componente.name == "ID")
                {
                    Componente.text = Profe.id.ToString();
                }
            }
        }
    }
}

[System.Serializable]
public class Profesores
{
    public string nombre;
    public int id;

}

public class Listaprofesores
{
    public List<Profesores> profesores;

    public List<Profesores> mostrar()
    {
        return profesores;
    }
}