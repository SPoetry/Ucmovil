using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensajeriaC : MonoBehaviour {

    public static string id_destinatario;
    public GameObject ChatPrefab;
    public Transform Ubicacion;
    Text[] Componentes;

    string nombre;
    int id;

    float x = 0, y = 1434;
    string URLChats = ControladorLogin.InicioUrl;

    void Start()
    {
        URLChats += ControladorLogin.Tipo + "/MensajeriaC?id=" + ControladorLogin.Id;
        StartCoroutine("CargaMensajeriaCurso");
    }

    public IEnumerator CargaMensajeriaCurso()
    {
        WWW ResultadoMensajeria = new WWW(URLChats);
        yield return ResultadoMensajeria;
        string JsonProfesores = ResultadoMensajeria.text;
        Listaramos ListaRamos = JsonUtility.FromJson<Listaramos>(JsonProfesores);
        List<Ramos> ramosmios = ListaRamos.mostrar();

        foreach (Ramos ramo in ramosmios)
        {
            GameObject NuevoChat = Instantiate(ChatPrefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
            NuevoChat.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
            y -= 200;
            Componentes = NuevoChat.GetComponentsInChildren<Text>();

            foreach (Text Componente in Componentes)
            {
                if (Componente.name == "Nombre")
                {
                    Componente.text += ramo.nombre;
                }
                if (Componente.name == "ID")
                {
                    Debug.Log(ramo.id_asignatura);
                    Componente.text = ramo.id_asignatura;
                }
            }
        }
    }
}

[System.Serializable]
public class Ramos
{
    public string id_asignatura;
    public string nombre;

}

public class Listaramos
{
    public List<Ramos> ramos;

    public List<Ramos> mostrar()
    {
        return ramos;
    }
}