using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControladorProfesorAsignacion : MonoBehaviour {
    public string getURL;
    private string TipoMalla;

    [SerializeField]
    private GameObject ComponenteProfesor;
    [SerializeField]
    private Transform LugarListado;
    public static GameObject Excepcion;


    public void limpieza()
    {

        foreach (Transform child in LugarListado)
        {
            Destroy(child.gameObject);
        }
    }

    public void LimpiezaExcepcion()
    {
        LugarListado = GameObject.FindWithTag("ListaProfesor").transform;
        Excepcion = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
        foreach (Transform child in LugarListado)
        {
            if (Excepcion != child.gameObject)
            {
                Destroy(child.gameObject);
            }
        }
        LugarListado.GetComponent<RectTransform>().localPosition = new Vector2(0, 450);
    }

    public void LimpiezaMuestraProfesor()
    {
        limpieza();
        StartCoroutine("MostrarProfesores");
    }

    private IEnumerator MostrarProfesores()
    {
        getURL = ControladorLogin.InicioUrl + "d_escuela/mostrar_profesor?id_profesor=";
        WWW getProfesor = new WWW(getURL);
        yield return getProfesor;
        string JsonProfesor = getProfesor.text;
        ListaProfesor lista = JsonUtility.FromJson<ListaProfesor>(JsonProfesor);
        Text[] Componente;

        float valor;
        valor = 1.0F;

        foreach (Profesor profe in lista.ObtenerLista())
        {
            GameObject nuevoProfesor = Instantiate(ComponenteProfesor) as GameObject;
            nuevoProfesor.transform.SetParent(LugarListado.transform);
            nuevoProfesor.GetComponent<RectTransform>().localScale = new Vector2(valor, valor);
            nuevoProfesor.name = profe.nombre;
            Componente = nuevoProfesor.GetComponentsInChildren<Text>();
            Componente[0].text = profe.nombre;
            Componente[1].text = profe.especialidad;
            Componente[2].text = profe.id.ToString();
        }
    }
}

[System.Serializable]
public class Profesor
{
    public int id;
    public int ano_ingreso;
    public string especialidad;
    public string nombre;
    public string telefono;
    public string apodo;
    public object created_at;
    public object updated_at;
}


[System.Serializable]
public class ListaProfesor
{
    public List<Profesor> profesor;

    public List<Profesor> ObtenerLista()
    {
        return profesor;
    }
}