using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarChatC : MonoBehaviour {

    string UrlMensajes = ControladorLogin.InicioUrl;
    string Nombres;
    public Transform Ubicacion;

    float TiempoAnterior;
    float TiempoActual;

    int ContinuacioMensajeria = 0;

    public GameObject[] ElPrefab;
    public GameObject[] YoPrefab;

    void Start()
    {
        
        TiempoAnterior = Time.deltaTime;
        TiempoActual = Time.deltaTime;
        Debug.Log(ControladorLogin.Tipo);
        UrlMensajes += ControladorLogin.Tipo + "/MensajesC?id_remitente=" + ControladorLogin.Id + "&id_destinatario=" + Mensajeria.id_destinatario;
        StartCoroutine("CargandoChat");
    }

    void Update()
    {
        TiempoActual += Time.deltaTime;
        if ((TiempoActual - TiempoAnterior) >= 0.5f)
        {
            StartCoroutine("CargandoChat");
            TiempoAnterior = Time.deltaTime;
            TiempoActual = Time.deltaTime;
        }
    }

    public IEnumerator CargandoChat()
    {
        int ContadorLocal = 0;
        WWW MensajesChat = new WWW(UrlMensajes);
        yield return MensajesChat;
        string MensajeTextoChat = MensajesChat.text;
        Listachat ChatCompleto = JsonUtility.FromJson<Listachat>(MensajeTextoChat);
        List<Chat> ChatSeleccionar = ChatCompleto.total();

        foreach (Chat Mensaje in ChatSeleccionar)
        {
            ContadorLocal++;
            if (ContadorLocal > ContinuacioMensajeria)
            {
                ContinuacioMensajeria++;
                if (Mensaje.id_remitente == Int32.Parse(ControladorLogin.Id))
                {
                    if (Mensaje.texto.Length <= 50)
                    {
                        GameObject MensajeN = Instantiate(YoPrefab[0]) as GameObject;
                        MensajeN.transform.SetParent(Ubicacion.transform, false);
                        Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                        foreach (Text Componente in Texto)
                        {
                            if (Componente.name == "Mensaje")
                            {
                                Componente.text = Mensaje.texto;
                            }
                        }
                    }
                    else if (Mensaje.texto.Length <= 100)
                    {
                        GameObject MensajeN = Instantiate(YoPrefab[1]) as GameObject;
                        MensajeN.transform.SetParent(Ubicacion.transform, false);
                        Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                        foreach (Text Componente in Texto)
                        {
                            if (Componente.name == "Mensaje")
                            {
                                Componente.text = Mensaje.texto;
                            }
                        }
                    }
                    else if (Mensaje.texto.Length <= 150)
                    {
                        GameObject MensajeN = Instantiate(YoPrefab[2]) as GameObject;
                        MensajeN.transform.SetParent(Ubicacion.transform, false);
                        Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                        foreach (Text Componente in Texto)
                        {
                            if (Componente.name == "Mensaje")
                            {
                                Componente.text = Mensaje.texto;
                            }
                        }
                    }
                    else if (Mensaje.texto.Length <= 200)
                    {
                        GameObject MensajeN = Instantiate(YoPrefab[3]) as GameObject;
                        MensajeN.transform.SetParent(Ubicacion.transform, false);
                        Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                        foreach (Text Componente in Texto)
                        {
                            if (Componente.name == "Mensaje")
                            {
                                Componente.text = Mensaje.texto;
                            }
                        }
                    }
                    else if (Mensaje.texto.Length <= 250)
                    {
                        GameObject MensajeN = Instantiate(YoPrefab[4]) as GameObject;
                        MensajeN.transform.SetParent(Ubicacion.transform, false);
                        Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                        foreach (Text Componente in Texto)
                        {
                            if (Componente.name == "Mensaje")
                            {
                                Componente.text = Mensaje.texto;
                            }
                        }
                    }
                }
                else
                {
                    yield return StartCoroutine(NombresAlumnos(Mensaje.id_remitente));
                    if (Nombres != "")
                    {
                        if (Mensaje.texto.Length <= 50)
                        {
                            GameObject MensajeN = Instantiate(ElPrefab[0]) as GameObject;
                            MensajeN.transform.SetParent(Ubicacion.transform, false);
                            Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                            foreach (Text Componente in Texto)
                            {
                                if (Componente.name == "Mensaje")
                                {
                                    Componente.text = Mensaje.texto;
                                }
                                else if (Componente.name == "Remitente")
                                {
                                    Componente.text = Nombres;
                                }
                            }
                        }
                        else if (Mensaje.texto.Length <= 100)
                        {
                            GameObject MensajeN = Instantiate(ElPrefab[1]) as GameObject;
                            MensajeN.transform.SetParent(Ubicacion.transform, false);
                            Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                            foreach (Text Componente in Texto)
                            {
                                if (Componente.name == "Mensaje")
                                {
                                    Componente.text = Mensaje.texto;
                                }
                                else if (Componente.name == "Remitente")
                                {
                                    Componente.text = Nombres;
                                }
                            }
                        }
                        else if (Mensaje.texto.Length <= 150)
                        {
                            GameObject MensajeN = Instantiate(ElPrefab[2]) as GameObject;
                            MensajeN.transform.SetParent(Ubicacion.transform, false);
                            Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                            foreach (Text Componente in Texto)
                            {
                                if (Componente.name == "Mensaje")
                                {
                                    Componente.text = Mensaje.texto;
                                }
                                else if (Componente.name == "Remitente")
                                {
                                    Componente.text = Nombres;
                                }
                            }
                        }
                        else if (Mensaje.texto.Length <= 200)
                        {
                            GameObject MensajeN = Instantiate(ElPrefab[3]) as GameObject;
                            MensajeN.transform.SetParent(Ubicacion.transform, false);
                            Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                            foreach (Text Componente in Texto)
                            {
                                if (Componente.name == "Mensaje")
                                {
                                    Componente.text = Mensaje.texto;
                                }
                                else if (Componente.name == "Remitente")
                                {
                                    Componente.text = Nombres;
                                }
                            }
                        }
                        else if (Mensaje.texto.Length <= 250)
                        {
                            GameObject MensajeN = Instantiate(YoPrefab[4]) as GameObject;
                            MensajeN.transform.SetParent(Ubicacion.transform, false);
                            Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                            foreach (Text Componente in Texto)
                            {
                                if (Componente.name == "Mensaje")
                                {
                                    Componente.text = Mensaje.texto;
                                }
                                else if (Componente.name == "Remitente")
                                {
                                    Componente.text = Nombres;
                                }
                            }
                        }
                    }
                    else
                    {
                        Nombres = "Profesor";
                        if (Mensaje.texto.Length <= 50)
                        {
                            GameObject MensajeN = Instantiate(ElPrefab[0]) as GameObject;
                            MensajeN.transform.SetParent(Ubicacion.transform, false);
                            Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                            foreach (Text Componente in Texto)
                            {
                                if (Componente.name == "Mensaje")
                                {
                                    Componente.text = Mensaje.texto;
                                }
                                else if (Componente.name == "Remitente")
                                {
                                    Componente.text = Nombres;
                                }
                            }
                        }
                        else if (Mensaje.texto.Length <= 100)
                        {
                            GameObject MensajeN = Instantiate(ElPrefab[1]) as GameObject;
                            MensajeN.transform.SetParent(Ubicacion.transform, false);
                            Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                            foreach (Text Componente in Texto)
                            {
                                if (Componente.name == "Mensaje")
                                {
                                    Componente.text = Mensaje.texto;
                                }
                                else if (Componente.name == "Remitente")
                                {
                                    Componente.text = Nombres;
                                }
                            }
                        }
                        else if (Mensaje.texto.Length <= 150)
                        {
                            GameObject MensajeN = Instantiate(ElPrefab[2]) as GameObject;
                            MensajeN.transform.SetParent(Ubicacion.transform, false);
                            Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                            foreach (Text Componente in Texto)
                            {
                                if (Componente.name == "Mensaje")
                                {
                                    Componente.text = Mensaje.texto;
                                }
                                else if (Componente.name == "Remitente")
                                {
                                    Componente.text = Nombres;
                                }
                            }
                        }
                        else if (Mensaje.texto.Length <= 200)
                        {
                            GameObject MensajeN = Instantiate(ElPrefab[3]) as GameObject;
                            MensajeN.transform.SetParent(Ubicacion.transform, false);
                            Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                            foreach (Text Componente in Texto)
                            {
                                if (Componente.name == "Mensaje")
                                {
                                    Componente.text = Mensaje.texto;
                                }
                                else if (Componente.name == "Remitente")
                                {
                                    Componente.text = Nombres;
                                }
                            }
                        }
                        else if (Mensaje.texto.Length <= 250)
                        {
                            GameObject MensajeN = Instantiate(YoPrefab[4]) as GameObject;
                            MensajeN.transform.SetParent(Ubicacion.transform, false);
                            Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                            foreach (Text Componente in Texto)
                            {
                                if (Componente.name == "Mensaje")
                                {
                                    Componente.text = Mensaje.texto;
                                }
                                else if (Componente.name == "Remitente")
                                {
                                    Componente.text = Nombres;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public IEnumerator NombresAlumnos(int id)
    {
        string UrlNombres = ControladorLogin.InicioUrl + "BuscarPorIdA?id=" + id.ToString();
        WWW NombresChat = new WWW(UrlNombres);
        yield return NombresChat;
        Nombres = NombresChat.text;
    }
}
