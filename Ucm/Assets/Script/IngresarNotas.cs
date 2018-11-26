using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngresarNotas : MonoBehaviour {

    public Text titulo;
    public GameObject panelNotas;
    public InputField[] notas;
    public Text[] ponderaciones;
    public string UrlObtencionNotas = "http://localhost:8000/ObtenerNotas";
    private string id_alumno;
    private string id_ramo;

    public void Awake()
    {
        StartCoroutine("precarga");
        /*      titulo.text = AlumNotas.nombre + ": Notas del alumno " + AlumNotas.nombre_alumno;
        notas = panelNotas.GetComponentsInChildren<InputField>();
        foreach (InputField cuadroNota in notas)
        {
            cuadroNota.text="0";
        }
        ponderaciones = panelNotas.GetComponentsInChildren<Text>();
        foreach (Text cuadroPonderacion in ponderaciones){
            if (cuadroPonderacion.CompareTag("Notas"))
            {
                cuadroPonderacion.text = "0";
            }
        }
*/

    }

    public IEnumerator precarga(){
        id_alumno = AlumNotas.id_alumno;
        id_ramo = AlumNotas.id;
        UrlObtencionNotas = UrlObtencionNotas + "?id_a=1&id_c=1";
        WWW ResultadoConsulta = new WWW(UrlObtencionNotas);
        Debug.Log(UrlObtencionNotas);
        yield return ResultadoConsulta;
        string Datos = ResultadoConsulta.text;
        Debug.Log(Datos);
    }
}

