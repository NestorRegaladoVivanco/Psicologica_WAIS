using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeEventosv2 : MonoBehaviour
{
    public int  numDeEvento,
                numDePrueba,
                numDePruebaSeleccionada;

    private bool terminar=false;

    #region Notas de los eventos
    /*
    numDeInterfaz 
        0 = cubos
        1 = cuadro de texto (textMesh Pro)
        2 = opciones5 (dropDown)
        3 = opciones6 (Toggle)
    */

    /*
    numDeEvento  -nombre             - numDeInterfaz
        0       -Cubos                  - 0
        1       -Matrices               - 2
        2       -Vocabulario            - 1 (respuesta descriptiva)?
        3       -Aritmetica             - 1
        4       -Puzles Visuales        - 3
        5       -Balanzas               - 2
        6       -Figuras incompletas    - 1 (apuntar y escribir)?
    */ 
    #endregion

    void Start()
    {//Se utiliza para hacer pruebas en un evento especifico o para cuando el usuario selecciona un evento.
        //Se captura la prueba selecciona de la pantalla del menu
        numDePruebaSeleccionada=ControlDeEscenas.eventoSeleccionado;
        //Si se selecciono uno, se le asigna al numDeEvento, sino pasa a ser 0
        if(numDePruebaSeleccionada!=-1){
            numDeEvento=numDePruebaSeleccionada;
            print("Prueba seleccionada: "+numDeEvento );
        }else{
            numDeEvento=0;
        }
        numDePrueba=0;
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
            case 2: case 3: case 6: // Interfaz cuadro de texto (TextMeshPro)
                numInterfaz =  1;
                break; 
            case 1:  case 5: // opciones de 5 (dropDown)
                numInterfaz =  2;
                break;
            case 4: // opciones de 6 (Toggle)
                numInterfaz =  3;
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
        GameObject  eventos = GameObject.Find("Eventos"),
                    eventoActual=eventos.transform.GetChild(numDeEvento).gameObject;

        // Mientras tenga eventos o aun no termine.
        if(numDeEvento < eventos.transform.childCount || terminar==false)
        {
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
                    pruebaActual.SetActive(true);
                } 
                else // Oculta la prueba anterior y muestra la siguiente
                {
                    eventoActual.transform.GetChild(numDePrueba - 1).gameObject.SetActive(false);
                    pruebaActual.SetActive(true);
                }
                numDePrueba = numDePrueba + 1;

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
        if(numDeEvento >= eventos.transform.childCount || terminar){
            GameObject ocutarSiguiente = GameObject.Find("Canvas/Interfaz/Basica/boton_Siguiente");
            ocutarSiguiente.SetActive(false);
            print("Termino los eventos");
        }
    }

}
