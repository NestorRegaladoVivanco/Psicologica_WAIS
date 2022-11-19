using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeEscenas : MonoBehaviour
{
    static public int eventoSeleccionado;
    // Start is called before the first frame update
    public void LoadGame()
    {
        eventoSeleccionado=-1;
        SceneManager.LoadScene("Game");
    }

    public void LoadSelectEvent()
    {
        SceneManager.LoadScene("SelectEvent");
    }

    public void LoadMainMenu()
    {
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

}
