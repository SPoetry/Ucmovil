using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ver_Ramos : MonoBehaviour
{

    public string UrlRamos = ControladorLogin.InicioUrl + "ramos_impartidos";
    public string Id;
    public Text[] Componentes;

    [SerializeField]
    private GameObject PanelCurso;
    [SerializeField]
    private Transform Contenedor;

    public void Awake(){
        StartCoroutine("consulta");
    }

    public IEnumerator consulta()
    {
        Id = ControladorLogin.Id;
        Debug.Log(Id);
        UrlRamos = UrlRamos + "?id="+Id;
        WWW ResultadoConsulta = new WWW(UrlRamos);
        Debug.Log(UrlRamos);
        yield return ResultadoConsulta;
        string Datos = ResultadoConsulta.text;
        ListaRamos lista = JsonUtility.FromJson<ListaRamos>(Datos);

        foreach (Impartido ramo in lista.Enumerar()) {
            GameObject CuadroRamo = Instantiate(PanelCurso) as GameObject;
            CuadroRamo.transform.SetParent(Contenedor.transform);

            Componentes = CuadroRamo.GetComponentsInChildren<Text>();

            Componentes[0].text = ramo.id_ramo.ToString();
            Componentes[1].text=ramo.id_asignatura;
 

            CuadroRamo.GetComponent<RectTransform>().localScale = new Vector2(1.0F, 1.0F);
        }

        
    }
}

[System.Serializable]
public class Impartido
{
    public int id_ramo;
    public string id_asignatura;
    public int id_profesor;
    public int year;
    public int semestre;
    public object created_at;
    public object updated_at;

    public override string ToString()
    {
        return string.Format("{0} profesor: {1} ramo: {2}", id_ramo, id_profesor, id_asignatura);
    }

}

[System.Serializable]
public class ListaRamos
{
    public List<Impartido> impartidos;

    public List<Impartido> Enumerar() {
        return impartidos;
    }


    public string Listar()
    {
        string texto ="";
        foreach (Impartido ramo in impartidos)
        {
            texto = texto+"\n ID: "+ramo.id_ramo+" Codigo Ramo: "+ramo.id_asignatura;
        }
        return texto;
    }
}