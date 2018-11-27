using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilidad : MonoBehaviour {

    public GameObject[] Boton;

    public void Start()
    {
        if(ControladorLogin.Tipo == "alumnos")
        {
            StartCoroutine("ConsultaMalla");
        }
    }
    public IEnumerator ConsultaMalla()
    {
        string Url = ControladorLogin.InicioUrl + "ConsultaMalla?id=" + ControladorLogin.Id;
        WWW getResultado = new WWW(Url);
        Debug.Log(Url);
        yield return getResultado;
        Debug.Log(getResultado.text);
        if(getResultado.text == "ICI")
        {
            Boton[1].SetActive(false);
        }
        else
        {
            Boton[0].SetActive(false);
        }
    }
}
