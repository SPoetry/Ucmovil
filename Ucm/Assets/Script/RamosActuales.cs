using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RamosActuales : MonoBehaviour {

    public string UrlRamosActuales = "http://localhost:8000/RamosA";
    public GameObject AsignaturaPrefab;
    public Transform Ubicacion;
    public string Id;
    public int Fecha_actualA;
    public int Fecha_actualM;
    public int Semestre2m = 1;
    public int Semestre1m = 8;

    void Start () {
        Id = "1";
        Fecha_actualA = DateTime.Now.Year;
        Fecha_actualM = DateTime.Now.Month;

        if (Fecha_actualM > Semestre1m && Fecha_actualM >= Semestre2m)
        {
            UrlRamosActuales = UrlRamosActuales + "?id=" + Id + "&anio=" + Fecha_actualA + "-08-01";
        }
        else
        {
            UrlRamosActuales = UrlRamosActuales + "?id=" + Id + "&anio=" + Fecha_actualA + "-03-01";
        }
        StartCoroutine("RamosA");
    }
    public IEnumerator RamosA()
    {
        WWW ResultadoRamos = new WWW(UrlRamosActuales);
        Debug.Log(UrlRamosActuales);
        yield return ResultadoRamos;
        string DatosA = ResultadoRamos.text;
        Listaramosactuales Actual = JsonUtility.FromJson<Listaramosactuales>(DatosA);
        Actual.Actuales();
    }
}

[System.Serializable]
public class RamosActuale
{
    public string id_asignatura;
    public int id_alumno;
    public float nota;
    public int n_nota;
    public object created_at;
    public object updated_at;

    public override string ToString()
    {
        return string.Format("el codigo es: {0} su nombre: {1}", id_asignatura, id_alumno);
    }
}

[System.Serializable]
public class Listaramosactuales
{
    public List<RamosActuale> ramosA; 

    public void Actuales()
    {
        foreach(RamosActuale asignaturaA in ramosA)
        {
            Debug.Log(asignaturaA);
        }
        Debug.Log(ramosA.Count);
    }
}