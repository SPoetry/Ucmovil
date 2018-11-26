using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorBusquedaVersionRamo : MonoBehaviour {
    [SerializeField]
    private InputField TextoBusquedaAsignatura;
    [SerializeField]
    private InputField TextoBusquedaProfesor;
    [SerializeField]
    private InputField TextoBusquedaYear;
    [SerializeField]
    private InputField TextoBusquedaSemestre;
    [SerializeField]
    private Transform LugarListado;

    public void busqueda()
    {
        string Asignatura = TextoBusquedaAsignatura.text;
        string Profesor = TextoBusquedaProfesor.text;
        string Year = TextoBusquedaYear.text;
        string Semestre = TextoBusquedaSemestre.text;
        Text[] Componente;
        foreach (Transform child in LugarListado)
        {
            Componente = child.GetComponentsInChildren<Text>();
            if (Componente[0].text == Asignatura || Asignatura == "")
            {
                if (Componente[2].text == Profesor || Profesor == "")
                {
                    if (Componente[4].text == Year || Year == "")
                    {
                        if (Componente[5].text == Semestre || Semestre == "")
                        {
                        }
                        else
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    else
                    {
                        Destroy(child.gameObject);
                    }
                }
                else
                {
                    Destroy(child.gameObject);
                }
            }
            else
            {
                Destroy(child.gameObject);
            }
            LugarListado.GetComponent<RectTransform>().localPosition = new Vector2(0, 450);
        }
    }
}
