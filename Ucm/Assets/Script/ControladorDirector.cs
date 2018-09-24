using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDirector : MonoBehaviour {

    public void CambioEscena(string escena) {
        SceneManager.LoadScene(escena);
    }

    public void Salir() {
        Application.Quit();
    }
}
