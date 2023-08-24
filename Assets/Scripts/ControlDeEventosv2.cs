using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeEventosv2 : MonoBehaviour
{
    public int  numDeEvento,
                numDePrueba,
                // Datos de la escena anterior
                numDePruebaSeleccionada;
    public string numDeIdentificador;

    private bool terminar=false;
    private int pruebaAnterior;
    #region Notas de los eventos
    /*
    numDeInterfaz 
        0 = cubos
        1 = cuadro de texto (textMesh Pro)
        2 = opciones5 (dropDown)
        3 = opciones6A (Toggle 2 x 3)
        4 = opciones6B (Toggle 1 x 6) 
        5 = Sin asignar

    */

    /* Orden de los eventos faltantes
    numDeEvento  -nombre             - numDeInterfaz
-       0       -Cubos                  - 0
        1       -Semejanzas             - 1 87pdf
        2       -Digitos                - 1 (Implementar audio y que aparesca el cuadro de texto despues de reproducirlo?)100pdf
        3       -Matrices               - 2 106pdf
        4       -Vocabulario            - 1 (respuesta descriptiva)? 111pdf
        5       -Aritmetica             - 1 128pdf (agregar faltantes)
        6       -Busqueda de Simbolos   - 4  131pdf  termina:(120 seg en total) si termina antes, anotar el tiempo
        7       -Puzles Visuales        - 3
        8       -Informacion            - 1 145pdf
-       9       -Clave de numeros       - (Interno) Multiples Dropdawns? 153pdf
        10      -Letras y numeros       - 1 159pdf
        11      -Balanzas               - 2
        12      -Comprension            - 1 169pdf
-       13      -Cancelacion            - 4*(Interno) Multiples toggles 183pdf
        14       -Figuras incompletas    - 1 (apuntar y escribir)?
    */ 
    #endregion

    void Start()
    {//Se utiliza para hacer pruebas en un evento especifico o para cuando el usuario selecciona un evento.
        //Se captura la prueba selecciona de la pantalla del menu
        numDePruebaSeleccionada=ControlDeEscenas.eventoSeleccionado;
        //Se captura el identificador del usuario de la pantalla del menu
        numDeIdentificador=ControlDeEscenas.identificadorDePrueba;

        //Si se selecciono uno, se le asigna al numDeEvento, sino pasa a ser 0
        if(numDePruebaSeleccionada!=-1){
            numDeEvento=numDePruebaSeleccionada;
            print("Prueba seleccionada: "+ numDeEvento );
        }else{
            numDeEvento=0;
        }
        numDePrueba=0;
        pruebaAnterior=-1;
    }

    private void controDeInferfazDePruebas(int numDeInterfaz) //Dependiendo de "numDeInterfaz", se mostrara la interfaz deseada
        {
            GameObject uiInterfaz, uiPrueba;
            uiInterfaz = GameObject.Find("Canvas/Interfaz/Pruebas");
            uiPrueba = uiInterfaz.transform.GetChild(numDeInterfaz).gameObject;
            if (uiPrueba.activeSelf == false)
            {
                uiPrueba.SetActive(true);
            }
            else
            {
                uiPrueba.SetActive(false);
            }
        }
    
    private int acomodoDePruebaInterfaz(int numDeEvento) // Eventos que comparten la misma interfaz.
    {
        int numInterfaz;
        switch(numDeEvento)
        {
            case 0: // Interfaz cubos
                numInterfaz = 0;
                break;
            case 1: case 2: case 4: case 5: case 8: case 10: case 12: case 14:// Interfaz cuadro de texto (TextMeshPro)
                numInterfaz =  1;
                break; 
            case 3: case 11: // opciones de 5 (dropDown)
                numInterfaz =  2;
                break;
            case 7: // opciones6A (Toggle 2 x 3)
                numInterfaz =  3;
                break;
            case 6: // opciones6B (Toggle 1 x 6) 
                numInterfaz =  4;
                break;
            case 9: case 13: // Internos (dentro de las pruebas)
                numInterfaz =  5;
                break;
            default: // error
                numInterfaz =  -1;
                break;
        }
        print("numInterfaz: "+numInterfaz);
        return numInterfaz;
    }

    public void recorerEventos( )
    {
        GameObject  eventos = GameObject.Find("Eventos");

        // Mientras tenga eventos o aun no termine.
        if(numDeEvento < eventos.transform.childCount || terminar==false)
        {
            GameObject eventoActual=eventos.transform.GetChild(numDeEvento).gameObject;
            #region Asignacion de Interfas por prueba
            //Si es el primer evento y prueba
            if (numDePrueba == 0)
            {
                controDeInferfazDePruebas(acomodoDePruebaInterfaz(numDeEvento));
                //Si no es el primer evento y prueba
                if(numDeEvento != 0)
                {
                    GameObject eventoAnterior = eventos.transform.GetChild(numDeEvento - 1).gameObject;
                    GameObject pruebaAnterior = eventoAnterior.transform.GetChild(eventoAnterior.transform.childCount - 1).gameObject;
                    // Oculta la prueba anterior
                    pruebaAnterior.SetActive(false);
                    if (numDePruebaSeleccionada == -1) // Si No es seleccionada, oculta el evento anterior
                        controDeInferfazDePruebas(acomodoDePruebaInterfaz(numDeEvento - 1));
                }
            }

            #endregion
            //Mientras el evento actual tenga pruebas
            if (numDePrueba < eventoActual.transform.childCount)
            {   
                GameObject pruebaActual = eventoActual.transform.GetChild(numDePrueba).gameObject;
                print("Evento: " + eventoActual.transform.GetSiblingIndex());
                print("Prueba: " + pruebaActual.transform.GetSiblingIndex());
                print("Total de pruebas: " + eventoActual.transform.childCount);
                print("-------------------");
                // Si es la primera prueba solo lo muestra
                if (numDePrueba == 0)
                {
                    //List<time>[0].start() <----- Aqui solo empiza la primera prueba
                    pruebaActual.SetActive(true);
                } 
                else // Oculta la prueba anterior y muestra la siguiente
                {
                    // List<time>[numDePrueba - 1].stop  <------------ Para la prueba anterior
                    // List<time>[numDePrueba].start    <----------- comienza la sig prueba

                    eventoActual.transform.GetChild(numDePrueba - 1).gameObject.SetActive(false);
                    pruebaActual.SetActive(true);
                }
                //numDePrueba = numDePrueba + 1;

                if(numDePrueba >= eventoActual.transform.childCount){
                    pruebaActual.SetActive(false);
                }
            }else{ // Si ya no tiene pruebas el evento
                if (numDePruebaSeleccionada != -1) //Termina si hay una seleccionada
                {
                    terminar=true;
                }
                else{ // Pasa al siguiente evento y reinicia el numDePrueba
                    numDeEvento = numDeEvento + 1;
                    print("numero de evento siguiente evento: " + numDeEvento);
                    numDePrueba = 0;
                }
            }
        }
        //Si se acaba los eventos o se termina
        if(numDeEvento == 14 && numDePrueba == 25 || terminar){
            GameObject ocutarSiguiente = GameObject.Find("Canvas/Interfaz/Basica/boton_Siguiente");
            ocutarSiguiente.SetActive(false);
            print("Termino los eventos");
        }
    }

    public void boton_Siguiente(){
        numDePrueba = numDePrueba + 1;
    }

    void Update(){
        if(pruebaAnterior != numDePrueba){
            pruebaAnterior = numDePrueba;
            recorerEventos();
        }
    }
}
