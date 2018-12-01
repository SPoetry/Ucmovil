using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controladorAsignarProfesorCurso : MonoBehaviour {
    [SerializeField]
    private Dropdown YearDropdown;      //pide el objeto del dropdown year
    [SerializeField]
    private Dropdown SemestreDropdown;  //pide el objeto del dropdown semestre

    public void Asignar()
    {
        StartCoroutine("Asignacion");
    }
    public void EditarAsignacion()
    {
        SceneManager.LoadScene("AsignacionProfesorRamoEditar");
    }

    private IEnumerator Asignacion()
    {
        GameObject Asignatura = ControladorAsignaturaAsignacion.Excepcion;  //pide los valores de script excepcion que tiene el id de asignatura
        GameObject Profesor = ControladorProfesorAsignacion.Excepcion;      //pide los valores de script excepcion que tiene el id de profesor
        Text[] ComponenteAsignatura = Asignatura.GetComponentsInChildren<Text>();   //obtienen todos los valores de asignatura
        Text[] ComponenteProfesor = Profesor.GetComponentsInChildren<Text>();       //obtienen todos los valores de profesor
        string getAnadirProfeAsignatura = ControladorLogin.InicioUrl + "d_escuela/anadir_profesor_ramo";
        getAnadirProfeAsignatura = getAnadirProfeAsignatura + "?id_asignatura=" + ComponenteAsignatura[1].text;
        getAnadirProfeAsignatura = getAnadirProfeAsignatura + "&id_profesor=" + ComponenteProfesor[2].text;
        getAnadirProfeAsignatura = getAnadirProfeAsignatura + "&year=" + YearDropdown.options[YearDropdown.value].text;
        getAnadirProfeAsignatura = getAnadirProfeAsignatura + "&semestre=" + SemestreDropdown.options[SemestreDropdown.value].text;
        WWW getAsignacion = new WWW(getAnadirProfeAsignatura);  //se envia por url los valores
        yield return getAsignacion;
        if (getAsignacion.text == "ok")
        {
            SceneManager.LoadScene("AsignacionProfesorRamo");
        }
    }
}
