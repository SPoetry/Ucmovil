using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioEscena : MonoBehaviour { 
    
    public void CambioE()
    {
        SceneManager.LoadScene("Perfil");
    }

    public void CambioVista(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }
}
