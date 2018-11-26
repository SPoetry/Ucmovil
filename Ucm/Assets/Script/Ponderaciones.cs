using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ponderaciones : MonoBehaviour {
    public static string id;
    public static string nombre;
    public Text Name;

    public void CambioVista(Text Numero)
    {
        id = Numero.text;
        nombre = Name.text;
        SceneManager.LoadScene("Ponderaciones");
    }
}
