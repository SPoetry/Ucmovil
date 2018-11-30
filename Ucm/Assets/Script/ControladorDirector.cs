using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDirector : MonoBehaviour {

    public GameObject Asignatura;
    public GameObject PrefabAsignatura;

    private string AsignaturaURL = ControladorLogin.InicioUrl + "d_escuela/mostrar_asignatura";

    public static string[] Campo1;
    public static string[] Campo2;
    public static string[] Campo3;
    public static string[] Campo4;

    public void CambioEscena(string escena) {
        SceneManager.LoadScene(escena);
    }

    private void Start()
    {
        StartCoroutine("Asignaturas");
    }

    public IEnumerator Asignaturas()
    {
        WWW AsignaturasObtenidas = new WWW(AsignaturaURL);
        yield return AsignaturasObtenidas;

        string LoteAsignaturas = AsignaturasObtenidas.text;
        string[] Asignaturas = LoteAsignaturas.Split("/"[0]);

        Campo1 = new string[(Asignaturas.Length + 1)];
        Campo2 = new string[(Asignaturas.Length + 1)];
        Campo3 = new string[(Asignaturas.Length + 1)];
        Campo4 = new string[(Asignaturas.Length + 1)];

        for (int i = 0 ; i <Asignaturas.Length; i++)
        {
            
            //Debug.Log(Asignaturas[i]);
            string[] CamposAsignatura = Asignaturas[i].Split("."[0]);
            if(CamposAsignatura[0] != "")
            {   
                Campo1[i] = CamposAsignatura[0];
                Campo2[i] = CamposAsignatura[1];
                Campo3[i] = CamposAsignatura[2];
                Campo4[i] = CamposAsignatura[3];
                if (CamposAsignatura[3] == "")
                {
                    Campo4[i] = "null";
                }
            }
        }
    }
}
