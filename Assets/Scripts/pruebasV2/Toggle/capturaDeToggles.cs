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
    public static int numDePruebasCancelacion=4;
    
    private respuestaToggle[] resToggleBusquedaDeSimbolos = new respuestaToggle [numDePruebasBusquedaDeSimbolos];
    private respuestaToggle[] resTogglePuzzlesVisuales = new respuestaToggle [numDePruebasPuzlesVisuales];
    private respuestaToggle[] resToggleCancelacion = new respuestaToggle [numDePruebasCancelacion];
    
    public int puntuacionDeBusquedaDeSimbolos;
    public int puntuacionDePuzzleVisual;
    public int puntuacionDeCancelacion;

    private int pruebaAnterior;

    // Start is called before the first frame update
    void Start()
    {   
        // Inicializa respuestas de busquedaDeSimbolos
        GameObject busquedaDeSimbolos = GameObject.Find("Eventos/BusquedaDeSimbolos");
        for(int asignar=0;asignar < numDePruebasBusquedaDeSimbolos;asignar++)
        {
            resToggleBusquedaDeSimbolos[asignar] = (busquedaDeSimbolos.transform.GetChild(asignar).gameObject).GetComponent<respuestaToggle>();
        }

        // Inicializa respuestas de PuzzlesVisuales
        GameObject puzzleVisual = GameObject.Find("Eventos/PuzzlesVisuales");
        for(int asignar=0;asignar < numDePruebasPuzlesVisuales;asignar++)
        {
            resTogglePuzzlesVisuales[asignar] = (puzzleVisual.transform.GetChild(asignar).gameObject).GetComponent<respuestaToggle>();
        }

        // Inicializa respuestas de Cancelacion
        GameObject cancelacion = GameObject.Find("Eventos/Cancelacion");
        for(int asignar=0;asignar < numDePruebasCancelacion;asignar++)
        {
            resToggleCancelacion[asignar] = (cancelacion.transform.GetChild(asignar).gameObject).GetComponent<respuestaToggle>();
        }

        puntuacionDeBusquedaDeSimbolos=0;
        puntuacionDePuzzleVisual=0;
        puntuacionDeCancelacion=0;

        pruebaAnterior=-1;
    }

    private void eventoBusquedaDeSimbolos(int pruebaBusqueda)
    {
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

    private void eventoPuzzleVisual(int pruebaPuzzle)
    {
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
    
    private void eventoCancelacion(int pruebaCancelacion)
    {
        if(controlDeEventos.numDeEvento==13 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasCancelacion+1) // Espera al evento de Cancelacion
        {
            // Asigna eleccionesC por cada prueba, ya que es de distintos cantidades
            
            GameObject cancelacionTogglesC = (GameObject.Find("Eventos/Cancelacion")).transform.GetChild(pruebaCancelacion).GetChild(0).gameObject;
            Toggle[] eleccionesC = new Toggle[cancelacionTogglesC.transform.childCount]; // Formato para Cancelacion
            for(int asignar=0;asignar < cancelacionTogglesC.transform.childCount;asignar++)
            {
                eleccionesC[asignar] = (cancelacionTogglesC.transform.GetChild(asignar).gameObject).GetComponent<Toggle>();
            }

            if(pruebaCancelacion == 0){ // Anuncia el comienzo del evento
                print("Inicia Cancelacion");
            }
            print("Prueba: "+(pruebaCancelacion));
            for(int recorre = 0; recorre < resToggleCancelacion[pruebaCancelacion].respuestas.Length ; recorre++) // Comprueba el resultado
            {
                
                if(resToggleCancelacion[pruebaCancelacion].respuestas[recorre])
                {
                    print((eleccionesC[recorre]).isOn +" / "+resToggleCancelacion[pruebaCancelacion].respuestas[recorre]);
                    print((eleccionesC[recorre]).isOn == resToggleCancelacion[pruebaCancelacion].respuestas[recorre]);
                
                    if((eleccionesC[recorre]).isOn == resToggleCancelacion[pruebaCancelacion].respuestas[recorre])
                    {
                        print("Posicion: "+recorre + " es Correcta" );
                        puntuacionDeCancelacion = puntuacionDeCancelacion+1;
                    }else{
                        print("Posicion: "+recorre + " es Incorrecta" );
                    }
                }
                //Resetea el estado de los Toggle para el siguiente prueba
                (eleccionesC[recorre]).isOn=false;
            }
        }
    }

    void Update(){
        if(pruebaAnterior!=controlDeEventos.numDePrueba){
            pruebaAnterior=controlDeEventos.numDePrueba;
            int pruebaActual = controlDeEventos.numDePrueba-1;
            eventoBusquedaDeSimbolos(pruebaActual);
            eventoPuzzleVisual(pruebaActual);
            eventoCancelacion(pruebaActual);
        }
    }
}
