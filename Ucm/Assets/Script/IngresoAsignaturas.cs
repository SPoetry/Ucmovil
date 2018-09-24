using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngresoAsignaturas : MonoBehaviour {

    public string CgetURL = "http://localhost:8000/d_escuela/anadir_asignatura";
    public string pruebaURL = "http://localhost:8000/d_escuela/anadir_asignatura?id_asignatura=ICI-400&nombre=hola&creditos=1000&prerequisito=ICI-200";

    public InputField IdAsignatura;
    public InputField Nombre;
    public InputField Creditos;
    public InputField PreRequisitos;
    
    
    public void EnvioDatos()
    {
        StartCoroutine ("GuardarAsignatura");
    }

    private IEnumerator GuardarAsignatura()
    {
        Debug.Log ("llego hasta aca");
        CgetURL = CgetURL + "?id_asignatura=" + IdAsignatura.text;
        CgetURL = CgetURL + "&nombre=" + Nombre.text + "&creditos=" + Creditos.text + "&prerequisito=" + PreRequisitos.text;
        Debug.Log (CgetURL);
        WWW getResultado = new WWW (CgetURL);
        yield return getResultado;
        Debug.Log (getResultado.text);
    }
}
