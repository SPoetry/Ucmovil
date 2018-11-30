using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controladorAsignarProfesorCurso : MonoBehaviour {
    [SerializeField]
    private Dropdown YearDropdown;
    [SerializeField]
    private Dropdown SemestreDropdown;

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
        GameObject Asignatura = ControladorAsignaturaAsignacion.Excepcion;
        GameObject Profesor = ControladorProfesorAsignacion.Excepcion;
        Text[] ComponenteAsignatura = Asignatura.GetComponentsInChildren<Text>();
        Text[] ComponenteProfesor = Profesor.GetComponentsInChildren<Text>();
        string getAnadirProfeAsignatura = ControladorLogin.InicioUrl + "d_escuela/anadir_profesor_ramo";
        getAnadirProfeAsignatura = getAnadirProfeAsignatura + "?id_asignatura=" + ComponenteAsignatura[1].text;
        getAnadirProfeAsignatura = getAnadirProfeAsignatura + "&id_profesor=" + ComponenteProfesor[2].text;
        getAnadirProfeAsignatura = getAnadirProfeAsignatura + "&year=" + YearDropdown.options[YearDropdown.value].text;
        getAnadirProfeAsignatura = getAnadirProfeAsignatura + "&semestre=" + SemestreDropdown.options[SemestreDropdown.value].text;
        WWW getAsignacion = new WWW(getAnadirProfeAsignatura);
        yield return getAsignacion;
        if (getAsignacion.text == "ok")
        {
            SceneManager.LoadScene("AsignacionProfesorRamo");
        }
    }
}
