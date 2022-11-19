using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeEventos : MonoBehaviour
{
    public int numDeEvento = 0, numDePrueba = 0;
    public int numDePruebaSeleccionada;
    private bool terminar=false;
    #region Nota de los eventos
    //numDeInterfaz si es 0 = cubos, 1 = cuadro de texto, 2 = opciones5, 3 = opciones6
    // numDeEvento-nombre - numDeInterfaz
    // 0-Cubos - 0
    // 1-Matrices - 2
    // 2-Vocabulario - 1 (respuesta descriptiva)?
    // 3-Aritmetica - 1
    // 4-Puzles Visuales - 3
    // 5-Balanzas - 2
    // 6-Figuras incompletas - 1 (apuntar y escribir)?
    #endregion

    void Start()
    {
        numDePruebaSeleccionada=ControlDeEscenas.eventoSeleccionado;
    }
    public void mostrarInterfazPrueba(int numDeInterfaz)
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

    private int acomodoDePruebaInterfaz(int numDePrueba)
    {
        if (numDePrueba == 0)
        {
            return 0;
        }
        else if (numDePrueba == 2 || numDePrueba == 3 || numDePrueba == 6)
        {
            return 1;
        }
        else if (numDePrueba == 1 || numDePrueba == 5)
        {
            return 2;
        }
        else if (numDePrueba == 4)
        {
            return 3;
        }
        else {
            return -1;
        }
    }

    public void recorerPruebas( )
    {
        GameObject eventos, prueba, problema;
        eventos = GameObject.Find("Eventos");
        if(numDePruebaSeleccionada != -1){
            numDeEvento = numDePruebaSeleccionada;
        }
        prueba = eventos.transform.GetChild(numDeEvento).gameObject;
        if (numDeEvento < eventos.transform.childCount ||terminar==false)
        {
            #region Asignacion de Interfas por prueba
            if (numDeEvento == 0 && numDePrueba == 0)
            {
                mostrarInterfazPrueba(numDeEvento);
            }
            else if (numDeEvento != 0 && numDePrueba == 0)
            {
                GameObject ultimaPrueba = eventos.transform.GetChild(numDeEvento - 1).gameObject;
                GameObject ultimoProblema = ultimaPrueba.transform.GetChild(ultimaPrueba.transform.childCount - 1).gameObject;
                ultimoProblema.SetActive(false);
                if (numDePruebaSeleccionada == -1)
                    mostrarInterfazPrueba(acomodoDePruebaInterfaz(numDeEvento - 1));
                mostrarInterfazPrueba(acomodoDePruebaInterfaz(numDeEvento));
            }
            #endregion
            if (numDePrueba < prueba.transform.childCount)
            {
                problema = prueba.transform.GetChild(numDePrueba).gameObject;
                print("prueba num: " + prueba.transform.GetSiblingIndex());
                print("problema num: " + problema.transform.GetSiblingIndex());
                print("prueba hijo: " + prueba.transform.childCount);
                print("-------------------");
                if (numDePrueba == 0)
                {
                    problema.SetActive(true);
                } else
                {
                    prueba.transform.GetChild(numDePrueba - 1).gameObject.SetActive(false);
                    problema.SetActive(true);
                }
                print("numero de prueba: " + numDePrueba);
                numDePrueba = numDePrueba + 1;
            }
            if (numDePrueba >= prueba.transform.childCount) {
                if (numDePruebaSeleccionada != -1) //Hay seleccionada
                {
                    terminar=true;
                }
                else{
                    print("numero de evento: " + numDeEvento);
                    numDeEvento = numDeEvento + 1;
                    numDePrueba = 0;
                }
                
            }
        }
        if (numDeEvento >= eventos.transform.childCount || terminar)
        {
            GameObject ocutarSiguiente = GameObject.Find("Canvas/Interfaz/Basica/boton_Siguiente");
            ocutarSiguiente.SetActive(false);
            print("Termino los eventos");
        }
    

    }

}