using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RamosActuales : MonoBehaviour {

    string UrlRamosActuales = ControladorLogin.InicioUrl + "RamosA";
    public GameObject AsignaturaPrefab;
    public Transform Ubicacion;
    public Text[] componentes;

    string asignatura_anterior = "";
    string nombre;
    string profesor;
    string horario;
    GameObject nuevaAsignatura;

    float x = 497, y = 910.59f;


    void Start () {
        
        UrlRamosActuales = UrlRamosActuales + "?id=" + ControladorLogin.Id;
        
        StartCoroutine("RamosA");
    }

    public IEnumerator RamosA()
    {
        WWW ResultadoRamos = new WWW(UrlRamosActuales);
        Debug.Log(UrlRamosActuales);
        yield return ResultadoRamos;
        string DatosA = ResultadoRamos.text;
        Listadatosramos Actual = JsonUtility.FromJson<Listadatosramos>(DatosA);
        List<Datosramos> Ramos = Actual.Actuales();

        foreach(Datosramos ramo in Ramos)
        {
            if(asignatura_anterior == ramo.id_asignatura)
            {
                componentes = nuevaAsignatura.GetComponentsInChildren<Text>();
                foreach (Text a in componentes)
                {
                    if(a.name == "Horario")
                    {
                        if (ramo.modulo == 1) a.text += ramo.dia + " 8:30 - 9:30\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 2) a.text += ramo.dia + " 9:35  - 10:35\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 3) a.text += ramo.dia + " 10:50  - 11:50\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 4) a.text += ramo.dia + " 11:55  - 12:55\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 5) a.text += ramo.dia + " 13:10  - 14:10\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 6) a.text += ramo.dia + " 14:30  - 15:30\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 7) a.text += ramo.dia + " 15:35  - 16:35\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 8) a.text += ramo.dia + " 16:50  - 17:50\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 9) a.text += ramo.dia + " 17:55  - 18:55\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 10) a.text += ramo.dia + " 19:10  - 20:10\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 11) a.text += ramo.dia + " 20:15  - 21:15\t Sala: " + ramo.sala;
                        else a.text += ramo.dia + " 21:20  - 22:20\t Sala: " + ramo.sala;
                        a.text += "\n\t\t\t\t";
                    }
                }
            }
            else
            {
                Debug.Log(ramo);
                nuevaAsignatura = Instantiate(AsignaturaPrefab, new Vector3(0, 0), Quaternion.identity, Ubicacion) as GameObject;
                nuevaAsignatura.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
                y -= 480;
                componentes = nuevaAsignatura.GetComponentsInChildren<Text>();
                foreach (Text a in componentes)
                {
                    if (a.name == "Codigo")
                    {
                        a.text += ramo.id_asignatura;
                        asignatura_anterior = ramo.id_asignatura;
                    }
                    if (a.name == "Nombre")
                    {
                        a.text += ramo.nombreasig;
                    }
                    if (a.name == "Profesor")
                    {

                        a.text += ramo.nombre;
                    }
                    if (a.name == "Horario")
                    {
                        a.text += "\t";
                        if (ramo.modulo == 1) a.text += ramo.dia + " 8:30 - 9:30\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 2) a.text += ramo.dia + " 9:35  - 10:35\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 3) a.text += ramo.dia + " 10:50  - 11:50\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 4) a.text += ramo.dia + " 11:55  - 12:55\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 5) a.text += ramo.dia + " 13:10  - 14:10\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 6) a.text += ramo.dia + " 14:30  - 15:30\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 7) a.text += ramo.dia + " 15:35  - 16:35\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 8) a.text += ramo.dia + " 16:50  - 17:50\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 9) a.text += ramo.dia + " 17:55  - 18:55\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 10) a.text += ramo.dia + " 19:10  - 20:10\t Sala: " + ramo.sala;
                        else if (ramo.modulo == 11) a.text += ramo.dia + " 20:15  - 21:15\t Sala: " + ramo.sala;
                        else a.text += ramo.dia + " 21:20  - 22:20\t Sala: " + ramo.sala;
                        a.text += "\n\t\t\t\t";
                    }
                }
            }
            
        }
        
    }
}

[System.Serializable]
public class Datosramos
{
    public string id_asignatura;
    public string nombreasig;
    public string nombre;
    public int modulo;
    public string dia;
    public string sala;


    public override string ToString()
    {
        return string.Format("el codigo es: {0}", id_asignatura);
    }
}

[System.Serializable]
public class Listadatosramos
{
    public List<Datosramos> datosramos;

    public List<Datosramos> Actuales()
    {
        return datosramos;
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
    