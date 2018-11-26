using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ControladorSalaRamoHorario : MonoBehaviour {
    public int zeteo;
    private string getURL;
    private string TipoMalla;

    [SerializeField]
    private GameObject ComponenteVersionRamo;
    [SerializeField]
    private Transform LugarListado;
    [SerializeField]
    private InputField TextoBusquedaAsignatura;
    [SerializeField]
    private InputField TextoBusquedaProfesor;
    [SerializeField]
    private InputField TextoBusquedaYear;
    [SerializeField]
    private InputField TextoBusquedaSemestre;
    [SerializeField]
    private InputField IngresoSala;
    [SerializeField]
    private GameObject IngresoIdVersionRamo;
    private GameObject ImagenPanel;
    private GameObject Panel;
    public static GameObject Excepcion;


    public void limpieza()
    {
        foreach (Transform child in LugarListado)
        {
            Destroy(child.gameObject);
        }
    }

    public void busqueda()
    {
        string Asignatura = TextoBusquedaAsignatura.text;
        string Profesor = TextoBusquedaProfesor.text;
        string Year = TextoBusquedaYear.text;
        string Semestre = TextoBusquedaSemestre.text;
        Text[] Componente;
        foreach (Transform child in LugarListado)
        {
            Componente = child.GetComponentsInChildren<Text>();
            if (Componente[0].text == Asignatura || Asignatura == "")
            {
                if (Componente[2].text == Profesor || Profesor == "")
                {
                    if (Componente[4].text == Year || Year == "")
                    {
                        if (Componente[5].text == Semestre || Semestre == "")
                        {
                        }
                        else
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    else
                    {
                        Destroy(child.gameObject);
                    }
                }
                else
                {
                    Destroy(child.gameObject);
                }
            }
            else
            {
                Destroy(child.gameObject);
            }
            LugarListado.GetComponent<RectTransform>().localPosition = new Vector2(0, zeteo);
        }
    }

    public void ICI()
    {
        limpieza();
        TipoMalla = "?id_malla=ICI";
        StartCoroutine("MostrarVersionRamo");
    }

    public void INF()
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
            Componente[6].text = VerRam.id_ramo.ToString();
        }
    }

    public void LimpiezaExcepcion()
    {
        LugarListado = GameObject.FindWithTag("ListaVersionRamo").transform;
        Excepcion = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
        foreach (Transform child in LugarListado)
        {
            if (Excepcion != child.gameObject)
            {
                Destroy(child.gameObject);
            }
        }
        LugarListado.GetComponent<RectTransform>().localPosition = new Vector2(0, zeteo);
    }

    public void CerrarPestaña()
    {
        ImagenPanel = GameObject.Find("PanelEspecificacionHorario");
        ImagenPanel.GetComponent<RectTransform>().localScale = new Vector2(0, 0);
    }

    public void AbrirPestaña()
    {
        ImagenPanel = GameObject.Find("PanelEspecificacionHorario");
        ImagenPanel.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        LugarListado = GameObject.FindWithTag("ListaVersionRamo").transform;
        Transform LugarListadoPadre = LugarListado.transform.parent.gameObject.transform;
        ImagenPanel.transform.SetParent(LugarListadoPadre.transform);
    }

    public void ConsultaDisponibilidad()
    {
        AbrirPestaña();
        StartCoroutine("ConsultaSala");
    }

    private IEnumerator ConsultaSala()
    {
        string ConsultaSala = "http://127.0.0.1:8000/d_escuela/busqueda_sala?numero_sala=" + IngresoSala;
        WWW getResultadoSalas = new WWW(ConsultaSala);
        yield return getResultadoSalas;
        string JsonResultadoSalas = getResultadoSalas.text;
        ListaHorarioSerializado lista = JsonUtility.FromJson<ListaHorarioSerializado>(JsonResultadoSalas);
        Text[] Componente;

        float valor;
        valor = 1.0F;

        foreach (HorarioSerializado HorSer in lista.ObtenerLista())
        {
            
        }
    }
}

[System.Serializable]
public class HorarioSerializado
{
    public int id_asignatura;
    public int modulo;
    public string dia;
    public int sala;
    public string estado;
    public object created_at;
    public object updated_at;
}

[System.Serializable]
public class ListaHorarioSerializado
{
    public List<HorarioSerializado> version_ramo;

    public List<HorarioSerializado> ObtenerLista()
    {
        return version_ramo;
    }
}