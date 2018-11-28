using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusquedaTag : MonoBehaviour {
    public int zeteo;
    private string getURL;
    [SerializeField]
    private GameObject NoticiaPrefab;
    [SerializeField]
    private Dropdown SeleccionTag;
    [SerializeField]
    private Transform LugarListado;

    public void iniciar()
    {
        StartCoroutine("busqueda");
    }

    public void busqueda()
    {
        string TagSeleccionado = "";
        TagSeleccionado = SeleccionTag.options[SeleccionTag.value].text;
        Text[] Componente;
        if (TagSeleccionado == "Todas")
        {
            foreach (Transform child in LugarListado)
            {
                Destroy(child.gameObject);
            }
            TodaNoticia();
            LugarListado.GetComponent<RectTransform>().localPosition = new Vector2(0, zeteo);
        }
        else
        {
            foreach (Transform child in LugarListado)
            {
                Componente = child.GetComponentsInChildren<Text>();
                Debug.Log(Componente[4].text);
                if (Componente[4].text != "Obligatoria")
                {
                    if (Componente[4].text != TagSeleccionado)
                    {
                        Destroy(child.gameObject);
                    }
                }
                LugarListado.GetComponent<RectTransform>().localPosition = new Vector2(0, zeteo);
            }
        }
    }

    private void TodaNoticia()
    {
        
        StartCoroutine("MostrarNoticias");
    }

    public IEnumerator MostrarNoticias()
    {
        getURL = "http://127.0.0.1:8000/secretaria/mostrar_noticia";
        //Debug.Log(getURL);
        WWW getNoticias = new WWW(getURL);
        yield return getNoticias;
        string JsonNoticias = getNoticias.text;
        ListaNoticia lista = JsonUtility.FromJson<ListaNoticia>(JsonNoticias);
        Text[] Componente;

        float valor;
        valor = 1.0F;

        foreach (Noticia Not in lista.mostrar())
        {
            GameObject nuevaNoticia = Instantiate(NoticiaPrefab) as GameObject;
            nuevaNoticia.transform.SetParent(LugarListado.transform);
            nuevaNoticia.GetComponent<RectTransform>().localScale = new Vector2(valor, valor);
            nuevaNoticia.name = "Numero Noticia:" + Not.id_noticia;
            Componente = nuevaNoticia.GetComponentsInChildren<Text>();
            Componente[0].text = Not.titulo;
            Componente[1].text = Not.texto;
            Componente[2].text = Not.propietario;
            Componente[3].text = Not.updated_at;
            Componente[4].text = Not.tag;
        }
    }
}
