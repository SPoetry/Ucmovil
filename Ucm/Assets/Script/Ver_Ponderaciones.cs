using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ver_Ponderaciones : MonoBehaviour {

    public string UrlPonderacion = "http://localhost:8000/ponderaciones";
    public string UrlIngresoPonderaciones = "http://localhost:8000/ingresoponderaciones";

    public Text titulo;

    public InputField Nota1;
    public InputField Nota2;
    public InputField Nota3;
    public InputField Nota4;
    public InputField Nota5;
    public InputField Nota6;
    public InputField Nota7;
    public InputField Nota8;
    public InputField Nota9;
    public InputField Nota10;


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
        UrlPonderacion = UrlPonderacion + "?id=" + 1;
        WWW ResultadoConsulta = new WWW(UrlPonderacion);
        Debug.Log(UrlPonderacion);
        yield return ResultadoConsulta;
        string Datos = ResultadoConsulta.text;
        ListaPonderaciones lista = JsonUtility.FromJson<ListaPonderaciones>(Datos);

        int i = 0;
        foreach (Ponderacione pondera in lista.Enumerar())
        {
            i++;
            if (i == 1) { Nota1.text = pondera.P_nota.ToString(); }
            if (i == 2) { Nota2.text = pondera.P_nota.ToString(); }
            if (i == 3) { Nota3.text = pondera.P_nota.ToString(); }
            if (i == 4) { Nota4.text = pondera.P_nota.ToString(); }
            if (i == 5) { Nota5.text = pondera.P_nota.ToString(); }
            if (i == 6) { Nota6.text = pondera.P_nota.ToString(); }
            if (i == 7) { Nota7.text = pondera.P_nota.ToString(); }
            if (i == 8) { Nota8.text = pondera.P_nota.ToString(); }
            if (i == 9) { Nota9.text = pondera.P_nota.ToString(); }
            if (i == 10) { Nota10.text = pondera.P_nota.ToString(); }
        }


    }

    public IEnumerator Ingreso()
    {
        string Id = Ponderaciones.id;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "?id=" + 1;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota1=" + Nota1.text;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota2=" + Nota2.text;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota3=" + Nota3.text;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota4=" + Nota4.text;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota5=" + Nota5.text;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota6=" + Nota6.text;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota7=" + Nota7.text;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota8=" + Nota8.text;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota9=" + Nota9.text;
        UrlIngresoPonderaciones = UrlIngresoPonderaciones + "&P_nota10=" + Nota10.text;
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
    public int P_nota;
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
