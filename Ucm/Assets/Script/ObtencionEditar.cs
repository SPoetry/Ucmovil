using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObtencionEditar : MonoBehaviour {

    public InputField CampoId;
    public InputField CampoNombre;
    public InputField CampoCreditos;
    public InputField CampoPreRequisito;
    public InputField CampoPosicionX;
    public InputField CampoPosicionY;
    public InputField CampoIdMalla;

    private Text Id;
    private Text Nombre;
    private Text Creditos;
    private Text PreRequisito;
    private Text PosicionX;
    private Text PosicionY;
    private Text IdMalla;

    void Awake () {
        Id = AsignaturaEditDelet.Id;
        Nombre = AsignaturaEditDelet.Nombre;
        Creditos = AsignaturaEditDelet.Creditos;
        PreRequisito = AsignaturaEditDelet.PreRequisito;
        PosicionX = AsignaturaEditDelet.PosicionX;
        PosicionY = AsignaturaEditDelet.PosicionY;
        IdMalla = AsignaturaEditDelet.IdMalla;

        CampoId.text = Id.text;
        CampoNombre.text = Nombre.text;
        CampoCreditos.text = Creditos.text;
        CampoPreRequisito.text = PreRequisito.text;
        CampoPosicionX.text = PosicionX.text;
        CampoPosicionY.text = PosicionY.text;
        CampoIdMalla.text = IdMalla.text;
    }

    public void EnvioEditarAsignatura()
    {
        StartCoroutine ("EditarAsignatura");
    }

    private IEnumerator EditarAsignatura()
    {
        string EditargetURL = "http://localhost:8000/d_escuela/modificar_asignatura";
        EditargetURL = EditargetURL + "?id_asignatura=" + CampoId.text + "&nombre=" + CampoNombre.text + "&creditos=" + CampoCreditos.text;
        EditargetURL = EditargetURL + "&prerequisito=" + CampoPreRequisito.text + "&id_malla=" + CampoIdMalla.text;
        EditargetURL = EditargetURL + "&posicion_x=" + CampoPosicionX.text + "&posicion_y=" + CampoPosicionY.text;

        WWW getResultado = new WWW(EditargetURL);
        yield return getResultado;

        if (getResultado.text == "ok")
        {
            SceneManager.LoadScene("Asignatura");
        }
    }
}
