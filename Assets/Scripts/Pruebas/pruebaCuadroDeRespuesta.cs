using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pruebaCuadroDeRespuesta : MonoBehaviour
{
[SerializeField]
    private TextMeshProUGUI cuadroDeTexto;
    [SerializeField]
    private TMP_InputField cuadroInput;
    [SerializeField]
    public int respuestasConseguidaVocabulario,
                respuestasConseguidasAritmetica,
                respuestasConseguidasFigIncompleta;

    #region Respuestas de Vocabulario
    private string[]    resultadosVocabularioLibro, 
                        resultadosVocabularioAvion,
                        resultadosVocabularioCesta,
                        resultadosVocabularioGuante,
                        resultadosVocabularioManzana,
                        resultadosVocabularioDesayuno,
                        resultadosVocabularioCama,
                        resultadosVocabularioEspejo,
                        resultadosVocabularioSilencioso,
                        resultadosVocabularioGenerar,
                        resultadosVocabularioCompasion,
                        resultadosVocabularioRemordimiento,
                        resultadosVocabularioMeditar,
                        resultadosVocabularioConfiar,
                        resultadosVocabularioEsquivar,
                        resultadosVocabularioValiente,
                        resultadosVocabularioFortaleza,
                        resultadosVocabularioEvolucionar,
                        resultadosVocabularioDistincion,
                        resultadosVocabularioOpaco,
                        resultadosVocabularioPeculiar,
                        resultadosVocabularioContrastar,
                        resultadosVocabularioPagiar;

    #endregion                        
    private string[] resultadosAritmetica;

    #region Respuestas de Figuras Incompletas
    private string[]    resultadosFigIncomplePeine,
                        resultadosFigIncompletaMesa,
                        resultadosFigIncompletaCara,
                        resultadosFigIncompletaEspejo,
                        resultadosFigIncompletaGafas,
                        resultadosFigIncompletaPlaya,
                        resultadosFigIncompletaCuchillo,
                        resultadosFigIncompletaJarra,
                        resultadosFigIncompletaRosas,
                        resultadosFigIncompletaPastel,
                        resultadosFigIncompletaVaca,
                        resultadosFigIncompletaValla,
                        resultadosFigIncompletaArboles,
                        resultadosFigIncompletaTaquillas,
                        resultadosFigIncompletaKarate,
                        resultadosFigIncompletaNieve,
                        resultadosFigIncompletaPaseo,
                        resultadosFigIncompletaCharcos,
                        resultadosFigIncompletaZapatillas,
                        resultadosFigIncompletaTienda,
                        resultadosFigIncompletaCoche,
                        resultadosFigIncompletaEstanteria,
                        resultadosFigIncompletaCesta,
                        resultadosFigIncompletaAvion,
                        resultadosFigIncompletaCocina;

    #endregion
    private int pruebaActual;
    private bool trabajandoVocabulario,
                trabajandoAritmetica,
                trabajandoFigIncompleta;
    // Start is called before the first frame update
    void Start()
    {
        resultadosVocabularioLibro = new string []/* Libro */  {"libro"}; 
        resultadosVocabularioAvion = new string []/* Avion */{"avion","avión","avioneta","aeroplano"};
        resultadosVocabularioCesta = new string []/* Cesta */{"cesta","canasta"};
                /* ^^un punto solo^^ */ 
        resultadosVocabularioGuante= new string []/* Guante */{"prenda","cubren","cubre","progeten","manos","mano","frio"};
        resultadosVocabularioManzana = new string []/* Manzana */{"fruta","pieza","comida","arbol"}; 
        resultadosVocabularioDesayuno = new string []/* Desayuno */{"comida","alimento","primera","dia"};
        resultadosVocabularioCama = new string []/* Cama */{"mueble","dormir","colchon","mantas","sabanas","lugar","duermes","descanso","descansar"}; 
        resultadosVocabularioEspejo = new string []/* Espejo */{"reflejo","imagen","refleja","mirarse","verse","vidrio","cristal","objeto"};
        resultadosVocabularioSilencioso = new string []/* Silencioso */{"ruido","callado","estar","reservado","ser","calmado"}; 
        resultadosVocabularioGenerar = new string []/* Generar */{"procrear","engendrar","reproducir","crear","causar","algo","inventar","hacer","contruir"};
        resultadosVocabularioCompasion = new string []/* Compasion */{"piedad","sentimiento","pena","lastima","lástima","preocupacion","preocupación","perdon","compresión","compresion","consideracion","consideración","clemencia","empatia","empatía"}; 
        resultadosVocabularioRemordimiento = new string []/* Remordimiento */{"pena","dolor","arrepentir","arrepentimiento","arrepentirse","culpabilidad","hecho"};
        resultadosVocabularioMeditar = new string []/* Meditar */{"recapacitar","cavilar","reflexionar","pensar","algo","asimilar","comprender"}; 
        resultadosVocabularioConfiar = new string []/* Confiar */{"creer","fiarse","alguien","firmeza","seguridad","custodiar","contar","alguien","amigo","defraudar"};
        resultadosVocabularioEsquivar = new string []/* Esquivar */{"eludir","liberar","liberarse","evitar"}; 
        resultadosVocabularioValiente = new string []/* Valiente */{"persona","firmeza","valor","enfrentar","voluntad","determinacion","determinación","superacion","superación","atrevido","temerario","fuerte","resistente","afrontar"};
        resultadosVocabularioFortaleza = new string []/* Fortaleza */{"fuerza","vigor","resistencia","coraje","inexpugnable","fuerte","muralla","muros","persistencia","valor"}; 
        resultadosVocabularioEvolucionar = new string []/* Evolucionar */{"cambiar","crecer","progresar","transformarse","mejorar","avanzar"};
        resultadosVocabularioDistincion = new string []/* Distincion */{"elegancia","diferente","diferenciado","diferencia","premiar","homenajear","premio","comparar","separar","sobresale","especial"}; 
        resultadosVocabularioOpaco = new string []/* Opaco */{"atravesar","pasar","sombrio","luz","mediocre","contrario","transparente","translucido","translúcido","incomprensible"};
        resultadosVocabularioPeculiar = new string []/* Peculiar */{"diferente","corriente","ordinario","caracteristico","característico","distintivo","especial","original"}; 
        resultadosVocabularioContrastar = new string []/* Contrastar */{"comprobar","diferencia","opuesta","comparar","distinguirse","verificar"};
        resultadosVocabularioPagiar = new string []/* Plagiar */{"copiar","propia","robar","tuya","algo","utilizar","idea","ideas"};
        
        resultadosAritmetica = new string [] {
                "3","10","6","9","2"
                };
        resultadosFigIncomplePeine = new string []/* Peine */{"pua","seis","6","sexta","palito","púa"};
        resultadosFigIncompletaMesa = new string []/* Mesa */{"pata","pieza","madera"};
        resultadosFigIncompletaCara = new string []/* Cara */{"nariz","orificios","agujeros","cara","rostro"};
        resultadosFigIncompletaEspejo = new string []/* Espejo */{"cepillo","peine","reflejo","espejo","distinto"};
        resultadosFigIncompletaGafas = new string []/* Gafas */{"puente","gafas","pieza","nariz","entre","une"};
        resultadosFigIncompletaPlaya = new string []/* Playa */{"pasos","huellas","mujer","marcas","corriendo"};
        resultadosFigIncompletaCuchillo = new string []/* Cuchillo */{"cuchillo","dientes","sierra","ondas","dentada","hoja","filo","afiladas"};
        resultadosFigIncompletaJarra = new string []/* Jarra */{"chorro","agua","vertiendo","vertiendose","liquido"};
        resultadosFigIncompletaRosas = new string []/* Rosas */{"espinas","rosa","medio","segunda"};
        resultadosFigIncompletaPastel = new string []/* Pastel */{"trozo","cobertura","pastel","tarta"};
        resultadosFigIncompletaVaca = new string []/* Vaca */{"ranura","hendidura","grieta","pezuna","pezuña","casco","pie","dedos"};
        resultadosFigIncompletaValla = new string []/* Valla */{"bisagra","puerta","pieza","valla","metal","union"};
        resultadosFigIncompletaArboles = new string []/* Arboles */{"tronco","arbol"};
        resultadosFigIncompletaTaquillas = new string []/* Taquillas */{"rejilla","ventilacion","aire","respiradero"};
        resultadosFigIncompletaKarate = new string []/* Karate */{"cinturon","cinturón","hombre","cinta","lazo"};
        resultadosFigIncompletaNieve = new string []/* Nieve */{"nieve","troncos","pila"};
        resultadosFigIncompletaPaseo = new string []/* Paseo */{"sombra","mujer","ella"};
        resultadosFigIncompletaCharcos = new string []/* Charcos */{"gotas","salpicaduras","charco"};
        resultadosFigIncompletaZapatillas = new string []/* Zapatillas */{"ojal","agujero","orificio","anilla","cordon"};
        resultadosFigIncompletaTienda = new string []/* Tienda */{"asas","mochila","tirantes","sujeta","sujetar","correas"};
        resultadosFigIncompletaCoche = new string []/* Coche */{"neumatico","neumático","rueda","marcas"};
        resultadosFigIncompletaEstanteria = new string []/* Estanteria */{"estante","balda","pieza","madera","anaquel","sostenga"};
        resultadosFigIncompletaCesta = new string []/* Cesta */{"tira","linea","tejido","mimbre"};
        resultadosFigIncompletaAvion = new string []/* Avion */{"flaps","ala","derecha","alas","alerones","pieza","piezas"};
        resultadosFigIncompletaCocina = new string []/* Cocina */{"aro","fogon","metalica","alrededor","anilla"};

        
        
        pruebaActual=-1;
        respuestasConseguidaVocabulario=0;
        respuestasConseguidasAritmetica=0;
        respuestasConseguidasFigIncompleta=0;
        trabajandoVocabulario=false;
        trabajandoAritmetica=false;
        trabajandoFigIncompleta=false;
    }

    private int contadorDePalabras(string frase,string[] palabras)
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
    public void laRespuestaEsCorrecta()
    {
        GameObject vocabulario = GameObject.Find("Eventos/Vocabulario/01");
        GameObject aritmetica = GameObject.Find("Eventos/Aritmetica/01");
        GameObject figIncompleta = GameObject.Find("Eventos/FigurasIncompletas/01");
        int puntos=0;

        #region Vocabulario
        if(pruebaActual>=23 && trabajandoVocabulario)
        {
            trabajandoVocabulario=false;
            pruebaActual=-1;
        }
        else if(trabajandoVocabulario)
        {
            print("Se trabaja: "+pruebaActual);
            if(pruebaActual==0)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioLibro)>0 )
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==1)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioAvion)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==2)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioCesta)>0)
                {
                    puntos=puntos+1;
                }

            }
            if(pruebaActual==3)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioGuante)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioGuante)>0)
                {
                    puntos=puntos+1;
                }

            }
            if(pruebaActual==4)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioManzana)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioManzana)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==5)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioDesayuno)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioDesayuno)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==6)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioCama)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioCama)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==7)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioEspejo)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioEspejo)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==8)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioSilencioso)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioSilencioso)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==9)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioGenerar)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioGenerar)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==10)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioCompasion)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioCompasion)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==11)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioRemordimiento)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioRemordimiento)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==12)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioMeditar)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioMeditar)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==13)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioConfiar)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioConfiar)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==14)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioEsquivar)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioEsquivar)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==15)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioValiente)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioValiente)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==16)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioFortaleza)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioFortaleza)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==17)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioEvolucionar)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioEvolucionar)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==18)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioDistincion)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioDistincion)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==19)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioOpaco)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioOpaco)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==20)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioPeculiar)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioPeculiar)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==21)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioContrastar)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioContrastar)>0)
                {
                    puntos=puntos+1;
                }
            }
            if(pruebaActual==22)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioPagiar)>1)
                {
                    puntos=puntos+2;
                }
                else if(contadorDePalabras(cuadroDeTexto.text,resultadosVocabularioPagiar)>0)
                {
                    puntos=puntos+1;
                }
            }
            
            if(puntos==2)
            {
                print("Prueba: "+(pruebaActual+1)+ " es Correcta 2pts" );
                respuestasConseguidaVocabulario = respuestasConseguidaVocabulario+1;
            }
            else if(puntos==1)
            {
                print("Prueba: "+(pruebaActual+1)+ " es Correcta 1pts" );
                respuestasConseguidaVocabulario = respuestasConseguidaVocabulario+1;
            }
            else
            {
                print("Prueba: "+(pruebaActual+1) + " es Incorrecta" );
            }

            pruebaActual = pruebaActual+1;
        } 

        if (vocabulario.activeSelf == true)
        {
            print("Comienza prueba de Vocabulario" );
            trabajandoVocabulario = true;
            pruebaActual = pruebaActual+1;
        }
        #endregion

        #region Aritmetica
        if(pruebaActual!=-1 && pruebaActual!=5 && trabajandoAritmetica)
        {
            if(resultadosAritmetica[pruebaActual].Length==cuadroDeTexto.text.Length-1)
            {
                if((cuadroDeTexto.text).Contains(resultadosAritmetica[pruebaActual]))
                {
                    print("Prueba: "+(pruebaActual+1)+ " es Correcta" );
                    respuestasConseguidasAritmetica = respuestasConseguidasAritmetica+1;
                }
                else
                {
                    print("Prueba: "+(pruebaActual+1) + " es Incorrecta" );
                }
            }
            else
            {
                print("Prueba: "+(pruebaActual+1) + " es Incorrecta" );
            }
            pruebaActual = pruebaActual+1;
        }else if(pruebaActual>=5 && trabajandoAritmetica)
        {
            trabajandoAritmetica=false;
            pruebaActual=-1;
        }

        if (aritmetica.activeSelf == true)
        {
            print("Comienza prueba de Aritmetica" );
            trabajandoAritmetica= true;
            pruebaActual = pruebaActual+1;
        }
        #endregion
        
        #region Figuras Incompletas
        if(trabajandoFigIncompleta)
        {
            if(pruebaActual==0)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncomplePeine)>0)
                {
                    puntos++;
                }
                
            }
            if(pruebaActual==1)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaMesa)>0)
                {
                    puntos++;
                }
                
            }
            if(pruebaActual==2)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaCara)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==3)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaEspejo)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==4)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaGafas)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==5)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaPlaya)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==6)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaCuchillo)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==7)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaJarra)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==8)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaRosas)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==9)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaPastel)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==10)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaVaca)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==11)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaValla)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==12)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaArboles)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==13)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaTaquillas)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==14)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaKarate)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==15)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaNieve)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==16)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaPaseo)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==17)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaCharcos)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==18)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaZapatillas)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==19)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaTienda)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==20)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaCoche)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==21)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaEstanteria)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==22)
            {   
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaCesta)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==23)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaAvion)>0)
                {
                    puntos++;
                }
            }
            if(pruebaActual==24)
            {
                if(contadorDePalabras(cuadroDeTexto.text,resultadosFigIncompletaCocina)>0)
                {
                    puntos++;
                }
            }
            
            if(puntos==1)
            {
                print("Prueba: "+(pruebaActual)+ " es Correcta" );
                respuestasConseguidasFigIncompleta = respuestasConseguidasFigIncompleta+1;
            }
            else
            {
                print("Prueba: "+(pruebaActual) + " es Incorrecta" );
            }

            pruebaActual = pruebaActual+1;
        }else if(pruebaActual>=23 && trabajandoFigIncompleta)
        {
            trabajandoFigIncompleta=false;
            pruebaActual=-1;
        }

        if (figIncompleta.activeSelf == true)
        {
            print("Comienza prueba de Figuras Incompletas" );
            trabajandoFigIncompleta = true;
            pruebaActual = pruebaActual+1;
        }
        #endregion

        cuadroInput.text="";
    }
}
