using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarChat : MonoBehaviour {

    string UrlMensajes = ControladorLogin.InicioUrl;
    public Transform Ubicacion;

    float TiempoAnterior;
    float TiempoActual;

    int ContinuacioMensajeria = 0;

    public GameObject[] ElPrefab;
    public GameObject[] YoPrefab;

	void Start () {
        TiempoAnterior = Time.deltaTime;
        TiempoActual = Time.deltaTime;
        Debug.Log(ControladorLogin.Tipo);
        UrlMensajes += ControladorLogin.Tipo + "/Mensajes?id_remitente=" + ControladorLogin.Id +"&id_destinatario=" + Mensajeria.id_destinatario;
        StartCoroutine("CargandoChat");
	}
	
	void Update () {
        TiempoActual += Time.deltaTime;
        if ((TiempoActual-TiempoAnterior) >= 0.5f)
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

        foreach(Chat Mensaje in ChatSeleccionar)
        {
            ContadorLocal++;
            if(ContadorLocal > ContinuacioMensajeria)
            {
                Debug.Log(Int32.Parse(ControladorLogin.Id));
                if (Mensaje.id_remitente == Int32.Parse(ControladorLogin.Id))
                {
                    ContinuacioMensajeria++;
                    if(Mensaje.texto.Length <= 50)
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
                    else if(Mensaje.texto.Length <= 100)
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
                    else if(Mensaje.texto.Length <= 150)
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
                    else if(Mensaje.texto.Length <= 200){
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
                    else if(Mensaje.texto.Length <= 250)
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
                    ContinuacioMensajeria++;
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
                        }
                    }
                    else if (Mensaje.texto.Length <= 250)
                    {
                        GameObject MensajeN = Instantiate(YoPrefab[4]) as GameObject;
                        MensajeN.transform.SetParent(Ubicacion.transform, false);
                        Text[] Texto = MensajeN.GetComponentsInChildren<Text>();
                        foreach(Text Componente in Texto)
                        {
                            if(Componente.name == "Mensaje")
                            {
                                Componente.text = Mensaje.texto;
                            }
                        }
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class Chat
{
    public int id_remitente;
    public int id_destinatario;
    public string texto;
}

[System.Serializable]
public class Listachat
{
    public List<Chat> chat;

    public List<Chat> total()
    {
        return chat;
    }
}