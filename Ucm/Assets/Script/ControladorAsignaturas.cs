using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorAsignaturas : MonoBehaviour
{
    public string getURL = "http://127.0.0.1:8000/d_escuela/mostrar_asignatura";

    [SerializeField]
    private GameObject ComponenteAsignatura;
    [SerializeField]
    private Transform LugarListado;

    public void Awake()
    {
        StartCoroutine("MostrarAsignaturas");
    }


    private IEnumerator MostrarAsignaturas()
    {
        WWW getAsignatura = new WWW(getURL);
        yield return getAsignatura;
        string JsonAsignatura = getAsignatura.text;
        ListaAsignatura lista = JsonUtility.FromJson<ListaAsignatura>(JsonAsignatura);
        lista.Listar();

        for (int i = 0; i < 5; i++)
        {
            
            GameObject nuevaAsignatura = Instantiate(ComponenteAsignatura) as GameObject;
            //AGREGAR MOVERSE EN EL VECTOR X, Y;
            nuevaAsignatura.transform.SetParent(LugarListado.transform);
            nuevaAsignatura.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 200);
        }
    }

}

[System.Serializable]
public class Asignatura
{
    public string id_asignatura;
    public string nombre;
    public int creditos;
    public object created_at;
    public object updated_at;
    public string prerequisito;


    public override string ToString()
    {
        return string.Format("el codigo es: {0} su nombre: {1} tiene {2} creditos y tiene {3} como prerrequisito", id_asignatura, nombre, creditos, prerequisito);
    }
}


[System.Serializable]
public class ListaAsignatura
{
    public List<Asignatura> asignatura;

    public void Listar()
    {
        foreach (Asignatura asign in asignatura)
        {
            Debug.Log(asign);
        }
    }
}