using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ver_Ponderaciones : MonoBehaviour {

    string UrlPonderacion = ControladorLogin.InicioUrl + "ponderaciones";
    string UrlIngresoPonderaciones = ControladorLogin.InicioUrl + "ingresoponderaciones";

    public Text titulo;

    public GameObject panelPonderaciones;
    public InputField[] ponderaciones;


    public void Awake()
    {
        titulo.text = "Ponderaciones: " + Ponderaciones.nombre;
        StartCoroutine("Precarga");
    }
    public void IngresoPonderaciones()
    {
        StartCoroutine("Ingreso");
    }

    public IEnumerator Precarga()
    {
        string Id = Ponderaciones.id;
        UrlPonderacion = UrlPonderacion + "?id=" + Id;
        WWW ResultadoConsulta = new WWW(UrlPonderacion);
        Debug.Log(UrlPonderacion);
        yield return ResultadoConsulta;
        string Datos = ResultadoConsulta.text;
        ListaPonderaciones lista = JsonUtility.FromJson<ListaPonderaciones>(Datos);

        ponderaciones = panelPonderaciones.GetComponentsInChildren<InputField>();
        int i = 0;
        foreach (Ponderacione pondera in lista.Enumerar())
        {
            Debug.Log(pondera.P_nota);
            ponderaciones[i].text = pondera.P_nota.ToString();
            i++;
        }


    }

    public IEnumerator Ingreso()
    {
        string Id = Ponderaciones.id;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "?id=" + Id;

        ponderaciones = panelPonderaciones.GetComponentsInChildren<InputField>();
        for (int i = 0; i < 10; i++)
        {
            int j = i + 1;
            if (ponderaciones[i].text == "") { UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota" + j + "=0"; }
            else {UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota" + j + "=" + ponderaciones[i].text;}
            
        }
        Debug.Log(UrlIngresoPonderaciones);
        WWW ResultadoConsulta = new WWW(UrlIngresoPonderaciones);
        yield return ResultadoConsulta;
        Debug.Log(ResultadoConsulta.text);
        if (ResultadoConsulta.text == "Success"){
            SceneManager.LoadScene("VerRamos");
        }
    }
}


[System.Serializable]
public class Ponderacione
{
    public int id_ramo;
    public int N_nota;
    public float P_nota;
    public object created_at;
    public object updated_at;
}

[System.Serializable]
public class ListaPonderaciones
{
    public List<Ponderacione> ponderaciones;
    public List<Ponderacione> Enumerar()
    {
        return ponderaciones;
    }

}
