using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pruebaConOpcionesDe5 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textoDropdown; // resultado del Dropdawn capturado del usuario
     [SerializeField]
    private TMP_Dropdown dropDown; // Dropdawn para resetear la posicion de la respuesta del usuario.

    [SerializeField]
    public int respuestasConseguidasMatriz, // Informacion del resultado de las respuestas del evento Matriz
                respuestasConseguidasBalanza; // Informacion del resultado de las respuestas del evento Balanza

    private int[] resultadosMatricez,resultadosBalanzas; // Resultados de los eventos matriz y balanzas donde posteriormente se compara con los del usuario.
    private int pruebaActual; // Control del orden de la prueba actual.
    private bool trabajandoMatrices; // Se lleva un control del evento Matricez del que se esta trabajando
    private bool trabajandoBalanzas; // Se lleva un control del evento Balanzas del que se esta trabajando
    // Start is called before the first frame update
    void Start()
    {
        resultadosMatricez = new int [] {   // Se inicializa los resultados del evento de matricez
                5,4,3,2,1,
                5,3,4,4,1,
                5,2,1,5,1,
                3,5,2,3,1,
                4,2,1,5,4,
                2,3,4 };
        resultadosBalanzas = new int [] { // Se inicializa los resultados del evento de balanzas
                3,2,1,5,1,
                2,3,4,1,4,
                4,5,1,2,5, 
                3,1,4,1,3,
                3,2,2,2,5,
                3,5,1,2,4 };
        
        pruebaActual=-1; // Se inicializa el orden de pruebas.
        // Se inicializa las respuestas conseguidas del evento de:
        respuestasConseguidasMatriz=0; // Matricez
        respuestasConseguidasBalanza=0; // Balanzas
        // Se inicializa el control de eventos de:
        trabajandoMatrices=false; // Matricez.
        trabajandoBalanzas=false; // Balanzas.
    }

    private int acomodarRespuesta(string respuesta) // Traduce las respuestas del dropdawn para luego comparar con los resultados del evento.
    {
        if(respuesta == "Figura 1")
        {
            return 1;
        }
        if(respuesta == "Figura 2")
        {
            return 2;
        }
        if(respuesta == "Figura 3")
        {
            return 3;
        }
        if(respuesta == "Figura 4")
        {
            return 4;
        }
        if(respuesta == "Figura 5")
        {
            return 5;
        }
        return 0;
    }

        public void laRespuestaEsCorrecta()
    {
        GameObject matrices = GameObject.Find("Eventos/Matrices/01");
        GameObject balanzas = GameObject.Find("Eventos/Balanzas/01");
        #region Matrices
        if(pruebaActual!=-1 && pruebaActual!=28 && trabajandoMatrices)// Control del recorrido del evento de matricez
        {
            // Comprueba que la respuestas del evento matriz con las del usuario
            if(resultadosMatricez[pruebaActual] == acomodarRespuesta(textoDropdown.text)) // Si es correcto, suma un punto y lo notifica
            {
                print("Prueba: "+(pruebaActual-1)+ " es Correcta" );
                respuestasConseguidasMatriz = respuestasConseguidasMatriz+1;
            }
            else // Si no es correcto, solo lo notifica
            {
                print("Prueba: "+(pruebaActual-1) + " es Incorrecta" );
            }

            pruebaActual = pruebaActual+1; // Se mueve a la siguiente prueba
        }else if(pruebaActual>=28 && trabajandoMatrices) // Termina de mostrar el evento de matricez, y reinicia las variables.
        {
            trabajandoMatrices=false;
            pruebaActual=-1;
        }

        if (matrices.activeSelf == true) // Comienza el evento de matricez e inicializa las variables para comenzar.
        {
            print("Comienza prueba de Matrices" );
            trabajandoMatrices = true;
            pruebaActual = pruebaActual+1;
        }
        #endregion

        #region Balanzas
        if ((balanzas.transform.GetChild(0).gameObject).activeSelf == true)
        if(pruebaActual!=-1 && pruebaActual!=30 && trabajandoBalanzas) // Control de recorrido del evento de balanzas
        {
            // Comprueba que la respuestas del evento matriz con las del usuario
            if(resultadosBalanzas[pruebaActual] == acomodarRespuesta(textoDropdown.text)) // Si es correcto, suma un punto y lo notifica
            {
                print("Prueba: "+(pruebaActual-2)+ " es Correcta" );
                respuestasConseguidasBalanza = respuestasConseguidasBalanza+1;
            }
            else // Si no es correcto, solo lo notifica
            {
                print("Prueba: "+(pruebaActual-2) + " es Incorrecta" );
            }

            pruebaActual = pruebaActual+1; // Se mueve a la siguiente prueba
        }else if(pruebaActual>=30 && trabajandoBalanzas) // Termina de mostrar el evento de balanzas, y reinicia las variables.
        {
            trabajandoBalanzas=false;
            pruebaActual=0;
        }

        if (balanzas.activeSelf == true) // Comienza el evento de balanzas e inicializa las variables para comenzar.
        {
            print("Comienza prueba de Balanzas" );
            trabajandoBalanzas= true;
            pruebaActual = pruebaActual+1;
        }
        #endregion
        dropDown.value=0; // Se reinicia el estado del dropdawn a la primera posicion.
    }

}
