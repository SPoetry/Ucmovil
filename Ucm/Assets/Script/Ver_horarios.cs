using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ver_horarios : MonoBehaviour
{
    [SerializeField]
    private GameObject Modulo;
    [SerializeField]
    private Transform Modulos;
    [SerializeField]
    private GameObject Descripcion;

    public GameObject[] Prefabs;
    public Text[] Componentes;
    public Text[] Atributos;

    private readonly string id_profe = ControladorLogin.Id;
    public string UrlObtencionHorario = ControladorLogin.InicioUrl + "profesor/obtener_horario";
    Vector3 newSize = new Vector3(1.423022f, 1.423022f, 1.423022f);
    Color32 newColor = new Color32(0, 208, 227, 255);
    Vector3 Size0 = new Vector3(0, 0, 0);
    Vector3 Size1 = new Vector3(1, 1, 1);


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i<60; i++)
        {
            GameObject CuadroModulo = Instantiate(Modulo) as GameObject;
            CuadroModulo.transform.SetParent(Modulos.transform);
            CuadroModulo.transform.localScale = newSize;    
            Prefabs[i] = CuadroModulo;

        }

        StartCoroutine("CargarHorario");
    }

    public IEnumerator CargarHorario()
    {
        UrlObtencionHorario = UrlObtencionHorario + "?id_profe=2";
        WWW request = new WWW(UrlObtencionHorario);
        yield return request;
        string datos = request.text;
        ListaHorarios listahorarios = JsonUtility.FromJson<ListaHorarios>(datos);
        Debug.Log(datos);
        foreach (Horario horario in listahorarios.Enumerar())
        {
            int i = horario.modulo + Posicion(horario.dia) - 1;
            Debug.Log(i);
            Componentes = Prefabs[i].GetComponentsInChildren<Text>();
            Componentes[0].text = horario.nombre;
            Componentes[1].text = horario.id_asignatura;
            Componentes[2].text = horario.sala;
            Prefabs[i].GetComponent<Image>().color = newColor;
        }

    }

    private int Posicion(string dia) {
        if (dia == "Lunes") { return 0; }
        if (dia == "Martes") { return 12; }
        if (dia == "Miercoles") { return 24; }
        if (dia == "Jueves") { return 36; }
        if (dia == "Viernes") { return 48; }
        return 0;
    }

    public void Describir(GameObject boton)
    {
        Text[] campos = boton.GetComponentsInChildren<Text>();
        Descripcion = GameObject.FindWithTag("Descripcion");
        Atributos = Descripcion.GetComponentsInChildren<Text>();
        Atributos[3].text = campos[0].text;
        Atributos[4].text = campos[1].text;
        Atributos[5].text = campos[2].text;
        Descripcion.transform.localScale = Size1;

    }

    public void ocultar()
    {
        Descripcion = GameObject.FindWithTag("Descripcion");
        Descripcion.transform.localScale = Size0;
    }


    [System.Serializable]
    public class Horario
    {
        public string nombre;
        public string id_asignatura;
        public int modulo;
        public string sala;
        public string dia;
    }
    [System.Serializable]
    public class ListaHorarios
    {
        public List<Horario> horarios;
        public List<Horario> Enumerar()
        {
            return horarios;
        }
    }

}