using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RamosAnteriores : MonoBehaviour {

    public Text texto;

    string UrlHistorial = ControladorLogin.InicioUrl + "HistorialA";
    string Id;
	
	void Start () {
        Id = ControladorLogin.Id;

        UrlHistorial += "?id=" + Id;
        StartCoroutine("ConsultaHistorial");
	}

    public IEnumerator ConsultaHistorial()
    {
        WWW ResultadoHistorial = new WWW(UrlHistorial);
        Debug.Log(ResultadoHistorial);
        yield return ResultadoHistorial;
        string DatosH = ResultadoHistorial.text;
        Listahistorial Completo = JsonUtility.FromJson<Listahistorial>(DatosH);
        string Historial = Completo.total();
        Debug.Log(UrlHistorial);
        texto.text += Historial;
    }
}

[System.Serializable]
public class Historial
{
    public string id_asignatura;
    public int id_alumno;
    public string estado;
    public int semestre;
    public int nota_final;


    public override string ToString()
    {
        return string.Format("{0} \t {1} \t {2}", id_asignatura, estado, nota_final);
    }
}

[System.Serializable]
public class Listahistorial
{
    public List<Historial> historial;

    public string total()
    {
        string texto = "";
        foreach (Historial todo in historial)
        {
            texto = texto + " \n" + todo.id_asignatura + " \t\t\t\t\t\t " + todo.estado + " \t\t\t " + todo.nota_final;
        }
        return texto;
    }
}