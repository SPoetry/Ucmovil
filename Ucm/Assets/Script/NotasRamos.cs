using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NotasRamos : MonoBehaviour {

    public GameObject NombrePrefab;
    public GameObject NotaPrefab;
    public GameObject Cargando;
    public Transform Ubicacion;

    Text[] ComponentesNombre;
    Text[] ComponentesNota;
    string UrlNotas = ControladorLogin.InicioUrl + "RamosActuales";
    string ramoanterior = "";


    float x = 0, y = 840;

    void Start () {
        Cargando.SetActive(true);
        UrlNotas += "?id=" + ControladorLogin.Id;

        StartCoroutine("AsignaturasParaNotas");
    }

    public IEnumerator AsignaturasParaNotas()
    {
        WWW ResultadoRamos = new WWW(UrlNotas);
        yield return ResultadoRamos;
        string DatosA = ResultadoRamos.text;
        Listaramosactuales Actual = JsonUtility.FromJson<Listaramosactuales>(DatosA);
        List<Ramosactuale> Ramos = Actual.Actuales();

        foreach (Ramosactuale ramo in Ramos)
        {
            if(ramoanterior != ramo.nombre)
            {
                ramoanterior = ramo.nombre;
                GameObject nuevaAsignatura = Instantiate(NombrePrefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
                nuevaAsignatura.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);

                ComponentesNombre = nuevaAsignatura.GetComponentsInChildren<Text>();

                foreach (Text componente in ComponentesNombre)
                {
                    if (componente.name == "Nombre")
                    {

                        componente.text += ramo.nombre;
                    }
                }
            }
            GameObject NuevaNota = Instantiate(NotaPrefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
            NuevaNota.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);

            ComponentesNota = NuevaNota.GetComponentsInChildren<Text>();

            foreach (Text componente1 in ComponentesNota)
            {
                if (componente1.name == "Numero")
                {

                    componente1.text += "Nota " + ramo.n_nota + ": " + ramo.nota;
                }
            }
            Cargando.SetActive(false);
        }
    }
    /**
    public IEnumerator CodigoA(string id)
    {
        string NombreA = ControladorLogin.InicioUrl + "NameA?id="+ id;
        WWW ResultadoRamos = new WWW(NombreA);
        yield return ResultadoRamos;
        Debug.Log(ResultadoRamos.text);
        Nombre = ResultadoRamos.text;
    }

    public IEnumerator NotasA(string id)
    {
        i = 0;
        string NotasA = ControladorLogin.InicioUrl + "NotasAsignatura?id=" +id + "&alumno=" + id_alumno;
        WWW NotasResultado = new WWW(NotasA);
        Debug.Log(NotasA);
        yield return NotasResultado;
        string Notas = NotasResultado.text;
        Listaramosactuales Actual = JsonUtility.FromJson<Listaramosactuales>(Notas);
        List<Ramosactuale> Notastotales = Actual.Actuales();
        Debug.Log(Notastotales.Count);

        foreach(Ramosactuale nota in Notastotales)
        {
            GameObject NuevaNota = Instantiate(NotaPrefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
            NuevaNota.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
            mover2 = 130;
            y -= mover2;

            ComponentesNota = NuevaNota.GetComponentsInChildren<Text>();

            foreach (Text componente in ComponentesNota)
            {
                i ++;
                if (componente.name == "Numero")
                {
                    
                    componente.text += "Nota "+ i.ToString()+": " + nota.nota.ToString();
                    NotasA = "";
                }
            }
        }
    }
     **/
}

[System.Serializable]
public class Ramosactuale
{
    public string nombre;
    public float nota;
    public int n_nota;
}

[System.Serializable]
public class Listaramosactuales
{
    public List<Ramosactuale> ramosactuale;

    public List<Ramosactuale> Actuales()
    {
        return ramosactuale;
    }
}
