using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorLogin : MonoBehaviour {

    public static string InicioUrl = "http://localhost:8000/";
    public string getURL = InicioUrl + "log";

    public InputField Correo;
    public InputField Contrasena;
    public GameObject ErrorLogin;

    public static string Id;
    public static string Tipo;

    public void EnvioDatos()
    {
        StartCoroutine("Logear");
    }
    private IEnumerator Logear()
    {
        getURL = getURL + "?email=" + Correo.text;
        getURL = getURL + "&password=" + Contrasena.text;
        Correo.text = "";
        Contrasena.text = "";
        WWW getResultado = new WWW(getURL);
        Debug.Log(getURL);
        yield return getResultado;
        getURL = "http://localhost:8000/log";

        Debug.Log(getResultado.text);

        string UsuariosJson = getResultado.text;
        Debug.Log(UsuariosJson);

        if (UsuariosJson != "no")
        {
            ListaUsuario listaUsuario = JsonUtility.FromJson<ListaUsuario>(UsuariosJson);
            listaUsuario.Listar();

            if (Tipo == "alumno")
            {
                Tipo = "alumnos";
                SceneManager.LoadScene("Lobby");
            }
            else if (Tipo == "secretaria")
            {
                Tipo = "secretarias";
                SceneManager.LoadScene("Lobby");
            }
            else if (Tipo == "profesor")
            {
                Tipo = "profesores";
                SceneManager.LoadScene("Lobby");
            }
            else if (Tipo == "director_carrera")
            {
                Tipo = "directores_carreras";
                SceneManager.LoadScene("Lobby");
            }
        }
        else
        {
            ErrorLogin.SetActive(true);
        }
    }
}


[System.Serializable]
public class Usuario
{
    public string id;
    public string email;
    public string tipo;
    public string created_at;
    public string updated_at;

    public override string ToString()
    {
        return string.Format("Id: {1}   Email: {2}   tipo:  {3}", id, email, tipo);
    }
}

public class ListaUsuario
{
    public List<Usuario> usuarios;

    public string Listar()
    {

        foreach (Usuario CadaUsuario in usuarios)
        {
            ControladorLogin.Id = CadaUsuario.id;
            ControladorLogin.Tipo = CadaUsuario.tipo;
            Debug.Log(ControladorLogin.Id);
            return "";
        }

        return "";
    }
}