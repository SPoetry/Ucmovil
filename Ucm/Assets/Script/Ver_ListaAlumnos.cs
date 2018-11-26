using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ver_ListaAlumnos : MonoBehaviour {

    public string UrlListaAlumnos = "http://localhost:8000/ListaAlumnos";
    public Text[] Componentes;
    public Text titulo;

    [SerializeField]
    private GameObject PanelAlumno;
    [SerializeField]
    private Transform Contenedor;

    public void Awake()
    {
        titulo.text = "Alumnos: " + AlumNotas.nombre;
        StartCoroutine("ListarAlumnos");
    }

    public IEnumerator ListarAlumnos()
    {
        string id = AlumNotas.id;
        UrlListaAlumnos = UrlListaAlumnos + "?id="+id;
        WWW ResultadoConsulta = new WWW(UrlListaAlumnos);
        Debug.Log(UrlListaAlumnos);
        yield return ResultadoConsulta;
        string Datos = ResultadoConsulta.text;
        ListaAlumnos lista = JsonUtility.FromJson<ListaAlumnos>(Datos);

        foreach (Alumno alumno in lista.Enumerar())
        {
            GameObject CuadroAlumno = Instantiate(PanelAlumno) as GameObject;
            CuadroAlumno.transform.SetParent(Contenedor.transform);

            Componentes = CuadroAlumno.GetComponentsInChildren<Text>();

            Componentes[0].text = alumno.id.ToString();
            Componentes[1].text = alumno.nombre;


            //CuadroAlumno.GetComponent<RectTransform>().localScale = new Vector2(1.0F, 1.0F);
        }


    }


}

[System.Serializable]
public class Alumno
{
    public int id;
    public string nombre;
}

[System.Serializable]
public class ListaAlumnos
{
    public List<Alumno> alumnos;
    public List<Alumno> Enumerar()
    {
        return alumnos;
    }
}