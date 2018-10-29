using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotasRamos : MonoBehaviour {

    public GameObject NombrePrefab;
    public GameObject NotaPrefab;
    public Transform Ubicacion;

    Text[] ComponentesNombre;
    Text[] ComponentesNota;
    string UrlNotas = ControladorLogin.InicioUrl + "RamosA";

    string Id;
    string Nombre;
    int i= 0;
    int id_alumno;
    int Nota;

    int mover = 0;
    int mover2 = 0;

    float x = 0, y = 840;

    void Start () {
        Id = "1";

        UrlNotas += "?id=" + Id;

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
            GameObject nuevaAsignatura = Instantiate(NombrePrefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
            nuevaAsignatura.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
            mover = 130;
            y -= mover;
            ComponentesNombre = nuevaAsignatura.GetComponentsInChildren<Text>();
            id_alumno = ramo.id_alumno;

            foreach (Text componente in ComponentesNombre)
            {
                if (componente.name == "Nombre")
                {
                    
                    yield return StartCoroutine(CodigoA(ramo.id_ramo));
                    componente.text += Nombre;
                    yield return StartCoroutine(NotasA(ramo.id_ramo));
                    Debug.Log("Paso");
                }
            }
        }
    }

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
}
