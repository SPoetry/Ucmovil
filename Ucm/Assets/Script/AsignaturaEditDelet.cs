using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsignaturaEditDelet : MonoBehaviour {

    [SerializeField]
    private GameObject TextoIdObjeto;
    [SerializeField]
    private GameObject TextoNombreObjeto;
    [SerializeField]
    private GameObject TextoCreditosObjeto;
    [SerializeField]
    private GameObject TextoPreRequisitoObjeto;
    [SerializeField]
    private GameObject TextoPosicionXObjeto;
    [SerializeField]
    private GameObject TextoPosicionYObjeto;
    [SerializeField]
    private GameObject TextoIdMalla;


    public static Text Id;
    public static Text Nombre;
    public static Text Creditos;
    public static Text PreRequisito;
    public static Text PosicionX;
    public static Text PosicionY;
    public static Text IdMalla;

    public void CambioEditar()
    {
        Id = TextoIdObjeto.GetComponent<Text>();
        Nombre = TextoNombreObjeto.GetComponent<Text>();
        Creditos = TextoCreditosObjeto.GetComponent<Text>();
        PreRequisito = TextoPreRequisitoObjeto.GetComponent<Text>();
        PosicionX = TextoPosicionXObjeto.GetComponent<Text>();
        PosicionY = TextoPosicionYObjeto.GetComponent<Text>();
        IdMalla = TextoIdMalla.GetComponent<Text>();
        SceneManager.LoadScene("AsignaturaEditar");
    }

    public void EnvioEliminar()
    {
        StartCoroutine("EliminarAsignatura");
    }

    public IEnumerator EliminarAsignatura()
    {
        Id = TextoIdObjeto.GetComponent<Text>();
        string DelGetURL = ControladorLogin.InicioUrl + "d_escuela/borrar_asignatura";

        DelGetURL = DelGetURL + "?id_asignatura=" + Id.text;
        WWW getResultado = new WWW(DelGetURL);
        yield return getResultado;
        Debug.Log(getResultado.text);

        if (getResultado.text == "ok")
        {
            SceneManager.LoadScene("Asignatura");
        }
    }

}
