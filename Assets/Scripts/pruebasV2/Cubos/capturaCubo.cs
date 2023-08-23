using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class capturaCubo : MonoBehaviour
{
    [SerializeField]
    private ControlDeEventosv2 controlDeEventos;
    private respuestasCubos pruebaDelCubo;

    public int  puntuacionCubos;
    public static int numDePruebasCubos=15;
    private GameObject pruebasCubos;
        
    private int pruebaAnterior;

    // Start is called before the first frame update
    void Start()
    {
        puntuacionCubos=0;
        pruebaAnterior=-1;
        
        pruebasCubos = GameObject.Find("Eventos/Cubos");
    }

    private bool compararAngulos(Vector3 angulo1,Vector3 angulo2)
        {
            //print("compararAngulos");
            Vector3 diferencia = new Vector3();
            diferencia.x  = Mathf.Round(angulo1.x - angulo2.x);
            //print(diferencia.x);
            diferencia.y  = Mathf.Round(angulo1.y - angulo2.y);
            //print(diferencia.y);
            diferencia.z  = Mathf.Round(angulo1.z - angulo2.z);
            //print(diferencia.z);
            if(!(diferencia.x > -1f && diferencia.x < 1f)) return false;
            else if(!(diferencia.y > -1f && diferencia.y < 1f)) return false;
            else if(!(diferencia.z > -1f && diferencia.z < 1f)) return false;
            else return true;
        }

    private Vector3 vector3Positivo(Vector3 posicion)
        {
            Vector3 positivo = posicion;
            if(posicion.x <= -1f) positivo.x = 360f + posicion.x;
            if(posicion.y <= -1f) positivo.y = 360f + posicion.y;
            if(posicion.z <= -1f) positivo.z = 360f + posicion.z;
            return positivo;
        }

    private int estadoDeCubo( Vector3 posicion)
        {
            //print("posicion: "+posicion);
            Vector3 cubo = vector3Positivo(posicion);
            //print("cubo: "+cubo);
            //------------------------------------ Blanco abajo izquierda / Rojo arriba derecha
            if( compararAngulos(new Vector3(0f,0f,0f) , cubo) || 
                compararAngulos(new Vector3(0f,180f,90f) , cubo) ||
                compararAngulos(new Vector3(180f,0f,270f) , cubo))
                {
                    //print("Blanco abajo izquierda / Rojo arriba derecha"); 
                    return 1;
                }
            //------------------------------------ Blanco abajo / Rojo arriba
            else if(compararAngulos(new Vector3(0f,0f,45f) , cubo) || 
                    compararAngulos(new Vector3(180f,0f,255f) , cubo) ||
                    compararAngulos(new Vector3(0f,180f,45f) , cubo))
                {
                    //print("Blanco abajo / Rojo arriba "); 
                    return 2;
                }
            //------------------------------------ Blanco abajo derecha / Rojo arriba izquierda
            else if(compararAngulos(new Vector3(0f,0f,90f) , cubo) || 
                    compararAngulos(new Vector3(180f,0f,180f) , cubo) ||
                    compararAngulos(new Vector3(0f,180f,0f) , cubo))
                {
                    //print("Blanco abajo derecha / Rojo arriba izquierda"); 
                    return 3;
                }
            //------------------------------------ Blanco derecha / Rojo izquierda
            else if(compararAngulos(new Vector3(0f,0f,135f) , cubo) || 
                    compararAngulos(new Vector3(180f,0f,135f) , cubo) ||
                    compararAngulos(new Vector3(0f,180f,315f) , cubo)) 
                {
                    //print("Blanco derecha / Rojo izquierda"); 
                    return 4;
                }
            //------------------------------------ Blanco arriba derecha / Rojo abajo izquierda
            else if(compararAngulos(new Vector3(0f,0f,180f) , cubo) || 
                    compararAngulos(new Vector3(180f,0f,90f) , cubo) ||
                    compararAngulos(new Vector3(0f,180f,270f) , cubo))
                {
                    //print("Blanco arriba derecha / Rojo abajo izquierda"); 
                    return 5;
                }
            //------------------------------------ Blanco arriba / Rojo abajo
            else if(compararAngulos(new Vector3(0f,0f,225f) , cubo) || 
                    compararAngulos(new Vector3(180f,0f,45f) , cubo) ||
                    compararAngulos(new Vector3(0f,180f,225f) , cubo))
                {
                    //print("Blanco arriba / Rojo abajo"); 
                    return 6;
                }
            //------------------------------------ Blanco arriba izquierda / Rojo abajo derecha
            else if(compararAngulos(new Vector3(0f,0f,270f) , cubo) || 
                    compararAngulos(new Vector3(180f,0f,0f) , cubo) ||
                    compararAngulos(new Vector3(0f,180f,180f) , cubo))
                {
                    //print("Blanco arriba izquierda / Rojo abajo derecha"); 
                    return 7;
                }
            //------------------------------------ Blanco izquierda / Rojo derecha
            else if(compararAngulos(new Vector3(0f,0f,315f) , cubo) || 
                    compararAngulos(new Vector3(0f,180f,135f) , cubo) ||
                    compararAngulos(new Vector3(180f,0f,315f) , cubo))
                {
                    //print("Blanco izquierda / Rojo derecha"); 
                    return 8;
                }
            //------------------------------------ Blanco -
            else if(compararAngulos(new Vector3(0f,270f,0f),cubo) || 
                    compararAngulos(new Vector3(90f,0f,90f) , cubo) ||
                    compararAngulos(new Vector3(90f,0f,0f) , cubo) ||
                    compararAngulos(new Vector3(0f,90f,180f) , cubo) ||
                    compararAngulos(new Vector3(270f,0f,270f) , cubo) ||
                    compararAngulos(new Vector3(270f,0f,180f) , cubo) ||
                    compararAngulos(new Vector3(270f,0f,270f) , cubo) ||
                    compararAngulos(new Vector3(270f,180f,0f) , cubo) ||
                    compararAngulos(new Vector3(90f,270f,270f) , cubo) ||
                    compararAngulos(new Vector3(90f,270f,0f) , cubo) ||
                    compararAngulos(new Vector3(270f,270f,270f) , cubo) ||
                    compararAngulos(new Vector3(0f,90f,90f) , cubo) ||
                    compararAngulos(new Vector3(180f,270f,270f) , cubo) ||
                    compararAngulos(new Vector3(135f,270f,270f) , cubo) ||
                    compararAngulos(new Vector3(225f,0f,0f) , cubo) ||
                    compararAngulos(new Vector3(180f,270f,0f) , cubo) ||
                    compararAngulos(new Vector3(0f,270f,270f) , cubo)
                    )
                {
                    //print("Blanco -");
                    return 9;
                }
            //------------------------------------ Blanco |
            else if(compararAngulos(new Vector3(45f,270f,0f) , cubo) || 
                    compararAngulos(new Vector3(135f,270f,0f) , cubo) ||
                    compararAngulos(new Vector3(225f,270f,0f) , cubo) ||
                    compararAngulos(new Vector3(315f,270f,0f) , cubo) ||

                    compararAngulos(new Vector3(315f,270f,270f) , cubo) ||
                    compararAngulos(new Vector3(45f,270f,270f) , cubo) ||
                    compararAngulos(new Vector3(45f,90f,90f) , cubo) ||
                    compararAngulos(new Vector3(315f,90f,90f) , cubo) ||

                    compararAngulos(new Vector3(270f,270f,0f) , cubo) ||
                    compararAngulos(new Vector3(0f,270f,270f) , cubo) ||

                    compararAngulos(new Vector3(225f,270f,270f) , cubo) ||
                    compararAngulos(new Vector3(315f,270f,270f) , cubo) ||
                    compararAngulos(new Vector3(135f,270f,270f) , cubo) ||
                    compararAngulos(new Vector3(45f,270f,270f) , cubo))
                {
                    //print("Blanco |");
                    return 10;
                }
            //------------------------------------Rojo -
            else if(compararAngulos(new Vector3(270f,360f,0f) , cubo) ||  
                    compararAngulos(new Vector3(180f,270f,90f) , cubo) || 
                    compararAngulos(new Vector3(90f,360f,180f) , cubo) || 
                    compararAngulos(new Vector3(0f,270f,90f) , cubo) ||  

                    compararAngulos(new Vector3(0f,90f,0f) , cubo) ||    
                    compararAngulos(new Vector3(0f,270f,180f) , cubo) || 
                    compararAngulos(new Vector3(270f,0f,90f) , cubo) ||  
                    compararAngulos(new Vector3(90f,0f,270f) , cubo) ||  

                    compararAngulos(new Vector3(180f,90f,0f) , cubo) || 
                    compararAngulos(new Vector3(360f,90f,0f) , cubo) || 
                    compararAngulos(new Vector3(270f,90f,0f) , cubo) || 
                    compararAngulos(new Vector3(0f,90f,270f) , cubo) || 

                    compararAngulos(new Vector3(270f,0f,0f) , cubo) ||  
                    compararAngulos(new Vector3(0f,270f,90f) , cubo) || 
                    compararAngulos(new Vector3(90f,0f,180f) , cubo) || 
                    compararAngulos(new Vector3(90f,180f,0f) , cubo) || 

                    compararAngulos(new Vector3(90f,90f,0f) , cubo) ||
                    compararAngulos(new Vector3(360f,90f,270f) , cubo) ||
                    compararAngulos(new Vector3(270f,0f,360f) , cubo) ||
                    compararAngulos(new Vector3(450f,0f,270f) , cubo) ||
                    compararAngulos(new Vector3(90f,0f,270f) , cubo))
                {
                    //print("Rojo -");
                    return 11;
                }
            //------------------------------------ Rojo |
            else if(compararAngulos(new Vector3(45f,90f,0f) , cubo) || // 3
                    compararAngulos(new Vector3(315f,90f,0f) , cubo) || // 1 3 -
                    compararAngulos(new Vector3(135f,90f,0f) , cubo) || // 1 3
                    compararAngulos(new Vector3(225f,90f,0f) , cubo) || // 1 3 -
                    compararAngulos(new Vector3(405f,90f,0f) , cubo) || // 1

                    compararAngulos(new Vector3(315f,90f,270f) , cubo) || // 4 5 -
                    compararAngulos(new Vector3(45f,90f,270f) , cubo) ||  // 4  5 -
                    compararAngulos(new Vector3(45f,270f,90f) , cubo) ||  // 2 4 5
                    compararAngulos(new Vector3(315f,270f,90f) , cubo) || // 2 4 5 -
                    compararAngulos(new Vector3(135f,270f,90f) , cubo) || // 2
                    compararAngulos(new Vector3(225f,270f,90f) , cubo) || // 2 -

                    compararAngulos(new Vector3(225f,90f,270f) , cubo) ||
                    compararAngulos(new Vector3(355f,90f,0f) , cubo) ||
                    compararAngulos(new Vector3(45f,270f,180f) , cubo) ||
                    compararAngulos(new Vector3(315f,270f,180f) , cubo) ||
                    compararAngulos(new Vector3(45f,90f,360f) , cubo) ||
                    compararAngulos(new Vector3(315f,90f,360f) , cubo) ||
                    compararAngulos(new Vector3(315f,270f,270f) , cubo))
                {
                    //print("Rojo |");
                    return 12;
                }
            else
            {   
                //print("No coincide: "+cubo);
                return 0;
            }
        }

    public void eventoCubos(int pruebaActual)
    {
        if(controlDeEventos.numDeEvento==0 && controlDeEventos.numDePrueba>0 && controlDeEventos.numDePrueba<numDePruebasCubos+1) // Espera al evento de Puzzle Visual
        {
            //print("---------Usuario---------");
            var cubosDelUsuario = ((pruebasCubos.transform.GetChild(pruebaActual)).GetChild(1).gameObject);// Se mueve entre las pruebas de cubo
            GameObject[] cubosEnOrden = new GameObject [cubosDelUsuario.transform.childCount];// Extrae los cubos de cada prueba
            Vector3[] rotacicionCubosEnOrden = new Vector3 [cubosDelUsuario.transform.childCount];
            for(int i=0; i < cubosDelUsuario.transform.childCount; i++ )
            {
                cubosEnOrden[i] = (cubosDelUsuario.transform.GetChild(i).gameObject);
            }
            List<GameObject> cubosOrdenadosEnY = cubosEnOrden.ToList();
            List<GameObject> cubosOrdenadosEnX = new List<GameObject>();
            List<GameObject> cubosOrdenadosEnYX = new List<GameObject>();
            cubosOrdenadosEnY = cubosOrdenadosEnY.OrderByDescending(o => o.transform.position.y).ToList();

            #region Acomodo de cubos
            float altura = cubosOrdenadosEnY[0].transform.position.y;
            float desplazamientoPermitido = 35f;
            foreach (var item in cubosOrdenadosEnY)
            {
                // Separa las alturas con desplazamiento asignado
                //print(item.transform.position.y+ " >= "+ (altura - desplazamientoPermitido));
                if(item.transform.position.y >= altura - desplazamientoPermitido)
                {
                    //print("cubosOrdenadosEnX.Add(item);");
                    cubosOrdenadosEnX.Add(item);
                }
                else{ // Al ser demasiado deplazamiento en la altura, se hace "corte".
                    // Ordena la lista que se genero y luego procede a convinarlo con la final
                    //print("Clear;");
                    cubosOrdenadosEnX = cubosOrdenadosEnX.OrderBy(o => o.transform.position.x).ToList();
                    cubosOrdenadosEnYX.AddRange(cubosOrdenadosEnX);
                    // Limpia los datos anteriores y actualiza al altura, para al final agregar el nuevo dato.
                    cubosOrdenadosEnX.Clear();
                    altura = item.transform.position.y;
                    cubosOrdenadosEnX.Add(item);
                }
            }
            cubosOrdenadosEnX = cubosOrdenadosEnX.OrderBy(o => o.transform.position.x).ToList();
            cubosOrdenadosEnYX.AddRange(cubosOrdenadosEnX);
            for(int i=0; i < cubosDelUsuario.transform.childCount; i++ )
            {
                //print(cubosOrdenadosEnYX.Count);
                rotacicionCubosEnOrden[i] = cubosOrdenadosEnYX[i].transform.eulerAngles;

                //print("cubosOrdenadosEnYX: "+cubosOrdenadosEnYX[i].name);
                //print("cubosEnOrden"+cubosEnOrden[i].name);
                //estadoDeCubo(rotacicionCubosEnOrden[i]);
                //print("*****************");
            }
            #endregion

            #region Se compara los cubos del usuario con las respuestas de la prueba
            // Se extraen las respuestas de la prueba seleccionada
            var respuestas = (Vector3[])((pruebasCubos.transform.GetChild(pruebaActual).gameObject).GetComponent<respuestasCubos>().respuestas).Clone();
            
            //print("---------Comparacion-----------");
            int cubosPorPrueba = 0; // cuenta el numero de cubos correctos en una prueba.
            for(int i=0; i < respuestas.Length; i++)
            {
                if(estadoDeCubo(rotacicionCubosEnOrden[i]) == estadoDeCubo(respuestas[i]))
                {
                    //print("Correcto");
                    //print(estadoDeCubo(rotacicionCubosEnOrden[i])+" == "+estadoDeCubo(respuestas[i]));
                    //print((rotacicionCubosEnOrden[i])+" == "+(respuestas[i]));
                    //print("+-+-+-+");
                    cubosPorPrueba++;
                }
                else
                {
                    //print("Incorrecto");
                    //print("rotacicionCubosEnOrden "+rotacicionCubosEnOrden[i]);
                    //print("respuestas "+respuestas[i]);
                    //print(estadoDeCubo(rotacicionCubosEnOrden[i])+" != "+estadoDeCubo(respuestas[i]));
                    //print((rotacicionCubosEnOrden[i])+" != "+(respuestas[i]));
                    //print("-+-+-+-");
                }
                //print("+++++++++++++++++++++++++++++++");
            }

            if(cubosPorPrueba == respuestas.Length)
                {
                    print("Prueba "+pruebaActual+" Correcta");
                    puntuacionCubos++;
                }
            else{
                    print("Prueba "+pruebaActual+" Incorrecta");
                }
            #endregion
        }
    }

    // Update is called once per frame/*
    void Update()
    {
        if(pruebaAnterior!=controlDeEventos.numDePrueba){
            pruebaAnterior=controlDeEventos.numDePrueba;
            int pruebaActual = controlDeEventos.numDePrueba-1; // Control del orden de la prueba actual.
            //eventoCubos(pruebaActual);
            
        }
    }
}
