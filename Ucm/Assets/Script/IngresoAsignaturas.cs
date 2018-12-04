using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class IngresoAsignaturas : MonoBehaviour {

    public string CgetURL = ControladorLogin.InicioUrl + "d_escuela/anadir_asignatura";
    public string pruebaURL = ControladorLogin.InicioUrl + "d_escuela/anadir_asignatura?id_asignatura=ICI-400&nombre=hola&creditos=1000&prerequisito=ICI-200";

    public InputField IdAsignatura;
    public InputField Nombre;
    public InputField Creditos;
    public InputField PreRequisitos;
    public InputField PosicionX;
    public InputField PosicionY;
    public InputField IdMalla;


    public void EnvioDatos()
    {
        StartCoroutine ("GuardarAsignatura");
    }

    private IEnumerator GuardarAsignatura()
    {
        CgetURL = CgetURL + "?id_asignatura=" + IdAsignatura.text;
        CgetURL = CgetURL + "&nombre=" + Nombre.text + "&creditos=" + Creditos.text + "&prerequisito=" + PreRequisitos.text;
        CgetURL = CgetURL + "&posicion_x=" + PosicionX.text + "&posicion_y=" + PosicionY.text + "&id_malla=" + IdMalla.text;

        WWW getResultado = new WWW (CgetURL);
        yield return getResultado;

        if (getResultado.text == "ok")
        {
            SceneManager.LoadScene("Asignatura");
        }
    }
}
