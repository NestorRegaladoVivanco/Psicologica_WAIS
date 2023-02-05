using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class puntuacionDeEventos : MonoBehaviour
{

    [SerializeField]
    private GameObject puntos;
    [SerializeField]
    private TextMeshProUGUI[] cuadroDeTextoInstrucciones;
    [SerializeField]
    private ControlDeEventosv2 eventos;
    [SerializeField]
    private capturaDeDropdawn numDropdawn;
    [SerializeField]
    private capturaDeTextMeshPro numTextMeshPro;
    [SerializeField]
    private capturaDeToggles numToggles;


    void Start()
    {
        
    }

    public void mostrarPuntos()
    {   // Cubos
        if(eventos.numDeEvento == 0 && eventos.numDePrueba == 3)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[0].text= "--";
        } 
        // Semejanzas
        else if(eventos.numDeEvento == 1 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasSemejanzas + 1)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[1].text = "--";
        }
        // Digitos 
        else if(eventos.numDeEvento == 2 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasDigitos + 1)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[2].text = "--";
        }
        // Matrices 
        else if(eventos.numDeEvento == 3 && eventos.numDePrueba == capturaDeDropdawn.numDePruebasMatricez+ 1)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[3].text = numDropdawn.respuestasCorrectasMatriz.ToString();
        }
        // Vocabulario 
        else if(eventos.numDeEvento == 4 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasVocabulario+1)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[4].text = numTextMeshPro.puntuacionVocabulario.ToString();
        }
        // Aritmetica 
        else if(eventos.numDeEvento == 5 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasAritmetica +1)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[5].text = numTextMeshPro.puntuacionAritmetica.ToString();
        }
        // Busqueda de simbolos
        else if(eventos.numDeEvento == 6 && eventos.numDePrueba == /*numDePruebasBusquedaDeSimbolos + */18)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[6].text = "--";
        }
        // Puzzles visaules
        else if(eventos.numDeEvento == 7 && eventos.numDePrueba == capturaDeToggles.numDePruebas+1)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[7].text = numToggles.puntuacionDePuzzleVisual.ToString();
        }
        // Informacion
        else if(eventos.numDeEvento == 8 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasInformacion +1)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[8].text = "--";
        }
        // Clave de numeros
        else if(eventos.numDeEvento == 9 && eventos.numDePrueba == /*numDePruebasClaveDeNumeros +*/18)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[9].text = "--";
        }
         // Letras y numeros
        else if(eventos.numDeEvento == 10 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasLetrasNumeros +1)
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[10].text = "--";
        }
        // Balanzas
        else if(eventos.numDeEvento == 11 && eventos.numDePrueba == capturaDeDropdawn.numDePruebasBalanzas+1)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[11].text = numDropdawn.respuestasCorrectasBalanza.ToString();
        }
        // Comprension
        else if(eventos.numDeEvento == 12 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasComprension + 1)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[12].text = "--";
        }
        // Cancelacion
        else if(eventos.numDeEvento == 13 && eventos.numDePrueba == /*numDePruebasCancelacion +*/18)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[13].text = "--";
        }
        // Figuras incompletas
        else if(eventos.numDeEvento == 14 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasFigIncompleta+1)
        { 
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[14].text = numTextMeshPro.puntuacionFigIncompleta.ToString();
        }
        else{
            puntos.SetActive(false);
        }

        
    }
}
