using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsignaturaEditDelet : MonoBehaviour {

    [SerializeField]
    private GameObject NombreAsignatura;
    [SerializeField]
    private GameObject CreditoAsignatura;
    [SerializeField]
    private GameObject CodigoAsignatura;

    public void Editar(string escena)
    {
        SceneManager.LoadScene(escena);
        StartCoroutine("EnviosEditar");
    }

    /*private IEnumerator EnviosEditar()
    {
        GameObject.f
    } */
}
