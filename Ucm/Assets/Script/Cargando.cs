using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargando : MonoBehaviour {

    public GameObject Circulo;
	
	void Update () {
        Circulo.transform.Rotate(0, 0, -2);
	}
}
