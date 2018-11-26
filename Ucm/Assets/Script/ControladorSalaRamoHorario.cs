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
    [SerializeField]
    private Dropdown DropdownDia;
    [SerializeField]
    private Dropdown DropdownModuloInicial;
    [SerializeField]
    private Dropdown DropdownCantidadModulo;
    [SerializeField]
    private Dropdown DropdownEstado;
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

    public void ConsultaDisponibilidadDiaSala()
    {
        AbrirPestaña();
        StartCoroutine("ConsultaDiaSala");
    }

    List<string> ModulosDisponible;
    Text[] ComponenteTexto;
    public IEnumerator ConsultaDiaSala()
    {
        DropdownModuloInicial.ClearOptions();
        LugarListado = GameObject.FindGameObjectWithTag("ListaVersionRamo").transform;
        Component[] ComponenteObjeto = LugarListado.GetComponentsInChildren<Component>();//se obtienen los componentes de el lugar listado
        GameObject OpcionSeleccionada = ComponenteObjeto[0].gameObject; //busco el boton seleccionado a través del componente y lo transformo a gameobject
        ComponenteTexto = ComponenteObjeto[0].GetComponentsInChildren<Text>();

        string ConsultaSala = "http://127.0.0.1:8000/d_escuela/busqueda_sala?numero_sala=" + ComponenteTexto[8].text + "&dia=" + DropdownDia.options[DropdownDia.value].text;
        WWW getResultadoSalas = new WWW(ConsultaSala);
        yield return getResultadoSalas;
        string JsonResultadoSalas = getResultadoSalas.text;
        ListaHorarioSerializado lista = JsonUtility.FromJson<ListaHorarioSerializado>(JsonResultadoSalas);

        ModulosDisponible = new List<string>();
        ModulosDisponible.Add("");
        for (int i=1; i<=12; i++)
        {
            if (i != 5)
            {
                ModulosDisponible.Add(i.ToString());
            }
        }
        foreach (HorarioSerializado HorSer in lista.ObtenerLista())
        {
            ModulosDisponible.Remove(HorSer.modulo.ToString());
        }
        DropdownModuloInicial.AddOptions(ModulosDisponible);
    }

    public void ConsultaDisponibilidadModulos()
    {
        DropdownCantidadModulo.ClearOptions();
        List<string> CantidadModulos = new List<string>();
        string ModuloInicioSeleccionado = DropdownModuloInicial.options[DropdownModuloInicial.value].text;
        int error = 0;
        int empieza = 0;
        int tamaño_arreglo = ModulosDisponible.Count;
        int i;
        for (i = 0; i < tamaño_arreglo; i++) //busca el lugar del array donde empezar
        {
            if (ModuloInicioSeleccionado == ModulosDisponible[i])
            {
                empieza = i;
            }
        }

        CantidadModulos.Add("");
        CantidadModulos.Add((1).ToString());
        for (i = empieza; i<= tamaño_arreglo-2; i++)
        {
            if ((int.Parse(ModulosDisponible[i])+1 == int.Parse(ModulosDisponible[i + 1])))
            {
                if (error == 0)
                {
                    CantidadModulos.Add((i + 2 - empieza).ToString());
                }
            }
            else
            {
                error++;
            }
        }
        DropdownCantidadModulo.AddOptions(CantidadModulos);
    }

    public void EnviarHorario()
    {
        StartCoroutine("EnviarHorarioIterador");
    }

    public IEnumerator EnviarHorarioIterador()
    {
        int ModuloInicial = int.Parse(DropdownModuloInicial.options[DropdownModuloInicial.value].text);
        int CantidadModulo = int.Parse(DropdownCantidadModulo.options[DropdownCantidadModulo.value].text);
        int CalculoModulo = ModuloInicial + CantidadModulo;
        int error=0;
        for (int i= ModuloInicial; i<CalculoModulo; i++)
        {
            string EnviarHorario = "http://127.0.0.1:8000/d_escuela/enviar_horario";
            EnviarHorario = EnviarHorario + "?id_ramo=" + ComponenteTexto[6].text + "&modulo=" + i.ToString();
            EnviarHorario = EnviarHorario + "&dia=" + DropdownDia.options[DropdownDia.value].text + "&sala=" + ComponenteTexto[8].text;
            EnviarHorario = EnviarHorario + "&estado=" + DropdownEstado.options[DropdownEstado.value].text;
            Debug.Log(EnviarHorario);
            WWW getResultadoEnvio = new WWW(EnviarHorario);
            yield return getResultadoEnvio;
            if(getResultadoEnvio.text != "ok")
            {
                //Debug.Log(getResultadoEnvio.text);
                error++;
            }
        }
        if (error == 0)
        {
            SceneManager.LoadScene("AsignacionSalas");
        }
    }
}

[System.Serializable]
public class HorarioSerializado
{
    public int id_ramo;
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