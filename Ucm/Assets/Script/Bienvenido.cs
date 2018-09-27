using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bienvenido : MonoBehaviour {

    public GameObject[] bienvenidos;

    void Start() {
        if (ControladorLogin.Tipo == "alumnos")
            bienvenidos[0].SetActive(true);
        if (ControladorLogin.Tipo == "profesores")
            bienvenidos[2].SetActive(true);
        if (ControladorLogin.Tipo == "secretarias")
            bienvenidos[1].SetActive(true);
        if(ControladorLogin.Tipo == "directores escuelas")
            bienvenidos[3].SetActive(true);
	}
	
}
