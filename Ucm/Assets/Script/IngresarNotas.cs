using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngresarNotas : MonoBehaviour {

    public Text titulo;


    public void Awake()
    {
        titulo.text = AlumNotas.nombre + ": Notas del alumno " + AlumNotas.nombre_alumno;

    }

}
