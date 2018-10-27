using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RamosActuales : MonoBehaviour {

    public string UrlRamosActuales = "http://localhost:8000/RamosA";
    public GameObject AsignaturaPrefab;
    public Transform Ubicacion;
    public Text[] componentes;
    string Id;

    string nombre;
    string profesor;
    string horario;

    float x = 497, y = 910.59f;


    int Fecha_actualA;
    int Fecha_actualM;
    int Semestre2m = 1;
    int Semestre1m = 8;

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
        List<Ramosactuale> Ramos = Actual.Actuales();

        foreach(Ramosactuale ramo in Ramos)
        {
            GameObject nuevaAsignatura = Instantiate(AsignaturaPrefab, new Vector3(0,0), Quaternion.identity, Ubicacion) as GameObject;
            nuevaAsignatura.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
            y -= 994;
            componentes = nuevaAsignatura.GetComponentsInChildren<Text>();
            foreach (Text a in componentes)
            {
                if (a.name == "Codigo") a.text += ramo.id_asignatura;
                if (a.name == "Nombre")
                {
                    yield return StartCoroutine(Nasig(ramo.id_asignatura));
                    a.text += nombre;
                }
                if(a.name == "Profesor")
                {
                    yield return StartCoroutine(Nprofe(ramo.id_asignatura));
                    a.text += profesor;
                }
                if(a.name == "Horario")
                {
                    yield return StartCoroutine(Horario(ramo.id_asignatura));
                    a.text += horario;
                    Debug.Log(a.text);
                }
            }
        }
        
    }
    public IEnumerator Nasig(string name)
    {
        string consultas = "http://localhost:8000/NameA?id=" + name;
        WWW ResultadoRamos = new WWW(consultas);
        yield return ResultadoRamos;
        nombre = ResultadoRamos.text;
    }
    public IEnumerator Nprofe(string id)
    {
        string nprofe = "http://localhost:8000/ProfesorA?id=" + id;
        WWW ResultadoRamos = new WWW(nprofe);
        Debug.Log(nprofe);
        yield return ResultadoRamos;
        profesor = ResultadoRamos.text;
    }
    public IEnumerator Horario(string id)
    {
        string ConsultaHorario = "http://localhost:8000/HorarioA?id=" + id;
        WWW ResultadoRamos = new WWW(ConsultaHorario);
        Debug.Log(ConsultaHorario);
        yield return ResultadoRamos;
        string HorariosA = ResultadoRamos.text;
        Debug.Log(HorariosA);
        Listahorario Hora = JsonUtility.FromJson<Listahorario>(HorariosA);
        horario = Hora.Horas();
    }
}


[System.Serializable]
public class Ramosactuale
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
    public List<Ramosactuale> ramosactuale; 

    public List<Ramosactuale> Actuales()
    {
        return ramosactuale;
    }
}


[System.Serializable]
public class Horario
{
    public string id_asignatura;
    public int modulo;
    public string dia;
    public string sala;
    public object created_at;
    public object updated_at;

    public override string ToString()
    {
        return string.Format("{0]: 8:30-9:30", dia);
        
    }
}

[System.Serializable]
public class Listahorario
{
    public List<Horario> horario;

    public string Horas()
    {
        string text = "\t";
        foreach (Horario hor in horario)
        {
            if (hor.modulo == 1) text += hor.dia + " 8:30 - 9:30";
            else if (hor.modulo == 2) text += hor.dia + " 9:35  - 10:35";
            else if (hor.modulo == 3) text += hor.dia + " 9:35  - 10:35";
            else if (hor.modulo == 4) text += hor.dia + " 9:35  - 10:35";
            else if (hor.modulo == 5) text += hor.dia + " 9:35  - 10:35";
            else if (hor.modulo == 6) text += hor.dia + " 9:35  - 10:35";
            else if (hor.modulo == 7) text += hor.dia + " 9:35  - 10:35";
            else if (hor.modulo == 8) text += hor.dia + " 9:35  - 10:35";
            else if (hor.modulo == 9) text += hor.dia + " 9:35  - 10:35";
            else if (hor.modulo == 10) text += hor.dia + " 9:35  - 10:35";
            else if (hor.modulo == 11) text += hor.dia + " 9:35  - 10:35";
            else text += hor.dia + " 9:35  - 10:35";
            text += "\n\t\t\t\t";
                            
        }
        return text;
    }
}