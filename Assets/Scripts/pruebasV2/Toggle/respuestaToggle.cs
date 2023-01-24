using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respuestaToggle : MonoBehaviour
{
    public bool[] respuestas;    

    public void setRespuestas(bool[] n_respuestas)
    {
        respuestas[0]=n_respuestas[0];
        respuestas[1]=n_respuestas[1];
        respuestas[2]=n_respuestas[2];
        respuestas[3]=n_respuestas[3];
        respuestas[4]=n_respuestas[4];
        respuestas[5]=n_respuestas[5];
    }

    public string getRespuestas()
    {
        return(respuestas[0]+","+respuestas[1]+","+respuestas[2]+","+respuestas[3]+","+respuestas[4]+","+respuestas[5]);
    }

    public respuestaToggle(respuestaToggle n_respuestasT)
    {
        respuestas[0]=n_respuestasT.respuestas[0];
        respuestas[1]=n_respuestasT.respuestas[1];
        respuestas[2]=n_respuestasT.respuestas[2];
        respuestas[3]=n_respuestasT.respuestas[3];
        respuestas[4]=n_respuestasT.respuestas[4];
        respuestas[5]=n_respuestasT.respuestas[5];
    }
}
