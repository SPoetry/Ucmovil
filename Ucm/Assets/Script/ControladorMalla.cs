using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorMalla : MonoBehaviour {
    public string getURL = "http://127.0.0.1:8000/d_escuela/mostrar_asignatura";

    [SerializeField]
    private GameObject ComponenteAsignatura;
    [SerializeField]
    private Transform SeccionY;
    [SerializeField]
    private Transform RecuadroPosicion;

    [SerializeField]
    private GameObject NombreAsignatura;
    [SerializeField]
    private GameObject CreditoAsignatura;
    [SerializeField]
    private GameObject CodigoAsignatura;
    [SerializeField]
    private GameObject PosicionX;
    [SerializeField]
    private GameObject PosicionY;
    [SerializeField]
    private GameObject PreRequisito;

    void Awake()
    {
        StartCoroutine("MostrarMalla");
    }

    public IEnumerator MostrarMalla()
    {
        WWW GetAsignaturasMalla = new WWW(getURL);
        yield return GetAsignaturasMalla;
        string JsonAsignatura = GetAsignaturasMalla.text;
        ListaAsignatura lista = JsonUtility.FromJson<ListaAsignatura>(JsonAsignatura);
        //Text[] Componente;

        for (int i=0; i<8; i++)
        {
            Transform NuevoEjeContenedor = Instantiate(SeccionY) as Transform;
            NuevoEjeContenedor.transform.SetParent(RecuadroPosicion.transform);
            NuevoEjeContenedor.GetComponent<RectTransform>().position = new Vector2(0, -i*133);
            NuevoEjeContenedor.name = "MovimientoContenedor " + (i + 1);
        }

        /*foreach (Asignatura asign in lista.ObtenerLista())
        {
            GameObject nuevaAsignatura = Instantiate(ComponenteAsignatura) as GameObject;
            nuevaAsignatura.transform.SetParent(LugarListado.transform);
            nuevaAsignatura.GetComponent<RectTransform>().localScale = new Vector2(valor, valor);

            nuevaAsignatura.name = asign.nombre;
            Componente = nuevaAsignatura.GetComponentsInChildren<Text>();
            Componente[2].text = asign.nombre;
            Componente[3].text = asign.creditos.ToString();
            Componente[4].text = asign.id_asignatura;
            Componente[5].text = asign.posicion_x.ToString();
            Componente[6].text = asign.posicion_y.ToString();
            Componente[7].text = asign.prerequisito;
        }*/
    }
}
