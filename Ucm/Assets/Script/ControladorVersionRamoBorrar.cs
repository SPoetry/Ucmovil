using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorVersionRamoBorrar : MonoBehaviour {
    public string getURL;
    private string TipoMalla;

    [SerializeField]
    private GameObject ComponenteAsignatura;
    [SerializeField]
    private Transform LugarListado;

    public void limpieza()
    {
        foreach (Transform child in LugarListado)
        {
            Destroy(child.gameObject);
        }
    }

    public void ICI()
    {
        limpieza();
        LugarListado.GetComponent<RectTransform>().localPosition = new Vector2(0, 450);
        TipoMalla = "?id_malla=ICI";
        StartCoroutine("MostrarVersionRamo");
    }

    public void INF()
    {
        limpieza();
        LugarListado.GetComponent<RectTransform>().localPosition = new Vector2(0, 450);
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
            GameObject nuevoVersionRamo = Instantiate(ComponenteAsignatura) as GameObject;
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
    }
}

[System.Serializable]
public class VersionRamo
{
    public int id_ramo;
    public string id_asignatura;
    public int id_profesor;
    public int year;
    public int semestre;
    public object created_at;
    public object updated_at;
    public string nombre_profesor;
    public string nombre_asignatura;
}

[System.Serializable]
public class ListaVersionRamo
{
    public List<VersionRamo> version_ramo;

    public List<VersionRamo> ObtenerLista()
    {
        return version_ramo;
    }
}