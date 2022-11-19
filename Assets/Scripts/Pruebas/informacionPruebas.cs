using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class informacionPruebas : MonoBehaviour
{
    public ControlDeEventos eventoActual;
    private GameObject burbujaDeTexto;
    private string[] instruccionesEventos;
    [SerializeField]
    private TextMeshProUGUI cuadroDeTextoInstrucciones;

    private void Start()
    {
        burbujaDeTexto = GameObject.Find("Canvas/Interfaz/Basica/burbujaDeInstrucciones");
        instruccionesEventos = new string []{
            
            /*Cubos*/"Imita la imagen de la derecha utilizando los cubos, moviendolos con el raton y utilizando las flechas para rotar el cubo asta conseguir que sean iguales.",
            /*Matrices*/"Selecciona una de las 5 opciones que concuerda con la imagen de arriba.",
            /*Vocabulario*/"Imagen: Escribe el objeto de se muestra. \nPalabra: Escribe la definicion palabra que se muestra.",
            /*Aritmetica*/"Escribe lo que se indica el problema.",
            /*PuzzlesVisuales*/"De las 6 opciones que se presenta, selecciona 3 para reconstruir el puzle presentado.",
            /*Balanzas*/"Selecciona entre las 5 opciones la pesa faltante para equilibrar los platillos.",
            /*FigurasIncompletas*/"Escrible que es lo que le falta a la imagen."
        };
    }
    public void leerInstruccionDelEvento()
    {
         if (burbujaDeTexto.activeSelf == false)
        {
            burbujaDeTexto.SetActive(true);
            cuadroDeTextoInstrucciones.text = instruccionesEventos[eventoActual.numDeEvento];
        }
        else
        {
            burbujaDeTexto.SetActive(false);
        }
    }

}
