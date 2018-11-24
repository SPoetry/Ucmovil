using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InformacionAsignatura : MonoBehaviour {

    [SerializeField]
    private GameObject Asignatura;
    [SerializeField]
    private GameObject BoxMensaje;
    public Transform LugarCreado;

    public void Detalles()
    {
        Asignatura = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
        LugarCreado = GameObject.FindWithTag("ListaMalla").transform;
        Text[] Componente;
        Text[] ComponenteAsignatura;
        GameObject Mensaje = Instantiate(BoxMensaje) as GameObject;
        Mensaje.GetComponent<RectTransform>().localScale = new Vector2(0.70274F, 0.70274F);
        Mensaje.GetComponent<RectTransform>().position = new Vector2(405,503);
        Mensaje.transform.SetParent(LugarCreado.transform);

        Componente = Mensaje.GetComponentsInChildren<Text>();
        ComponenteAsignatura = Asignatura.GetComponentsInChildren<Text>();

        Componente[1].text = ComponenteAsignatura[2].text;
        Componente[2].text = ComponenteAsignatura[0].text;
        Componente[3].text = ComponenteAsignatura[1].text;
        Componente[4].text = ComponenteAsignatura[3].text;
        Componente[5].text = ComponenteAsignatura[5].text;
        if (Componente[5].text == "")
        {
            Componente[5].text = "Sin Pre-Requisito";
        }
    }

    public void Borrar()
    {
        foreach (Transform child in LugarCreado)
        {
            if ( child.name == "DetalleAsignaturaMalla(Clone)")
            {
                Destroy(child.gameObject);
            }
        }
    }
}
