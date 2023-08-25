using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ControlDeEscenas : MonoBehaviour
{
    [System.Serializable]
    public struct GameStruct
    {
        public bool active;
        public int aritmetica;
        public int balanzas;
        public int busquedaS;
        public int cancelacion;
        public int claveNum;
        public string codigo;
        public int comprension;
        public int cubos;
        public int digitos;
        public int figCompleta;
        public string id ;
        public string idCliente ;
        public int letrasNum ;
        public int matriz ;
        public int pluzzeV ;
        public int ptnInformacion ;
        public int semejanzas ;
        public int taritmetica ;
        public int tbalanzas;
        public int tbusquedaS;
        public int tcancelacion ;
        public int tclaveNum ;
        public int tcomprension ;
        public int tcubos ;
        public int tdigitos ;
        public int tfigCompleta ;
        public int tletrasNum ;
        public int tmatriz ;
        public int tpluzzeV ;
        public int tptnInformacion ;
        public int tsemejanzas ;
        public int tvocabulario ;
        public int vocabulario;
    }
    static public int eventoSeleccionado;
    static public string identificadorDePrueba;
    private string codigo;
    private bool codigoValido;
    public GameStruct game;
    GameObject carga;
    
    // Start is called before the first frame update
    void Start()
    {
        eventoSeleccionado = -1;
        codigo = "";
        codigoValido = false;
        carga = GameObject.Find("Canvas/Spinner");
        if(carga != null)
            carga.SetActive(false);
    }
    
    public void ValidarCodigo()
    {
        StartCoroutine(CorrutinaLeer(codigo));
    }

    public void LoadGame()
    {
        //para ingresar al juego 
        if (!codigoValido)
        {
            //comprobacion de la base de datos aqui
            //si el campo no cumple con las esificaciones sale 
            Debug.Log("NO se puede acceder poner el mensaje de error");

        }
        else
        {
           //Si es correcto entrar al juego 
            Debug.Log("Entra al juego desde el inicio ");
            SceneManager.LoadScene("Game");
        }
    }

    public void LoadSelectEvent()
    {
        //para ingresar al juego 
        if (!codigoValido)
        {
            //comprobacion de la base de datos aqui
            //si el campo no cumple con las esificaciones sale 
            Debug.Log("NO se puede acceder poner el mensaje de error");
        }
        else
        {
           //Si es correcto entrar al juego 
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

    private IEnumerator CorrutinaLeer(string codigo)
    {
        UnityWebRequest web = UnityWebRequest.Get("http://localhost:8080/verificatedGame/{codigo}?codigo="+codigo); 
        carga.SetActive(true);
        yield return web.SendWebRequest();
        carga.SetActive(false);

        if(!web.isNetworkError && !web.isHttpError)
        {
            // Recibio respuesta del servidor
            Debug.Log(web.downloadHandler.text);
            game = JsonUtility.FromJson<GameStruct>(web.downloadHandler.text);
            Debug.Log(game.id);
            identificadorDePrueba = game.id;
            codigoValido = true;
        } else {
            Debug.Log("Hubo un problema...");
        }
    }
}
