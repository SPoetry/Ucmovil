using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ControladorSalaRamoHorario : MonoBehaviour {
    private string getURL;
    private string TipoMalla;

    [SerializeField]
    private GameObject ComponenteVersionRamo;
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

    private void ICI()
    {
        limpieza();
        TipoMalla = "?id_malla=ICI";
        StartCoroutine("MostrarVersionRamo");
    }

    private void INF()
    {
        limpieza();
        TipoMalla = "?id_malla=INF";
        StartCoroutine("MostrarVersionRamo");
    }

    private IEnumerator MostrarVersionRamo()
    {
        getURL = "http://127.0.0.1:8000/d_escuela/mostrar_version_ramo";
        getURL = getURL + TipoMalla;
        WWW getVersionRamo = new WWW(getURL);
        yield return getVersionRamo;
        string JsonVersionRamo = getVersionRamo.text;
        ListaVersionRamo lista = JsonUtility.FromJson<ListaVersionRamo>(JsonVersionRamo);
        Text[] Componente;

        float valor;
        valor = 1.0F;

        foreach (VersionRamo VerRam in lista.ObtenerLista())
        {
            GameObject nuevoVersionRamo = Instantiate(ComponenteVersionRamo) as GameObject;
            nuevoVersionRamo.transform.SetParent(LugarListado.transform);
            nuevoVersionRamo.GetComponent<RectTransform>().localScale = new Vector2(valor, valor);
            nuevoVersionRamo.name = "Version Ramo n:" + VerRam.id_ramo;
            Componente = nuevoVersionRamo.GetComponentsInChildren<Text>();
            Componente[0].text = VerRam.nombre_asignatura;
            Componente[1].text = VerRam.id_asignatura;
            Componente[2].text = VerRam.nombre_profesor;
            Componente[3].text = VerRam.id_profesor.ToString();
            Componente[4].text = VerRam.year.ToString();
            Componente[5].text = VerRam.semestre.ToString();
            Componente[11].text = VerRam.id_ramo.ToString();
        }
        DropdownCantidadModulo.AddOptions(CantidadModulos);
    }

    public void EnviarHorario()
    {
        StartCoroutine("EnviarHorarioIterador");
    }

    public IEnumerator EnviarHorarioIterador()
    {
        for (int i=0; i<cantidad; i++)
        {

        }
        string EnviarHorario = "http://127.0.0.1:8000/d_escuela/enviar_horario";
        WWW getResultadoEnvio = new WWW(EnviarHorario);

        yield return getResultadoEnvio;
        string JsonResultadoEnvio = getResultadoEnvio.text;
    }
}

[System.Serializable]
public class HorarioSerializado
{
    public string id_asignatura;
    public int modulo;
    public string dia;
    public string sala;
    public string estado;
    public object created_at;
    public object updated_at;
}

[System.Serializable]
public class ListaHorarioSerializado
{
    public List<HorarioSerializado> horario;

    public List<HorarioSerializado> ObtenerLista()
    {
        return horario;
    }
}