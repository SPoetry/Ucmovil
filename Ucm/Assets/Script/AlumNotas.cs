using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AlumNotas : MonoBehaviour
{
    public static string id;
    public static string id_alumno;
    public static string nombre;
    public static string nombre_alumno;
    public Text Name;

    public void CambioVista(Text Numero)
    {
        id = Numero.text;
        nombre = Name.text;
        SceneManager.LoadScene("ListaAlumnos");
    }

    public void VerNotas(Text Numero)
    {
        id_alumno = Numero.text;
        nombre_alumno = Name.text;
        SceneManager.LoadScene("IngresarNotas");
    }
}
