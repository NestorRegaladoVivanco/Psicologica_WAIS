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

    #region variables de puntuacion
    public int  puntuacionSemejanzas,   // Informacion del resultado de las respuestas del evento Semejanzas
                puntuacionDigitos,  // Informacion del resultado de las respuestas del evento Digitos
                puntuacionVocabulario, // Informacion del resultado de las respuestas del evento Vocabulario
                puntuacionAritmetica, // Informacion del resultado de las respuestas del evento Aritmetica
                puntuacionInformacion,  // Informacion del resultado de las respuestas del evento Informacion
                puntuacionLetrasNumeros,    // Informacion del resultado de las respuestas del evento Letras y Numeros
                puntuacionComprension,  // Informacion del resultado de las respuestas del evento Comprension
                puntuacionFigIncompleta; // Informacion del resultado de las respuestas del evento FigIncompleta
    #endregion
    #region variables de numDePruebas
    public static int numDePruebasSemejanzas=18; // ---
    public static int numDePruebasDigitos=48;
    public static int numDePruebasVocabulario=23;
    public static int numDePruebasAritmetica=22;
    public static int numDePruebasInformacion=26;
    public static int numDePruebasLetrasNumeros=30;
    public static int numDePruebasComprension=18;
    public static int numDePruebasFigIncompleta=25;
    #endregion
    private int pruebaAnterior; // Mantiene el control en el update.
    private int terminaDigitos; // Oportunidades que tiene el usuario en la prueba de digitos
    private int pruebasErroneasConsecutivas;
    private int terminaLetrasNumeros; // Oportunidades que tiene el usuario en la prueba de Numeros y Letras
    #region variables de GameObject de pruebas
    private GameObject  pruebasSemejanzas,
                        pruebasDigitos,
                        pruebasVocabulario,
                        pruebasAritmetica,
                        pruebasInformacion,
                        pruebasLetrasNumeros,
                        pruebasComprension,
                        pruebasFigIncompleta;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region Se inicializa las respuestas conseguidas del evento:
        puntuacionSemejanzas=0;
        puntuacionDigitos=0;
        puntuacionVocabulario=0;
        puntuacionAritmetica=0;
        puntuacionInformacion=0;
        puntuacionLetrasNumeros=0;
        puntuacionComprension=0;
        puntuacionFigIncompleta=0;
        #endregion
        // variable para mantener el control en el update
        pruebaAnterior=-1;
        terminaDigitos=0;
        pruebasErroneasConsecutivas=0;
        #region Se inicializa los gameobjet de los eventos:
        pruebasSemejanzas = GameObject.Find("Eventos/Semejanzas");
        pruebasDigitos = GameObject.Find("Eventos/Digitos");
        pruebasVocabulario = GameObject.Find("Eventos/Vocabulario");
        pruebasAritmetica = GameObject.Find("Eventos/Aritmetica");
        pruebasInformacion = GameObject.Find("Eventos/Informacion");
        pruebasLetrasNumeros = GameObject.Find("Eventos/LetrasNumeros");
        pruebasComprension = GameObject.Find("Eventos/Comprension");
        pruebasFigIncompleta = GameObject.Find("Eventos/FigurasIncompletas");
        #endregion
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

    private int contadorDePalabrasPuntuacion(string frase,string[] palabras) // Regresa el numero de palabras "Clave" que puso el usuario, comparando con el resultado.
    {
        
        for(int recorrePalabras=0;recorrePalabras<4;recorrePalabras++)
        {
            if(frase.Contains(palabras[recorrePalabras]))
            {
                return 2;
            }
        }
        for(int recorrePalabras=4;recorrePalabras<palabras.Length;recorrePalabras++)
        {
            if(frase.Contains(palabras[recorrePalabras]))
            {
                return 1;
            }
        }
        return 0;
    } 
    // ---Eventos----
    public void eventoSemejanzas(int pruebaActual)
    {
        if(controlDeEventos.numDeEvento==1 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasSemejanzas+1) // Espera al evento de Puzzle Visual
        {   
            // Se extraen las respuestas de la prueba seleccionada
            var respuestas = (string[])((pruebasSemejanzas.transform.GetChild(pruebaActual).gameObject).GetComponent<respuestasDeTextMeshPro>().resultado).Clone();
            if(pruebaActual == 0)
            { // Anuncia el comienzo del evento
                print("Inicia Semejanzas");
            }
                int cont = 0;
                cont = contadorDePalabrasPuntuacion(cuadroDeTexto.text,respuestas);
                puntuacionSemejanzas = puntuacionSemejanzas + cont;

                if(cont == 2)
                {
                    print("Sumas dos puntos");
                }else if(cont == 1)
                {
                    print("Sumas un punto");
                }else{
                    print("Insuficiente");
                }
            }
    }
    public void eventoDigitos(int pruebaActual){
        if(controlDeEventos.numDeEvento==2 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasDigitos+1) // Espera al evento de Puzzle Visual
        {
            // Se extraen las respuestas de la prueba seleccionada
            var respuestas = (string[])((pruebasDigitos.transform.GetChild(pruebaActual).gameObject).GetComponent<respuestasDeTextMeshPro>().resultado).Clone();
            if(pruebaActual == 0){ // Anuncia el comienzo del evento
                print("Inicia Digitos");
            }
            if(contadorDePalabras(cuadroDeTexto.text,respuestas)>0)
            {
                print("Sumas un punto");
                puntuacionDigitos++;
            }else{
                print("Insuficiente");
                terminaDigitos++;
            }

            
            if(terminaDigitos == 2){ //se termina los intentos de ese prueba y se pasa a la siguiente 
                pruebasDigitos.transform.GetChild(pruebaActual).gameObject.SetActive(false); // Se oculta la acutal de forma "manual"
                if(pruebaActual < 16) // Si es en la prueba de Digitos directos pasa a Digitos inversos
                {
                    print("Se termino la prueba de Digitos directos, por intentos");
                    controlDeEventos.numDePrueba = 16;
                }   
                else if( pruebaActual < 32 ) // Si es en la prueba de Digitos inversos pasa a Digitos crecientes
                {
                    print("Se termino la prueba de Digitos inversos, por intentos");
                    controlDeEventos.numDePrueba = 32;
                }
                else  // Si es en la prueba de Digitos crecientes se termina y pasa a
                {
                    print("Se termino la prueba de Digitos crecientes, por intentos");
                    controlDeEventos.numDePrueba = numDePruebasDigitos;
                }
                terminaDigitos = 0;
            }
            else if (pruebaActual % 2 != 0) // Cada numero par, se reinicia los intentos para no terminar
            {
                terminaDigitos = 0; 
            }
        }
    }
    public void eventoVocabulario(int pruebaActual)
    {
        if(controlDeEventos.numDeEvento==4 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasVocabulario+1) // Espera al evento de Puzzle Visual
        {
            // Se extraen las respuestas de la prueba seleccionada
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
    }
    public void eventoAritmetica(int pruebaActual){
        if(controlDeEventos.numDeEvento==5 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasAritmetica+1) // Espera al evento de Puzzle Visual
        {
            // Se extraen las respuestas de la prueba seleccionada
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
    }
    public void eventoInformacion(int pruebaActual){
        if(controlDeEventos.numDeEvento==8 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasInformacion+1) // Espera al evento de Informacion
        {
            // Se extraen las respuestas de la prueba seleccionada
            var respuestas = (string[])((pruebasInformacion.transform.GetChild(pruebaActual).gameObject).GetComponent<respuestasDeTextMeshPro>().resultado).Clone();
            if(pruebaActual == 0){ // Anuncia el comienzo del evento
                print("Inicia Informacion");
            }
            if(contadorDePalabras(cuadroDeTexto.text,respuestas)>0)
            {
                print("Sumas un punto");
                puntuacionInformacion++;
            }else{
                print("Insuficiente");
            }
        }
    }
    public void eventoLetrasNumeros(int pruebaActual)
    {
        
        if(controlDeEventos.numDeEvento==10 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasLetrasNumeros+1) // Espera al evento de Puzzle Visual
        {
            // Se extraen las respuestas de la prueba seleccionada
            var respuestas = (string[])((pruebasLetrasNumeros.transform.GetChild(pruebaActual).gameObject).GetComponent<respuestasDeTextMeshPro>().resultado).Clone();
            if(pruebaActual == 0){ // Anuncia el comienzo del evento
                print("Inicia Numeros y Letras");
            }
            if (pruebaActual % 3 == 0 && pruebaActual != 0) // Cada numero tres pruebas, se reinicia los intentos para no terminar
            {
                pruebasErroneasConsecutivas = 0; 
            }
            if(contadorDePalabras(cuadroDeTexto.text,respuestas)>0)
            {
                print("Sumas un punto");
                puntuacionLetrasNumeros++;
            }else{
                print("Insuficiente");
                pruebasErroneasConsecutivas++;
            }
            //Se termina los intentos de ese evento 
            if(pruebasErroneasConsecutivas == 3){ 
                pruebasLetrasNumeros.transform.GetChild(pruebaActual).gameObject.SetActive(false); // Se oculta la acutal de forma "manual"
                print("Se termino la prueba de Letras y numeros, por intentos");
                controlDeEventos.numDePrueba = numDePruebasLetrasNumeros;
                pruebasErroneasConsecutivas = 0; // Reinicia los valores para la siguiente prueba
            }
        }
    }
    public void eventoComprension(int pruebaActual)
    {
        if(controlDeEventos.numDeEvento==12 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasComprension+1) // Espera al evento de Puzzle Visual
        {   
            // Se extraen las respuestas de la prueba seleccionada
            var respuestas = (string[])((pruebasComprension.transform.GetChild(pruebaActual).gameObject).GetComponent<respuestasDeTextMeshPro>().resultado).Clone();
            if(pruebaActual == 0)
            { // Anuncia el comienzo del evento
                print("Inicia Comprension");
            }
            int cont = 0;
            cont = contadorDePalabrasPuntuacion(cuadroDeTexto.text,respuestas);
            puntuacionComprension = puntuacionComprension + cont;
            if(cont == 2)
            {
                print("Sumas dos puntos");
            }else if(cont == 1)
            {
                print("Sumas un punto");
                pruebasErroneasConsecutivas=0;
            }else{
                print("Insuficiente");
                pruebasErroneasConsecutivas++;
            }
            if(pruebasErroneasConsecutivas == 3){ 
                pruebasComprension.transform.GetChild(pruebaActual).gameObject.SetActive(false); // Se oculta la acutal de forma "manual"
                print("Se termino la prueba de Comprencion, por intentos");
                controlDeEventos.numDePrueba = numDePruebasComprension;
                pruebasErroneasConsecutivas = 0; // Reinicia los valores para la siguiente prueba
            }
        }
    }
    public void eventoFigIncompleta (int pruebaActual){
        if(controlDeEventos.numDeEvento==14 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasFigIncompleta+1) // Espera al evento de FigIncompleta
        {
            // Se extraen las respuestas de la prueba seleccionada
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
    }

    void Update(){
        if(pruebaAnterior!=controlDeEventos.numDePrueba){
            pruebaAnterior=controlDeEventos.numDePrueba;
            int pruebaActual = controlDeEventos.numDePrueba-1; // Control del orden de la prueba actual.
            eventoSemejanzas(pruebaActual);
            eventoDigitos(pruebaActual);
            eventoVocabulario(pruebaActual);
            eventoAritmetica(pruebaActual);
            eventoInformacion(pruebaActual);
            eventoLetrasNumeros(pruebaActual);
            eventoComprension(pruebaActual); 
            eventoFigIncompleta(pruebaActual);
            cuadroInput.text=""; // Reinicia el Input del usuario.
        }
    }
}
