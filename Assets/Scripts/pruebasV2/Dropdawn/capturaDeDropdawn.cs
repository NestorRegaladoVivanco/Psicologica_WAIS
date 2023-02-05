using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class capturaDeDropdawn : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropDown; // Dropdawn para resetear la posicion de la respuesta del usuario.
    [SerializeField]
    private ControlDeEventosv2 controlDeEventos;
    
    public int respuestasCorrectasMatriz, // Informacion del resultado de las respuestas del evento Matriz
                respuestasCorrectasBalanza; // Informacion del resultado de las respuestas del evento Balanza

    public static int numDePruebasMatricez=28;
    public static int numDePruebasBalanzas=30;

    // Resultados de los eventos matriz y balanzas donde posteriormente se compara con los del usuario.
    private int[] resultadosMatricez = new int [numDePruebasMatricez];
    private int[] resultadosBalanzas = new int [numDePruebasBalanzas]; 

    private int pruebaAnterior;
    // Start is called before the first frame update
    void Start()
    {
        // Se inicializa los resultados del evento de matricez
        GameObject matricesAsigna = GameObject.Find("Eventos/Matrices");
        for(int asignar=0; asignar < numDePruebasMatricez ;asignar++)
        {
            resultadosMatricez[asignar] = (matricesAsigna.transform.GetChild(asignar).gameObject).GetComponent<respuestaDeDropdawn>().respuesta;
        }
        // Se inicializa los resultados del evento de balanzas
        GameObject balanzasAsigna = GameObject.Find("Eventos/Balanzas");
        for(int asignar=0; asignar < numDePruebasBalanzas ;asignar++)
        {
            resultadosBalanzas[asignar] = (balanzasAsigna.transform.GetChild(asignar).gameObject).GetComponent<respuestaDeDropdawn>().respuesta;
        }
        
        // Se inicializa las respuestas conseguidas del evento de:
        respuestasCorrectasMatriz=0; // Matricez
        respuestasCorrectasBalanza=0; // Balanzas
        pruebaAnterior=-1;
    }

    private void eventoBalanzas(int pruebaActual)
    {
        if(controlDeEventos.numDeEvento==11 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasBalanzas+1) // Espera al evento de Puzzle Visual
        {
            if(pruebaActual == 0){ // Anuncia el comienzo del evento
                print("Inicia Balanzas");
            }
            print(resultadosBalanzas[pruebaActual]+" = "+dropDown.value);
            if(resultadosBalanzas[pruebaActual] == dropDown.value) // Si es correcto, suma un punto y lo notifica
            {
                print("Prueba: "+(pruebaActual)+ " es Correcta" );
                respuestasCorrectasBalanza = respuestasCorrectasBalanza+1;
            }
            else // Si no es correcto, solo lo notifica
            {
                print("Prueba: "+(pruebaActual) + " es Incorrecta" );
            }
        }
    }

    private void eventoMatrices(int pruebaActual){
        if(controlDeEventos.numDeEvento==3 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasMatricez+1) // Espera al evento de Puzzle Visual
        {
            if(pruebaActual == 0){ // Anuncia el comienzo del evento
                print("Inicia Matrices");
            }
            print(resultadosMatricez[pruebaActual]+" = "+dropDown.value);
            if(resultadosMatricez[pruebaActual] == dropDown.value) // Si es correcto, suma un punto y lo notifica
            {
                print("Prueba: "+(pruebaActual)+ " es Correcta" );
                respuestasCorrectasMatriz = respuestasCorrectasMatriz+1;
            }
            else // Si no es correcto, solo lo notifica
            {
                print("Prueba: "+(pruebaActual) + " es Incorrecta" );
            }
        }
    }

    void Update(){
        if(pruebaAnterior!=controlDeEventos.numDePrueba){
            pruebaAnterior=controlDeEventos.numDePrueba;
            int pruebaActual = controlDeEventos.numDePrueba-1; // Control del orden de la prueba actual.
            eventoMatrices(pruebaActual);
            eventoBalanzas(pruebaActual);
            dropDown.value=0; // Se reinicia el estado del dropdawn a la primera posicion.
        }
    }

}
