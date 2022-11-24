using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pruebaConOpciones6 : MonoBehaviour
{
    [SerializeField]
    private Toggle[] elecciones;

    public int respuestasConseguidas;

    private int[,] resultados;
    private int pruebaActual;
    // Start is called before the first frame update
    void Start()
    {
        resultados = new int [28,6] {  
                        {1,0,1,0,0,1}, {1,1,0,0,0,1}, //Ejemplo / Demo
                        {0,1,1,0,1,0}, {1,1,0,0,1,0}, // 1 / 2
                        {1,0,0,1,0,1}, {0,1,1,0,0,1}, // 3 / 4
                        {0,0,1,0,1,1}, {1,0,1,0,0,1}, // 5 / 6
                        {0,1,0,0,1,1}, {1,0,1,1,0,0}, // 7 / 8
                        {1,0,1,0,0,1}, {1,1,0,0,1,0}, // 9 / 10
                        {1,1,0,0,1,0}, {1,0,0,1,1,0}, // 11 / 12
                        {0,0,1,1,0,1}, {1,1,0,0,0,1}, // 13 / 14
                        {0,1,1,1,0,0}, {0,0,1,1,0,1}, // 15 / 16
                        {1,1,0,0,0,1}, {1,0,0,0,1,1}, // 17 / 18
                        {0,1,1,0,1,0}, {1,0,1,1,0,0}, // 19 / 20
                        {1,0,0,0,1,1}, {0,1,1,0,1,0}, // 21 / 22
                        {0,0,1,1,0,1}, {0,0,1,1,1,0}, // 23 / 24
                        {1,1,1,0,0,0}, {0,0,1,1,0,1}  // 25 / 26
                    };
        pruebaActual=-1;
        respuestasConseguidas=0;
    }

    public void laRespuestaEsCorrecta()
    {
        GameObject puzzleVisual = GameObject.Find("Eventos/PuzzlesVisuales");
        int respuestaCorrecta = 0;
        if(pruebaActual!=-1 && pruebaActual!=28)
        {
            
            for(int recorre = 0; recorre<6 ; recorre++)
            {
                if(elecciones[recorre].isOn == Convert.ToBoolean(resultados[pruebaActual,recorre]))
                {
                    respuestaCorrecta = respuestaCorrecta+1;
                }
                elecciones[recorre].isOn=false;
            }

            if(respuestaCorrecta==6) // Si al comparar los resultados, el numero de respuestas correcta es 6, se notifica como correcto en la prueba y se le suma un punto.
            {
                print("Prueba: "+(pruebaActual-1)+ " es Correcta" );
                respuestasConseguidas= respuestasConseguidas+1;
            }
            else // Si no pues solo se notifica
            {
                print("Prueba: "+(pruebaActual-1) + " es Incorrecta" );
            }

            pruebaActual = pruebaActual+1; // Se mueve a la siguiente prueba.
        }
        
        if ((puzzleVisual.transform.GetChild(0).gameObject).activeSelf == true) // Se notifica el inicio de la prueba de puzzles
        {
            print("Comienza prueba puzzles" );
            pruebaActual = pruebaActual+1;
        }

    }

}
