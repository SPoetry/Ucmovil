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

    [SerializeField]
    private GameObject NombreAsignatura;
    [SerializeField]
    private GameObject CreditoAsignatura;
    [SerializeField]
    private GameObject CodigoAsignatura;
    [SerializeField]
    private GameObject PosicionX;
    [SerializeField]
    private GameObject PosicionY;
    [SerializeField]
    private GameObject PreRequisito;


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
        //lista.Listar();
        Text[] Componente;

        float valor;
        valor = 1.0F;

        foreach (Asignatura asign in lista.ObtenerLista())
        {
            /*NombreAsignatura.GetComponent<Text>().text = asign.nombre;
            CreditoAsignatura.GetComponent<Text>().text = asign.creditos.ToString();
            CodigoAsignatura.GetComponent<Text>().text = asign.id_asignatura;*/

            GameObject nuevaAsignatura = Instantiate(ComponenteAsignatura) as GameObject;
            nuevaAsignatura.transform.SetParent(LugarListado.transform);
            nuevaAsignatura.GetComponent<RectTransform>().localScale = new Vector2(valor, valor);
            
            nuevaAsignatura.name    = asign.nombre;
            Componente = nuevaAsignatura.GetComponentsInChildren<Text>();
            Componente[2].text = asign.nombre;
            Componente[3].text = asign.creditos.ToString();
            Componente[4].text = asign.id_asignatura;
            Componente[5].text = asign.posicion_x.ToString();
            Componente[6].text = asign.posicion_y.ToString();
            Componente[7].text = asign.prerequisito;
        }
    }

}

[System.Serializable]
public class Asignatura
{
    public string id_asignatura;
    public string nombre;
    public int creditos;
    public int posicion_x;
    public int posicion_y;
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

    public List<Asignatura> ObtenerLista()
    {
        return asignatura;
    }

    public void Listar()
    {
        foreach (Asignatura asign in asignatura)
        {
            Debug.Log(asign);
        }
    }
}