using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ver_Ramos : MonoBehaviour
{

    public string UrlConsulta = "http://localhost:8000/ramos_impartidos?id=2";
    public string Id;
    public Text CuadroRamos;

    public void Awake(){
        StartCoroutine("consulta");
    }


    public IEnumerator consulta()
    {
        Id = ControladorLogin.Id;
        UrlConsulta = UrlConsulta + "?id=" + Id;
        WWW ResultadoConsulta = new WWW(UrlConsulta);
        yield return ResultadoConsulta;
        string Datos = ResultadoConsulta.text;
        ListaRamos lista = JsonUtility.FromJson<ListaRamos>(Datos);
        CuadroRamos.text = lista.Listar();
        
    }
}

[System.Serializable]
public class Impartido
{
    public int id_ramoimpartido;
    public string id_asignatura;
    public int id_profesor;
    public object created_at;
    public object updated_at;

    public override string ToString()
    {
        return string.Format("{0} profesor: {1} ramo: {2}", id_ramoimpartido, id_profesor, id_asignatura);
    }

}

[System.Serializable]
public class ListaRamos
{
    public List<Impartido> impartidos;
    
    public string Listar()
    {
        string texto ="";
        foreach (Impartido ramo in impartidos)
        {
            texto = texto+"\n ID: "+ramo.id_ramoimpartido+" Codigo Ramo: "+ramo.id_asignatura;
        }
        return texto;
    }
}