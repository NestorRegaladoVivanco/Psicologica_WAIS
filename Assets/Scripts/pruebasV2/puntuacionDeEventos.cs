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
    {
        if(eventos.numDeEvento == 0 && eventos.numDePrueba == 3)
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[0].text= "--";
        }
        else if(eventos.numDeEvento == 1 && eventos.numDePrueba == capturaDeDropdawn.numDePruebasMatricez+1)
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[1].text = numDropdawn.respuestasCorrectasMatriz.ToString();
        }
        else if(eventos.numDeEvento == 2 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasVocabulario+1)
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[2].text = numTextMeshPro.puntuacionVocabulario.ToString();
        }
        else if(eventos.numDeEvento == 3 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasAritmetica+1)
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[3].text = numTextMeshPro.puntuacionAritmetica.ToString();
        }
        else if(eventos.numDeEvento == 4 && eventos.numDePrueba == capturaDeToggles.numDePruebas+1)
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[4].text = numToggles.puntuacionDePuzzleVisual.ToString();
        }
        else if(eventos.numDeEvento == 5 && eventos.numDePrueba == capturaDeDropdawn.numDePruebasBalanzas+1)
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[5].text = numDropdawn.respuestasCorrectasBalanza.ToString();
        }
        else if(eventos.numDeEvento == 6 && eventos.numDePrueba == capturaDeTextMeshPro.numDePruebasFigIncompleta+1)
        {
            puntos.SetActive(true);
            cuadroDeTextoInstrucciones[6].text = numTextMeshPro.puntuacionFigIncompleta.ToString();
        }
        else{
            puntos.SetActive(false);
        }

        
    }
}
