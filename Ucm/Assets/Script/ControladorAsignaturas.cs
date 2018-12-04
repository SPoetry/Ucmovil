using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorAsignaturas : MonoBehaviour
{
    string getURL = ControladorLogin.InicioUrl;   //se crea una variable string que interactuará con la url
    private string TipoMalla;   //se crea una variable string que tomará el valor del codigo de la malla

    [SerializeField]
    private GameObject ComponenteAsignatura;    //se pide el objeto prefabricado que obtendrá los valores de asignatura
    [SerializeField]
    private Transform LugarListado;     //se pide el objeto donde será ingresado el objeto ComponenteAsignatura

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

    public void limpieza()      //funcion que limpia (destruye) todos los objetos de LugarListado
    {
        foreach (Transform child in LugarListado)
        {
            Destroy(child.gameObject);
        }
    }

    public void ICI()       //se concatena el valor del string con el id de la malla ICI
    {
        limpieza();
        TipoMalla = "?id_malla=ICI";
        StartCoroutine("MostrarAsignaturas");
    }

    public void INF()       //se concatena el valor del string con el id de la malla INF
    {
        limpieza();
        TipoMalla = "?id_malla=INF";
        StartCoroutine("MostrarAsignaturas");
    }

    private IEnumerator MostrarAsignaturas()        //obtiene todos los valores de asignatura
    {
        getURL = ControladorLogin.InicioUrl + "d_escuela/mostrar_asignatura";   //se busca la variable global de un controlador, se concatena direccion
        getURL = getURL + TipoMalla;        //se concatena el codigo de tipo de malla
        //Debug.Log(getURL);
        WWW getAsignatura = new WWW(getURL);    //se entrega el valor a nueva variable obteniendo el resultado del servidor
        yield return getAsignatura;     //se espera a que vuelva el resultado del servidor
        string JsonAsignatura = getAsignatura.text;     //se crea un string entregandole todo el valor de getAsignatura
        ListaAsignatura lista = JsonUtility.FromJson<ListaAsignatura>(JsonAsignatura);      //se serializa todo el valor obtenidolos en lista
        Text[] Componente;      //se crea un array de texto para almacenar todos los valores del objeto

        float valor;
        valor = 1.0F;

        foreach (Asignatura asign in lista.ObtenerLista())      //se recorre el arreglo serializado con el modelo Asignatura con alias asign
        {
            GameObject nuevaAsignatura = Instantiate(ComponenteAsignatura) as GameObject;   //se crea un prefabricado
            nuevaAsignatura.transform.SetParent(LugarListado.transform);    //se emparenta el prefabricado con el lugar donde debe aparecer
            nuevaAsignatura.GetComponent<RectTransform>().localScale = new Vector2(valor, valor);   //el prefabricado toma valores de escala
            
            nuevaAsignatura.name    = asign.nombre;     //se cambia el nombre del prefabricado
            Componente = nuevaAsignatura.GetComponentsInChildren<Text>();   //se obtienen todos los valores del componente del prefabricado
            Componente[2].text = asign.nombre;              //se alteran todos los valores para almacenar y mostrar en el prefabricado
            Componente[3].text = asign.creditos.ToString();
            Componente[4].text = asign.id_asignatura;
            Componente[5].text = asign.posicion_x.ToString();
            Componente[6].text = asign.posicion_y.ToString();
            Componente[7].text = asign.prerequisito;
            Componente[8].text = asign.id_malla;
        }
    }

}

[System.Serializable]
public class Asignatura     //se crea un modelo de asignatura para almacenar y recorrer los valores de la url
{
    public string id_asignatura;
    public string nombre;
    public int creditos;
    public int posicion_x;
    public int posicion_y;
    public object created_at;
    public object updated_at;
    public string prerequisito;
    public string id_malla;


    public override string ToString()
    {
        return string.Format("el codigo es: {0} su nombre: {1} tiene {2} creditos y tiene {3} como prerrequisito", id_asignatura, nombre, creditos, prerequisito);
    }
}


[System.Serializable]
public class ListaAsignatura        //se crea una lista de asignatura
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