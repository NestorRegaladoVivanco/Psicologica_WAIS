using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using UnityEngine.Networking;
using Newtonsoft.Json;


public class puntuacionDeEventos : MonoBehaviour
{

    [SerializeField]
    private GameObject puntos;
    [SerializeField]
    private TextMeshProUGUI[] cuadroDeTextoInstrucciones;
    [SerializeField]
    private ControlDeEventosv2 eventos;
    [SerializeField]
    private capturaCubo numCubos;
    [SerializeField]
    private capturaDeDropdawn numDropdawn;
    [SerializeField]
    private capturaDeTextMeshPro numTextMeshPro;
    [SerializeField]
    private capturaDeToggles numToggles;

    private int pruebaAnterior;

    string url;
    string actualizarEvento;
    GameObject carga;

    void Start()
    {
        pruebaAnterior=-1;
        carga = GameObject.Find("Canvas/Spinner");
        carga.SetActive(false);
    }

    private void mostrarPuntos()
    {   // Cubos
        url = "";
        actualizarEvento = "";

        if(eventos.numDeEvento == 0 && eventos.numDePrueba == capturaCubo.numDePruebasCubos)
        { 
            print("!!!!!!!!!!!!!!!!!!!!!!!!");
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[0].text= numCubos.puntuacionCubos.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modCubos.php?id="+eventos.numDeIdentificador+"&cubos="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"cubos\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        } 
        // Semejanzas
        else if(eventos.numDeEvento == 1 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasSemejanzas)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[1].text = numTextMeshPro.puntuacionSemejanzas.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modSemejanzas.php?id="+eventos.numDeIdentificador+"&sem="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"semejanzas\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Digitos 
        else if(eventos.numDeEvento == 2 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasDigitos)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[2].text = numTextMeshPro.puntuacionDigitos.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modDigitos.php?id="+eventos.numDeIdentificador+"&digitos="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"digitos\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Matrices 
        else if(eventos.numDeEvento == 3 && eventos.numDePrueba == capturaDeDropdawn.numDePruebasMatricez)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[3].text = numDropdawn.respuestasCorrectasMatriz.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modMatriz.php?id="+eventos.numDeIdentificador+"&matriz="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"matriz\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Vocabulario 
        else if(eventos.numDeEvento == 4 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasVocabulario)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[4].text = numTextMeshPro.puntuacionVocabulario.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modVocabulario.php?id="+eventos.numDeIdentificador+"&voc="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"vocabulario\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Aritmetica 
        else if(eventos.numDeEvento == 5 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasAritmetica)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[5].text = numTextMeshPro.puntuacionAritmetica.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modAritmetica.php?id="+eventos.numDeIdentificador+"&ar="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"aritmetica\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Busqueda de simbolos
        else if(eventos.numDeEvento == 6 && eventos.numDePrueba == capturaDeToggles.numDePruebasBusquedaDeSimbolos)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[6].text = numToggles.puntuacionDeBusquedaDeSimbolos.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modBusquedaS.php?id="+eventos.numDeIdentificador+"&bus="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"busquedaS\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Puzzles visaules
        else if(eventos.numDeEvento == 7 && eventos.numDePrueba == capturaDeToggles.numDePruebasPuzlesVisuales)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[7].text = numToggles.puntuacionDePuzzleVisual.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modPluzzeV.php?id="+eventos.numDeIdentificador+"&plu="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"pluzzeV\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Informacion
        else if(eventos.numDeEvento == 8 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasInformacion)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[8].text = numTextMeshPro.puntuacionInformacion.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modptnInformacion.php?id="+eventos.numDeIdentificador+"&ptn="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"ptnInformacion\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Clave de numeros
        else if(eventos.numDeEvento == 9 && eventos.numDePrueba == capturaDeDropdawn.numDePruebasClaveDeNumeros)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[9].text = numDropdawn.respuestasCorrectasClaveDeNumeros.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modCaveNum.php?id="+eventos.numDeIdentificador+"&clave="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"claveNum\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
         // Letras y numeros
        else if(eventos.numDeEvento == 10 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasLetrasNumeros)
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[10].text = numTextMeshPro.puntuacionLetrasNumeros.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modLetrasNum.php?id="+eventos.numDeIdentificador+"&letras="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"letrasNum\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Balanzas
        else if(eventos.numDeEvento == 11 && eventos.numDePrueba == capturaDeDropdawn.numDePruebasBalanzas)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[11].text = numDropdawn.respuestasCorrectasBalanza.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modBalanzas.php?id="+eventos.numDeIdentificador+"&balanzas="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"balanzas\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Comprension
        else if(eventos.numDeEvento == 12 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasComprension)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[12].text = numTextMeshPro.puntuacionComprension.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modComprension.php?id="+eventos.numDeIdentificador+"&comprension="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"comprension\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Cancelacion
        else if(eventos.numDeEvento == 13 && eventos.numDePrueba == capturaDeToggles.numDePruebasCancelacion)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[13].text = numToggles.puntuacionDeCancelacion.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modCancelacion.php?id="+eventos.numDeIdentificador+"&cancelacion="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"cancelacion\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        // Figuras incompletas
        else if(eventos.numDeEvento == 14 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasFigIncompleta)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[14].text = numTextMeshPro.puntuacionFigIncompleta.ToString();
            url = "https://testpsicologicow.000webhostapp.com/modPuntuaciones/modFigcompleta.php?id="+eventos.numDeIdentificador+"&completa="+cuadroDeTextoInstrucciones[eventos.numDeEvento].text;
            actualizarEvento = "{\"figCompleta\":"+cuadroDeTextoInstrucciones[eventos.numDeEvento].text+"}";
        }
        else{
            puntos.SetActive(false);
        }

        // Si se actualizo puntuacion, se envia a la base de datos el cambio
        if (actualizarEvento != ""){
            Debug.Log("Se envia el url: " + actualizarEvento);
            StartCoroutine(CorrutinaEscribir(actualizarEvento));
        }

    }

    private IEnumerator CorrutinaEscribir(string actualizarEvento)
    {
        string url ="http://localhost:8080/UpdateGame/"+eventos.numDeIdentificador;
        Debug.Log(url);

        UnityWebRequest web = UnityWebRequest.Put( url, actualizarEvento);
        web.SetRequestHeader("accept", "application/json");
        web.SetRequestHeader("Content-Type", "application/json");

        carga.SetActive(true);
        yield return web.SendWebRequest();
        carga.SetActive(false);

        if(!web.isNetworkError && !web.isHttpError)
        {
            Debug.Log("Se actualizaron los puntos");
        // handle the success case here
        } else {
            Debug.Log("Hubo un problema...");
        }
    }

    void Update()
    {
        if(pruebaAnterior != eventos.numDePrueba){
            pruebaAnterior = eventos.numDePrueba;
            int pruebaActual = eventos.numDePrueba-1;
            numCubos.eventoCubos(pruebaActual);
            mostrarPuntos();
        }
    }
}
