using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorLogin : MonoBehaviour {

    [SerializeField]
    public static string InicioUrl = "http://192.168.43.138:8000/";

    string getURL = InicioUrl + "log";

    public InputField Correo;
    public InputField Contrasena;
    public GameObject ErrorLogin;
    public GameObject Cargando;

    public static string Id;
    public static string Tipo;

    public void EnvioDatos()
    {
        Cargando.SetActive(true);
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
        getURL = "http://192.168.43.138:8000/log";

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
                Cargando.SetActive(false);
                SceneManager.LoadScene("Lobby");
            }
            else if (Tipo == "secretaria")
            {
                Tipo = "secretarias";
                Cargando.SetActive(false);
                SceneManager.LoadScene("Lobby");
            }
            else if (Tipo == "profesor")
            {
                Tipo = "profesores";
                Cargando.SetActive(false);
                SceneManager.LoadScene("Lobby");
            }
            else if (Tipo == "director_carrera")
            {
                Tipo = "directores_carreras";
                Cargando.SetActive(false);
                SceneManager.LoadScene("Lobby");
            }
        }
        else
        {
            Cargando.SetActive(false);
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