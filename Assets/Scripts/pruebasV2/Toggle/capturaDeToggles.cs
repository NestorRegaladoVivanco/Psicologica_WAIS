using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class capturaDeToggles : MonoBehaviour
{
    [SerializeField]
    private Toggle[] elecciones;
    [SerializeField]
    private ControlDeEventosv2   controlDeEventos;
    public static int numDePruebas=28;
    private respuestaToggle[] resToggle = new respuestaToggle [numDePruebas];
    public int puntuacionDePuzzleVisual;
    private int pruebaAnterior;

    // Start is called before the first frame update
    void Start()
    {   
        inicializaResToggle();
        puntuacionDePuzzleVisual=0;
        pruebaAnterior=-1;
    }

    void inicializaResToggle()
    {
        GameObject puzzleVisual = GameObject.Find("Eventos/PuzzlesVisuales");
        for(int asignar=0;asignar < numDePruebas;asignar++)
        {
            resToggle[asignar] = (puzzleVisual.transform.GetChild(asignar).gameObject).GetComponent<respuestaToggle>();
        }
    }

    private void eventoPuzzleVisual()
    {
        int pruebaPuzzle = controlDeEventos.numDePrueba-1;
        if(controlDeEventos.numDeEvento==7 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebas+1) // Espera al evento de Puzzle Visual
        {
            if(pruebaPuzzle == 0){ // Anuncia el comienzo del evento
                print("Inicia PuzzleVisual");
            }
            int respuestaCorrecta = 0;
            for(int recorre = 0; recorre<6 ; recorre++) // Comprueba el resultado
            {
                print((elecciones[recorre]).isOn +" / "+resToggle[pruebaPuzzle].respuestas[recorre]+" : "+pruebaPuzzle);
                print((elecciones[recorre]).isOn == resToggle[pruebaPuzzle].respuestas[recorre]);
                if((elecciones[recorre]).isOn == resToggle[pruebaPuzzle].respuestas[recorre])
                {
                    respuestaCorrecta = respuestaCorrecta+1;
                }
                //Resetea el estado de los Toggle para el siguiente prueba
                (elecciones[recorre]).isOn=false;
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
            eventoPuzzleVisual();
        }
    }

}
