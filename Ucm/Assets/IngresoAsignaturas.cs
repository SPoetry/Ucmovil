using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngresoAsignaturas : MonoBehaviour {

    public string getURL = "http://localhost:8000/d_escuela/anadir_asignatura";

    public InputField IdAsignatura;
    public InputField Nombre;
    public InputField Creditos;
    public InputField PreRequisitos;

    //


    public void EnvioDatos()
    {
        StartCoroutine ("GuardarAsignatura");
    }

    private IEnumerator GuardarAsignatura()
    {
        Debug.Log ("llego hasta aca");
        getURL = getURL + "?id_asignatura=" + IdAsignatura;
        getURL = getURL + "&nombre=" + Nombre + "&creditos=" + Creditos + "&prerequisito=" + PreRequisitos;
        WWW getResultado = new WWW (getURL);
        yield return getResultado;
        Debug.Log (getResultado.text);
    }
}
