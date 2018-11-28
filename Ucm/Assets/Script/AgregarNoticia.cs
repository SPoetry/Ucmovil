using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AgregarNoticia : MonoBehaviour {

	public string postURL2 = "http://localhost:8000/secretaria/agregar_noticia";

    public Text EstaId;
	public InputField Titulo;
	public InputField Texto;
    [SerializeField]
    private Dropdown DropdownEstado;
    public InputField Propietario;
    [SerializeField]
    private Dropdown DropdownTag;

	public void Enviodedatos()
	{
		StartCoroutine ("GuardarNoticia");
	}
	public void mostrar()
	{
		StartCoroutine ("MostrarNoticia");
	}

	private IEnumerator GuardarNoticia()
	{
        string estado = DropdownEstado.options[DropdownEstado.value].text;
        string tag = DropdownTag.options[DropdownTag.value].text;
        postURL2 = postURL2 + "?titulo=" + Titulo.text + "&texto=" + Texto.text +  "&estado=" + estado + "&propietario=" + Propietario.text + "&tag=" + tag;

		WWW getResultado = new WWW (postURL2);
		yield return getResultado;
		postURL2 = ControladorLogin.InicioUrl + "secretaria/agregar_noticia";

        if (getResultado.text == "ok")
        {
            SceneManager.LoadScene("AgregarNoticia");
        }
	}

    public void AccederAChat()
    {
        Mensajeria.id_destinatario = EstaId.text;
        Debug.Log(Mensajeria.id_destinatario);
        SceneManager.LoadScene("Chat");
    }

    public void AccederAChatCurso()
    {
        Mensajeria.id_destinatario = EstaId.text;
        Debug.Log(Mensajeria.id_destinatario);
        SceneManager.LoadScene("ChatCurso");
    }
}
