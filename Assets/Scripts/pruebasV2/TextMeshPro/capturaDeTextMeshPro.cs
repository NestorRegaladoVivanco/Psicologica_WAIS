using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class capturaDeTextMeshPro : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField cuadroInput;
    [SerializeField]
    private ControlDeEventosv2 controlDeEventos;
    [SerializeField]
    private TextMeshProUGUI cuadroDeTexto;

    public int puntuacionVocabulario, // Informacion del resultado de las respuestas del evento Vocabulario
                puntuacionAritmetica, // Informacion del resultado de las respuestas del evento Aritmetica
                puntuacionFigIncompleta; // Informacion del resultado de las respuestas del evento FigIncompleta

    public static int numDePruebasSemejanzas=18; // ---
    public static int numDePruebasDigitos=18;
    public static int numDePruebasVocabulario=23;
    public static int numDePruebasAritmetica=22;
    public static int numDePruebasInformacion=18;
    public static int numDePruebasLetrasNumeros=10;
    public static int numDePruebasComprension=18;
    public static int numDePruebasFigIncompleta=25;

    private GameObject  pruebasVocabulario,
                        pruebasAritmetica,
                        pruebasFigIncompleta;

    // Start is called before the first frame update
    void Start()
    {
        // Se inicializa las respuestas conseguidas del evento de:
        puntuacionVocabulario=0;
        puntuacionAritmetica=0;
        puntuacionFigIncompleta=0;

        pruebasVocabulario = GameObject.Find("Eventos/Vocabulario");
        pruebasAritmetica = GameObject.Find("Eventos/Aritmetica");
        pruebasFigIncompleta = GameObject.Find("Eventos/FigurasIncompletas");
    }

    private int contadorDePalabras(string frase,string[] palabras) // Regresa el numero de palabras "Clave" que puso el usuario, comparando con el resultado.
    {
        int contador=0;
        for(int recorrePalabras=0;recorrePalabras<palabras.Length;recorrePalabras++)
        {
            if(frase.Contains(palabras[recorrePalabras]))
            {
                contador++;
            }
        }
        return contador;
    } 

    public void resultadosDeTextMeshPro()
    {
        int pruebaActual = controlDeEventos.numDePrueba-2; // Control del orden de la prueba actual.
        
        #region Vocabulario
        if(controlDeEventos.numDeEvento==4 && controlDeEventos.numDePrueba>1 && controlDeEventos.numDePrueba<numDePruebasVocabulario+2) // Espera al evento de Puzzle Visual
        {
            var respuestas = (string[])((pruebasVocabulario.transform.GetChild(pruebaActual).gameObject).GetComponent<respuestasDeTextMeshPro>().resultado).Clone();
            if(pruebaActual == 0){ // Anuncia el comienzo del evento
                print("Inicia Vocabulario");
            }
            if(pruebaActual <= 2) // Las primeras 3 pruebas solo pueden valer un punto
            {
                if(contadorDePalabras(cuadroDeTexto.text,respuestas)>0)
                {
                    print("Sumas un punto");
                    puntuacionVocabulario++;
                }else{
                    print("Insuficiente");
                }
            }else{
                if(contadorDePalabras(cuadroDeTexto.text,respuestas)>1)
                {
                    print("Sumas dos puntos");
                    puntuacionVocabulario=puntuacionVocabulario+2;
                }else if(contadorDePalabras(cuadroDeTexto.text,respuestas)>0)
                {
                    print("Sumas un punto");
                    puntuacionVocabulario++;
                }else{
                    print("Insuficiente");
                }
            }
        }
        #endregion

        #region Aritmetica
        if(controlDeEventos.numDeEvento==5 && controlDeEventos.numDePrueba>1 && controlDeEventos.numDePrueba<numDePruebasAritmetica+2) // Espera al evento de Puzzle Visual
        {
            var respuestas = (string[])((pruebasAritmetica.transform.GetChild(pruebaActual).gameObject).GetComponent<respuestasDeTextMeshPro>().resultado).Clone();
            if(pruebaActual == 0){ // Anuncia el comienzo del evento
                print("Inicia Aritmetica");
            }
            if(contadorDePalabras(cuadroDeTexto.text,respuestas)>0)
            {
                print("Sumas un punto");
                puntuacionAritmetica++;
            }else{
                print("Insuficiente");
            }
        }
        #endregion

        #region FigIncompleta
        if(controlDeEventos.numDeEvento==14 && controlDeEventos.numDePrueba>1 && controlDeEventos.numDePrueba<numDePruebasFigIncompleta+2) // Espera al evento de FigIncompleta
        {
            var respuestas = (string[])((pruebasFigIncompleta.transform.GetChild(pruebaActual).gameObject).GetComponent<respuestasDeTextMeshPro>().resultado).Clone();
            if(pruebaActual == 0){ // Anuncia el comienzo del evento
                print("Inicia FigIncompleta");
            }
            if(contadorDePalabras(cuadroDeTexto.text,respuestas)>0)
            {
                print("Sumas un punto");
                puntuacionFigIncompleta++;
            }else{
                print("Insuficiente");
            }
        }
        #endregion
        
        cuadroInput.text=""; // Reinicia el Input del usuario.
    }


}
