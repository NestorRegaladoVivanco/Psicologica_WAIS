using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeEscenas : MonoBehaviour
{
    static public int eventoSeleccionado;
    static public string identificadorDePrueba;
    private string codigo = "";
    // Start is called before the first frame update
    public void LoadGame()
    {
        //para ingresar al juego 
        if (codigo.Length == 0)
        {
            //comprobacion de la base de datos aqui
            //si el campo no cumple con las esificaciones sale 
            Debug.Log("NO se puede acceder poner el mensaje de error");

        }
        else
        {
           //Si es correcto entrar al juego 
            eventoSeleccionado = -1;
            identificadorDePrueba = codigo;
            Debug.Log("Entra al juego desde el inicio ");
            SceneManager.LoadScene("Game");
        }
    }

    public void LoadSelectEvent()
    {
        //para ingresar al juego 
        if (codigo.Length == 0)
        {
            //comprobacion de la base de datos aqui
            //si el campo no cumple con las esificaciones sale 
            Debug.Log("NO se puede acceder poner el mensaje de error");

        }
        else
        {
           //Si es correcto entrar al juego 
            identificadorDePrueba = codigo;
            Debug.Log("Entra a seleccionar prueba ");
            SceneManager.LoadScene("SelectEvent");
        }
        
    }

    public void LoadMainMenu()
    {
        // Regresa al menu principal
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void cargarEvento(int opcion)
    {
        eventoSeleccionado = opcion;
        SceneManager.LoadScene("Game");
    }

    public void setcodigo(string codigo)
    {
        //obtener el codigo del textInput y ponerlo en la variable local para evaluarla en playGame
        this.codigo = codigo;
    }
}
