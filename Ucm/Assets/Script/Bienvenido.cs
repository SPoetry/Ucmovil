﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bienvenido : MonoBehaviour {

    public GameObject[] bienvenidos;
    public GameObject[] Botones;

    void Start()
    {
        if (ControladorLogin.Tipo == "alumnos")
        {
            bienvenidos[0].SetActive(true);
            Botones[5].SetActive(true);
            Botones[6].SetActive(true);
            Botones[7].SetActive(true);
            Botones[8].SetActive(true);
        }
        if (ControladorLogin.Tipo == "profesores")
        {
            bienvenidos[2].SetActive(true);
            Botones[4].SetActive(true);
            Botones[10].SetActive(true);
            Botones[12].SetActive(true);
        }
        if (ControladorLogin.Tipo == "secretarias")
        {
            bienvenidos[1].SetActive(true);
            Botones[1].SetActive(true);
            Botones[2].SetActive(true);
            Botones[3].SetActive(true);
        }
        if (ControladorLogin.Tipo == "directores_carreras")
        {
            bienvenidos[3].SetActive(true);
            Botones[0].SetActive(true);
        }
    }
}
