using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorAsignaturas : MonoBehaviour
{
    public string getURL = "http://127.0.0.1:8000/d_escuela/mostrar_asignatura";

    public void Awake()
    {
        StartCoroutine("MostrarAsignaturas");
    }


    private IEnumerator MostrarAsignaturas()
    {
        WWW getAsignatura = new WWW(getURL);
        yield return getAsignatura;
        string JsonAsignatura = getAsignatura.text;
        Debug.Log(JsonAsignatura);
        ListaAsignatura lista = JsonUtility.FromJson<ListaAsignatura>(JsonAsignatura);
        lista.Listar();

    }

}

[System.Serializable]
public class Asignatura
{
    public string id_asignatura { get; set; }
    public string nombre { get; set; }
    public int creditos { get; set; }
    public object created_at { get; set; }
    public object updated_at { get; set; }
    public string prerequisito { get; set; }

    public override string ToString()
    {
        return string.Format("{0} \n", id_asignatura);
    }
}


[System.Serializable]
public class ListaAsignatura
{
    public List<Asignatura> Asignaturas { get; set; }

    public void Listar()
    {
        Debug.Log("antes foreach");
        foreach (Asignatura asignatura in Asignaturas)
        {
            Debug.Log("entre foreach");
            Debug.Log(asignatura);
        }
        Debug.Log("despues foreach");
    }
}