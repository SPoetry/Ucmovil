using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControladorAsignaturaAsignacion : MonoBehaviour {
    public string getURL;
    private string TipoMalla;

    [SerializeField]
    private GameObject ComponenteAsignatura;
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
        LugarListado = GameObject.FindWithTag("ListaAsignatura").transform;
        Excepcion  = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
        foreach (Transform child in LugarListado)
        {
            if (Excepcion != child.gameObject)
            {
                Destroy(child.gameObject);
            }
        }
        LugarListado.GetComponent<RectTransform>().localPosition = new Vector2(0,450);
    }

    public void ICI()
    {
        limpieza();
        TipoMalla = "?id_malla=ICI";
        StartCoroutine("MostrarAsignaturas");
    }

    public void INF()
    {
        limpieza();
        TipoMalla = "?id_malla=INF";
        StartCoroutine("MostrarAsignaturas");
    }

    private IEnumerator MostrarAsignaturas()
    {
        getURL = "http://127.0.0.1:8000/d_escuela/mostrar_asignatura";
        getURL = getURL + TipoMalla;
        WWW getAsignatura = new WWW(getURL);
        yield return getAsignatura;
        string JsonAsignatura = getAsignatura.text;
        ListaAsignatura lista = JsonUtility.FromJson<ListaAsignatura>(JsonAsignatura);
        Text[] Componente;

        float valor;
        valor = 1.0F;

        foreach (Asignatura asign in lista.ObtenerLista())
        {
            GameObject nuevaAsignatura = Instantiate(ComponenteAsignatura) as GameObject;
            nuevaAsignatura.transform.SetParent(LugarListado.transform);
            nuevaAsignatura.GetComponent<RectTransform>().localScale = new Vector2(valor, valor);
            nuevaAsignatura.name = asign.nombre;
            Componente = nuevaAsignatura.GetComponentsInChildren<Text>();
            Componente[0].text = asign.nombre;
            Componente[1].text = asign.id_asignatura;
        }
    }
}
