using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mostrarPuntuacion : MonoBehaviour
{
    public GameObject puntos;
    public TextMeshProUGUI[] cuadroDeTextoInstrucciones;
    public ControlDeEventos eventos;
    public pruebaConOpcionesDe5 opcion5;
    public pruebaConOpciones6 opcion6;
    public pruebaCuadroDeRespuesta cuadroDeRespuesta;


    void Start()
    {
        
    }

    public void mostrarPuntos()
    {
        if(eventos.numDeEvento == 1 && eventos.numDePrueba == 0 ||eventos.numDeEvento == 0 && eventos.numDePrueba == 3) // Cubos
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[0].text= "--";
        
        }
        else if(eventos.numDeEvento == 2 && eventos.numDePrueba == 0 ||eventos.numDeEvento == 1 && eventos.numDePrueba == 29) // Matrices
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[1].text= opcion5.respuestasConseguidasMatriz.ToString();
        }
        else if(eventos.numDeEvento == 3 && eventos.numDePrueba == 0 ||eventos.numDeEvento == 2 && eventos.numDePrueba == 24) // Vocabulario
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[2].text= cuadroDeRespuesta.respuestasConseguidaVocabulario.ToString();
        }
        else if(eventos.numDeEvento == 4 && eventos.numDePrueba == 0 ||eventos.numDeEvento == 3 && eventos.numDePrueba == 6) // Aritmetica
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[3].text= cuadroDeRespuesta.respuestasConseguidasAritmetica.ToString();
        }
        else if(eventos.numDeEvento == 5 && eventos.numDePrueba == 0||eventos.numDeEvento == 4 && eventos.numDePrueba == 29) // Puzzle Visual
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[4].text= opcion6.respuestasConseguidas.ToString();
        }
        else if(eventos.numDeEvento == 6 && eventos.numDePrueba == 0 ||eventos.numDeEvento == 5 && eventos.numDePrueba == 31) // Balanzas
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[5].text= opcion5.respuestasConseguidasBalanza.ToString();
        }
        else if(eventos.numDeEvento == 7 && eventos.numDePrueba == 0 ||eventos.numDeEvento == 6 && eventos.numDePrueba == 26) // Figuras incompletas
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[6].text= cuadroDeRespuesta.respuestasConseguidasFigIncompleta.ToString();
        }else
        {
            puntos.SetActive(false);
        }

    }
}
