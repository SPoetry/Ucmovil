using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IngresarNotas : MonoBehaviour {

    public Text titulo;
    public GameObject panelNotas;
    public GameObject panelPonderaciones;
    public InputField[] notas;
    public Text[] ponderaciones;
    public Text[] ponderacionesNotas;
    public string UrlObtencionNotas = "http://localhost:8000/ObtenerNotas";
    public string UrlIngresoNotas = "http://localhost:8000/IngresarNotas";
    public string UrlEnvioNotas;
    private string id_alumno = AlumNotas.id_alumno;
    private string id_ramo = AlumNotas.id;



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

    public void IngresoNotas()
    {
        UrlEnvioNotas = UrlIngresoNotas + "?id_ramo=" + id_ramo + "&id_alumno=" + id_alumno;
        notas = panelNotas.GetComponentsInChildren<InputField>();

        foreach (InputField nota in notas)
        {
            if (nota.text == "")
            {
                UrlEnvioNotas = UrlEnvioNotas + "&" + nota.name + "=0";
            } else
            {
                UrlEnvioNotas = UrlEnvioNotas + "&" + nota.name + "=" + nota.text;
            }
        }
        Debug.Log(UrlEnvioNotas);
        WWW response = new WWW(UrlEnvioNotas);
       
        StartCoroutine(ingreso(response));
    }

    public IEnumerator ingreso(WWW response)
    {
        yield return response;
        string datos = response.text;
        Debug.Log(datos);
    }
   
    public IEnumerator precarga(){
        UrlObtencionNotas = UrlObtencionNotas + "?id_a=1&id_c=1";
        WWW ResultadoConsulta = new WWW(UrlObtencionNotas);
        Debug.Log(UrlObtencionNotas);
        yield return ResultadoConsulta;
        string Datos = ResultadoConsulta.text;
        ListaPrenotas listaprecarga = JsonUtility.FromJson<ListaPrenotas>(Datos);
        Debug.Log(Datos);

        notas = panelNotas.GetComponentsInChildren<InputField>();
        ponderaciones = panelPonderaciones.GetComponentsInChildren<Text>();
        foreach (Prenota prenota in listaprecarga.Enumerar())
        {
            notas[prenota.n_nota-1].text = prenota.nota.ToString();
            ponderaciones[prenota.n_nota - 1].text = prenota.P_nota.ToString();
        }
    }
}

[System.Serializable]
public class Prenota
{
    public int n_nota;
    public double nota;
    public double P_nota;
}

[System.Serializable]
public class ListaPrenotas
{
    public List<Prenota> prenotas;
    public List<Prenota> Enumerar()
    {
        return prenotas;
    }
}