using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pruebaConOpcionesDe5 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textoDropdown;
     [SerializeField]
    private TMP_Dropdown dropDown;

    [SerializeField]
    public int respuestasConseguidasMatriz,
                respuestasConseguidasBalanza;

    private int[] resultadosMatricez,resultadosBalanzas;
    private int pruebaActual;
    private bool trabajandoMatrices;
    private bool trabajandoBalanzas;
    // Start is called before the first frame update
    void Start()
    {
        resultadosMatricez = new int [] {   
                5,4,3,2,1,
                5,3,4,4,1,
                5,2,1,5,1,
                3,5,2,3,1,
                4,2,1,5,4,
                2,3,4 };
        resultadosBalanzas = new int [] {
                3,2,1,5,1,
                2,3,4,1,4,
                4,5,1,2,5, 
                3,1,4,1,3,
                3,2,2,2,5,
                3,5,1,2,4 };
        pruebaActual=-1;
        respuestasConseguidasMatriz=0;
        respuestasConseguidasBalanza=0;
        trabajandoMatrices=false;
        trabajandoBalanzas=false;
    }

    private int acomodarRespuesta(string respuesta)
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
        if(pruebaActual!=-1 && pruebaActual!=28 && trabajandoMatrices)
        {
            
            if(resultadosMatricez[pruebaActual] == acomodarRespuesta(textoDropdown.text))
            {
                print("Prueba: "+(pruebaActual-1)+ " es Correcta" );
                respuestasConseguidasMatriz = respuestasConseguidasMatriz+1;
            }
            else
            {
                print("Prueba: "+(pruebaActual-1) + " es Incorrecta" );
            }

            pruebaActual = pruebaActual+1;
        }else if(pruebaActual>=28 && trabajandoMatrices)
        {
            trabajandoMatrices=false;
            pruebaActual=-1;
        }

        if (matrices.activeSelf == true)
        {
            print("Comienza prueba de Matrices" );
            trabajandoMatrices = true;
            pruebaActual = pruebaActual+1;
        }
        #endregion

        #region Balanzas
        if ((balanzas.transform.GetChild(0).gameObject).activeSelf == true)
        if(pruebaActual!=-1 && pruebaActual!=30 && trabajandoBalanzas)
        {
            
            if(resultadosBalanzas[pruebaActual] == acomodarRespuesta(textoDropdown.text))
            {
                print("Prueba: "+(pruebaActual-2)+ " es Correcta" );
                respuestasConseguidasBalanza = respuestasConseguidasBalanza+1;
            }
            else
            {
                print("Prueba: "+(pruebaActual-2) + " es Incorrecta" );
            }

            pruebaActual = pruebaActual+1;
        }else if(pruebaActual>=30 && trabajandoBalanzas)
        {
            trabajandoBalanzas=false;
            pruebaActual=0;
        }

        if (balanzas.activeSelf == true)
        {
            print("Comienza prueba de Balanzas" );
            trabajandoBalanzas= true;
            pruebaActual = pruebaActual+1;
        }
        #endregion
        dropDown.value=0;
    }

}
