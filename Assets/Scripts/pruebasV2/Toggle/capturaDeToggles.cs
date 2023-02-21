using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class capturaDeToggles : MonoBehaviour
{
    [SerializeField]
    private Toggle[] eleccionesA; // Formato 2 x 3
    [SerializeField]
    private Toggle[] eleccionesB; // Formato 1 x 6

    [SerializeField]
    private ControlDeEventosv2   controlDeEventos;

    public static int numDePruebasBusquedaDeSimbolos=66;
    public static int numDePruebasPuzlesVisuales=28;
    
    private respuestaToggle[] resToggleBusquedaDeSimbolos = new respuestaToggle [numDePruebasBusquedaDeSimbolos];
    private respuestaToggle[] resTogglePuzzlesVisuales = new respuestaToggle [numDePruebasPuzlesVisuales];

    public int puntuacionDeBusquedaDeSimbolos;
    public int puntuacionDePuzzleVisual;

    private int pruebaAnterior;

    // Start is called before the first frame update
    void Start()
    {   
        inicializaResToggleBusquedaDeSimbolos();
        inicializaResTogglePuzlesVisuales();

        puntuacionDeBusquedaDeSimbolos=0;
        puntuacionDePuzzleVisual=0;

        pruebaAnterior=-1;
    }

    void inicializaResToggleBusquedaDeSimbolos()
    {
        GameObject busquedaDeSimbolos = GameObject.Find("Eventos/BusquedaDeSimbolos");
        for(int asignar=0;asignar < numDePruebasBusquedaDeSimbolos;asignar++)
        {
            resToggleBusquedaDeSimbolos[asignar] = (busquedaDeSimbolos.transform.GetChild(asignar).gameObject).GetComponent<respuestaToggle>();
        }
    }

    void inicializaResTogglePuzlesVisuales()
    {
        GameObject puzzleVisual = GameObject.Find("Eventos/PuzzlesVisuales");
        for(int asignar=0;asignar < numDePruebasPuzlesVisuales;asignar++)
        {
            resTogglePuzzlesVisuales[asignar] = (puzzleVisual.transform.GetChild(asignar).gameObject).GetComponent<respuestaToggle>();
        }
    }

    private void eventoBusquedaDeSimbolos()
    {
        int pruebaBusqueda = controlDeEventos.numDePrueba-1;
        if(controlDeEventos.numDeEvento==6 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasBusquedaDeSimbolos+1) // Espera al evento de Puzzle Visual
        {
            if(pruebaBusqueda == 0){ // Anuncia el comienzo del evento
                print("Inicia Busqueda De Simbolos");
            }
            int respuestaCorrecta = 0;
            for(int recorre = 0; recorre<6 ; recorre++) // Comprueba el resultado
            {
                //print((eleccionesB[recorre]).isOn +" / "+resToggleBusquedaDeSimbolos[pruebaBusqueda].respuestas[recorre]+" : "+pruebaBusqueda);
                //print((eleccionesB[recorre]).isOn == resToggleBusquedaDeSimbolos[pruebaBusqueda].respuestas[recorre]);
                if((eleccionesB[recorre]).isOn == resToggleBusquedaDeSimbolos[pruebaBusqueda].respuestas[recorre])
                {
                    respuestaCorrecta = respuestaCorrecta+1;
                }
                //Resetea el estado de los Toggle para el siguiente prueba
                (eleccionesB[recorre]).isOn=false;
            }
            if(respuestaCorrecta==6) // Si al comparar los resultados, el numero de respuestas correcta es 6, se notifica como correcto en la prueba y se le suma un punto.
            {
                print("Prueba: "+(pruebaBusqueda)+ " es Correcta" );
                puntuacionDeBusquedaDeSimbolos = puntuacionDeBusquedaDeSimbolos+1;
            }
            else // Si no pues solo se notifica
            {
                print("Prueba: "+(pruebaBusqueda) + " es Incorrecta" );
            }
        }
    }

    private void eventoPuzzleVisual()
    {
        int pruebaPuzzle = controlDeEventos.numDePrueba-1;
        if(controlDeEventos.numDeEvento==7 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasPuzlesVisuales+1) // Espera al evento de Puzzle Visual
        {
            if(pruebaPuzzle == 0){ // Anuncia el comienzo del evento
                print("Inicia PuzzleVisual");
            }
            int respuestaCorrecta = 0;
            for(int recorre = 0; recorre<6 ; recorre++) // Comprueba el resultado
            {
                //print((eleccionesA[recorre]).isOn +" / "+resTogglePuzzlesVisuales[pruebaPuzzle].respuestas[recorre]+" : "+pruebaPuzzle);
                //print((eleccionesA[recorre]).isOn == resTogglePuzzlesVisuales[pruebaPuzzle].respuestas[recorre]);
                if((eleccionesA[recorre]).isOn == resTogglePuzzlesVisuales[pruebaPuzzle].respuestas[recorre])
                {
                    respuestaCorrecta = respuestaCorrecta+1;
                }
                //Resetea el estado de los Toggle para el siguiente prueba
                (eleccionesA[recorre]).isOn=false;
            }
            if(respuestaCorrecta==6) // Si al comparar los resultados, el numero de respuestas correcta es 6, se notifica como correcto en la prueba y se le suma un punto.
            {
                print("Prueba: "+(pruebaPuzzle)+ " es Correcta" );
                puntuacionDePuzzleVisual= puntuacionDePuzzleVisual+1;
            }
            else // Si no pues solo se notifica
            {
                print("Prueba: "+(pruebaPuzzle) + " es Incorrecta" );
            }
        }
    }
    

    void Update(){
        if(pruebaAnterior!=controlDeEventos.numDePrueba){
            pruebaAnterior=controlDeEventos.numDePrueba;
            eventoBusquedaDeSimbolos();
            eventoPuzzleVisual();
        }
    }

}
