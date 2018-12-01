using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ControladorSalaRamoHorario : MonoBehaviour {
    public int zeteo;           //se pide un valor de zeteo para el lugar donde está asignandose el prafabricado ComponenteVersionRamo
    private string getURL;      //se establece una url
    private string TipoMalla;   //se busca el tipo de malla

    [SerializeField]
    private GameObject ComponenteVersionRamo;   //se pide un prefabricado para entregar los valores de la versionramo
    [SerializeField]
    private Transform LugarListado;             //Lugar del padre de ComponenteVersionRamo
    [SerializeField]
    private InputField TextoBusquedaAsignatura; //busqueda de asignatura, se pide el inputfield de la escena
    [SerializeField]
    private InputField TextoBusquedaProfesor;
    [SerializeField]
    private InputField TextoBusquedaYear;
    [SerializeField]
    private InputField TextoBusquedaSemestre;
    [SerializeField]
    private InputField IngresoSala;     //se toma el valor de la sala
    [SerializeField]
    private GameObject IngresoIdVersionRamo;
    private GameObject ImagenPanel;
    private GameObject Panel;
    [SerializeField]
    private Dropdown DropdownDia;   //toma el objeto dropdown dia
    [SerializeField]
    private Dropdown DropdownModuloInicial;
    [SerializeField]
    private Dropdown DropdownCantidadModulo;
    [SerializeField]
    private Dropdown DropdownEstado;
    public static GameObject Excepcion;     //toma el objeto el cual no dbee borrarse


    public void limpieza()      //funcion que limpia (destruye) todos los objetos de LugarListado
    {
        foreach (Transform child in LugarListado)
        {
            Destroy(child.gameObject);
        }
    }

    public void busqueda()      //descarta todos los componentes que no cumplen la funcion
    {
        string Asignatura = TextoBusquedaAsignatura.text;   //traspaso el valor del texto a variable
        string Profesor = TextoBusquedaProfesor.text;
        string Year = TextoBusquedaYear.text;
        string Semestre = TextoBusquedaSemestre.text;
        Text[] Componente;      //creo un array de texto que contendra todos los valores de el prefabricado
        foreach (Transform child in LugarListado)       //recorre todos los hijos del lugar listado y destruye los que no sean igual a la descripcion
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

    public void ICI()   //concatena la url con la version de la malla
    {
        limpieza();
        TipoMalla = "?id_malla=ICI";
        StartCoroutine("MostrarVersionRamo");
    }

    public void INF()   //concatena la url con la version de la malla
    {
        limpieza();
        TipoMalla = "?id_malla=INF";
        StartCoroutine("MostrarVersionRamo");
    }

    private IEnumerator MostrarVersionRamo()    //toma todos los valores de las versiones de los ramos segun malla
    {
        getURL = ControladorLogin.InicioUrl + "d_escuela/mostrar_version_ramo";
        getURL = getURL + TipoMalla;
        WWW getVersionRamo = new WWW(getURL);
        yield return getVersionRamo;
        string JsonVersionRamo = getVersionRamo.text;
        ListaVersionRamo lista = JsonUtility.FromJson<ListaVersionRamo>(JsonVersionRamo);   //se serializa todos los valores obtenidos en una lista de VersionRamo
        Text[] Componente;

        float valor;
        valor = 1.0F;

        foreach (VersionRamo VerRam in lista.ObtenerLista())    //se recorre toda la lista de version ramo
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

    public void LimpiezaExcepcion()     //descarta todos los valores que no concuerden con el valor clickeado
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

    public void CerrarPestaña()     //quita la pestaña de la especificacion del panel a través de las escalas de tamaño
    {
        ImagenPanel = GameObject.Find("PanelEspecificacionHorario");
        ImagenPanel.GetComponent<RectTransform>().localScale = new Vector2(0, 0);
    }

    public void AbrirPestaña()      //agrega la pestaña de la especificacion del panel a través de las escalas de tamaño
    {
        ImagenPanel = GameObject.Find("PanelEspecificacionHorario");    //encuentra un objeto por el nombre
        ImagenPanel.GetComponent<RectTransform>().localScale = new Vector2(1, 1);       //establece la escala de x e y en 1
        LugarListado = GameObject.FindWithTag("ListaVersionRamo").transform;    //enuentra el padre de los componentes de version ramo
        Transform LugarListadoPadre = LugarListado.transform.parent.gameObject.transform;   
        ImagenPanel.transform.SetParent(LugarListadoPadre.transform);       //emparenta el panel de la imagen a el padre de los componentes de version ramo
    }

    public void ConsultaDisponibilidadDiaSala()
    {
        AbrirPestaña();
        StartCoroutine("ConsultaDiaSala");
    }

    List<string> ModulosDisponible;
    Text[] ComponenteTexto;
    public IEnumerator ConsultaDiaSala()    //hace validacion de los modulos que están disponibles
    {
        DropdownModuloInicial.ClearOptions();
        LugarListado = GameObject.FindGameObjectWithTag("ListaVersionRamo").transform;
        Component[] ComponenteObjeto = LugarListado.GetComponentsInChildren<Component>();//se obtienen los componentes de el lugar listado
        GameObject OpcionSeleccionada = ComponenteObjeto[0].gameObject; //busco el boton seleccionado a través del componente y lo transformo a gameobject
        ComponenteTexto = ComponenteObjeto[0].GetComponentsInChildren<Text>();

        string ConsultaSala = ControladorLogin.InicioUrl + "d_escuela/busqueda_sala?numero_sala=" + ComponenteTexto[8].text + "&dia=" + DropdownDia.options[DropdownDia.value].text;
        WWW getResultadoSalas = new WWW(ConsultaSala);
        yield return getResultadoSalas;
        string JsonResultadoSalas = getResultadoSalas.text;
        ListaHorarioSerializado lista = JsonUtility.FromJson<ListaHorarioSerializado>(JsonResultadoSalas);

        ModulosDisponible = new List<string>();
        ModulosDisponible.Add("");
        for (int i=1; i<=12; i++)   //crea todos los modulos del horario, exceptuando el 5 por hora de almuerzo
        {
            if (i != 5)
            {
                ModulosDisponible.Add(i.ToString());
            }
        }
        foreach (HorarioSerializado HorSer in lista.ObtenerLista()) //remueve todos los valores que están ocupados en esa sala
        {
            ModulosDisponible.Remove(HorSer.modulo.ToString());
        }
        DropdownModuloInicial.AddOptions(ModulosDisponible);        //añade todas las opciones al dropdown modulo inicial
    }

    public void ConsultaDisponibilidadModulos()     //entrega cantidad de modulos disponibles, segun el modulo seleccionado
    {
        DropdownCantidadModulo.ClearOptions();  //limpia todos los modulos en ese momento
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

        CantidadModulos.Add("");    //agrega la opcion vacio
        CantidadModulos.Add((1).ToString());    //agrega la opcion de 1 modulo
        for (i = empieza; i<= tamaño_arreglo-2; i++)    //agrega el conteo de los otros modulos
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
        DropdownCantidadModulo.AddOptions(CantidadModulos);     //entrega las opciones a el dropdown cantidad modulos
    }

    public void EnviarHorario()
    {
        StartCoroutine("EnviarHorarioIterador");
    }

    public IEnumerator EnviarHorarioIterador()
    {
        int ModuloInicial = int.Parse(DropdownModuloInicial.options[DropdownModuloInicial.value].text);     //obtiene el valor del dropdown inicial
        int CantidadModulo = int.Parse(DropdownCantidadModulo.options[DropdownCantidadModulo.value].text);  //obtiene el valor de la cantidad de modulos pedidos
        int CalculoModulo = ModuloInicial + CantidadModulo;
        int error=0;
        for (int i= ModuloInicial; i<CalculoModulo; i++)    //crea un iterador de envios de informacion a una url
        {
            string EnviarHorario = ControladorLogin.InicioUrl + "d_escuela/enviar_horario";
            EnviarHorario = EnviarHorario + "?id_ramo=" + ComponenteTexto[6].text + "&modulo=" + i.ToString();
            EnviarHorario = EnviarHorario + "&dia=" + DropdownDia.options[DropdownDia.value].text + "&sala=" + ComponenteTexto[8].text;
            EnviarHorario = EnviarHorario + "&estado=" + DropdownEstado.options[DropdownEstado.value].text;
            Debug.Log(EnviarHorario);
            WWW getResultadoEnvio = new WWW(EnviarHorario);
            yield return getResultadoEnvio;
            if(getResultadoEnvio.text != "ok")  //consulta si existe algun tipo de error
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
public class HorarioSerializado //crea un modelo de horario serializado
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
public class ListaHorarioSerializado    //crea una lista de el horario
{
    public List<HorarioSerializado> horario;

    public List<HorarioSerializado> ObtenerLista()
    {
        return horario;
    }
}