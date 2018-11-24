using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorMalla : MonoBehaviour {
    public string getURL;
    private string TipoMalla;

    [SerializeField]
    public GameObject ComponenteAsignatura;
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

    public void limpieza()
    {
        foreach (Transform child in RecuadroPosicion)
        {
            Destroy(child.gameObject);
        }
    }
    public void ICI()
    {
        limpieza();
        TipoMalla = "?id_malla=ICI";
        StartCoroutine("MostrarMalla");
    }
    public void INF()
    {
        limpieza();
        TipoMalla = "?id_malla=INF";
        StartCoroutine("MostrarMalla");
    }

    public IEnumerator MostrarMalla()
    {
        getURL = "http://127.0.0.1:8000/d_escuela/mostrar_asignatura";
        getURL = getURL + TipoMalla;
        //Debug.Log(getURL);
        WWW GetAsignaturasMalla = new WWW(getURL);
        yield return GetAsignaturasMalla;
        string JsonAsignatura = GetAsignaturasMalla.text;
        ListaAsignatura lista = JsonUtility.FromJson<ListaAsignatura>(JsonAsignatura);
        int CantidadEjeY=0;
        foreach (Asignatura asign in lista.ObtenerLista())
        {
            if (CantidadEjeY < asign.posicion_y)
            {
                CantidadEjeY = asign.posicion_y;
            }
        }
        Text[] Componente;
        float DimensionMallaX = 1.0F;
        float DimensionMallaY = 0.7F;
        float MovimientoX = 0.0F;
        float TamañoXMax=0.0F;
        Debug.Log(CantidadEjeY);
        for (int i=0; i<CantidadEjeY; i++)
        {
            Transform NuevoEjeContenedor = Instantiate(SeccionY) as Transform;
            NuevoEjeContenedor.transform.SetParent(RecuadroPosicion.transform);
            NuevoEjeContenedor.GetComponent<RectTransform>().localPosition = new Vector2(0, -65-i*133);
            NuevoEjeContenedor.name = "Contenedor Numero " + (i + 1);

            foreach ( Asignatura asign in lista.ObtenerLista() )
            {
                MovimientoX = 250 + ((asign.posicion_x - 1) * 505);
                if (asign.posicion_y == i+1)
                {
                    GameObject ContenedorAsignatura = Instantiate(ComponenteAsignatura) as GameObject;
                    ContenedorAsignatura.transform.SetParent(NuevoEjeContenedor.transform);
                    ContenedorAsignatura.GetComponent<RectTransform>().localPosition = new Vector2(MovimientoX, -40);
                    //Debug.Log(ContenedorAsignatura.GetComponent<RectTransform>().position);
                    ContenedorAsignatura.GetComponent<RectTransform>().localScale = new Vector2(DimensionMallaX, DimensionMallaY);

                    ContenedorAsignatura.name = asign.nombre;
                    Componente = ContenedorAsignatura.GetComponentsInChildren<Text>();
                    Componente[0].text = asign.nombre;
                    Componente[1].text = asign.creditos.ToString();
                    Componente[2].text = asign.id_asignatura;
                    Componente[3].text = asign.posicion_x.ToString();
                    Componente[4].text = asign.posicion_y.ToString();
                    Componente[5].text = asign.prerequisito;
                    Componente[6].text = asign.id_malla;
                }
                if (TamañoXMax < MovimientoX)
                {
                    TamañoXMax = MovimientoX;
                    TamañoXMax = TamañoXMax - 250;
                    TamañoXMax = TamañoXMax * 1.73F;
                    TamañoXMax = TamañoXMax + 250;
                    TamañoXMax = TamañoXMax + 500;
                }
            }
        }
        RecuadroPosicion.GetComponent<RectTransform>().sizeDelta = new Vector2 (TamañoXMax, 0);
        Debug.Log(RecuadroPosicion.GetComponent<RectTransform>().sizeDelta);
    }
}
