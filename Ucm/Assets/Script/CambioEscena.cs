using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioEscena : MonoBehaviour {

    public string tipo;
    
    
    public void CambioE()
    {
        tipo = ControladorLogin.Tipo;
        if(tipo == "alumnos"){
            SceneManager.LoadScene("PerfilA");
        }
        if(tipo == "profesores"){
            SceneManager.LoadScene("PerfilP");
        }
        if(tipo == "directores_carreras"){
            SceneManager.LoadScene("PerfilD");
        }
        if(tipo == "secretarias"){
            SceneManager.LoadScene("PerfilS");
        }
        
    }
    public void CambioVista(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }
}
