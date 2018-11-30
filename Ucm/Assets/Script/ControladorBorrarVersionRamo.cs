using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorBorrarVersionRamo : MonoBehaviour {
    [SerializeField]
    private GameObject TextoIdObjeto;

    private Text Id;

    public void BorrarVersionRamo()
    {
        StartCoroutine("EliminarAsignatura");
    }

    private IEnumerator EliminarAsignatura()
    {
        Id = TextoIdObjeto.GetComponent<Text>();
        string DelGetURL = ControladorLogin.InicioUrl + "d_escuela/borrar_version_ramo";

        DelGetURL = DelGetURL + "?id_ramo=" + Id.text;
        WWW getResultado = new WWW(DelGetURL);
        yield return getResultado;
        Debug.Log(getResultado.text);

        if (getResultado.text == "ok")
        {
            SceneManager.LoadScene("AsignacionProfesorRamoEditar");
        }
    }
}
