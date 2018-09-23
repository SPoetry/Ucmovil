using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAsignaturas : MonoBehaviour {

    public string postURL = "http://localhost:8000/gg";
    public string getURL = "http://127.0.0.1:8000/d_escuela/mostrar_asignatura";

    public void Start()
    {
        StartCoroutine("MostrarAsignaturas");
    }

    public IEnumerator MostrarAsignaturas()
    {
        Debug.Log("Entrar a la pagina");
        Debug.Log(getURL);
        WWW getAsignatura = new WWW(getURL);
        yield return getAsignatura;
        Debug.Log (getAsignatura.text);
    }


}
