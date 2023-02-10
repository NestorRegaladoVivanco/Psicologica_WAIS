using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AccionesBttn : MonoBehaviour
{
    public AudioSource audio;
    GameObject textMeshPro;
    public GameObject bttnAudio;

    void Start()
    {
        textMeshPro = GameObject.Find("Canvas/Interfaz/Pruebas/cuadroDeRespuesta");
    }

    public void playButton()
    {
        textMeshPro.SetActive(false);
        audio.Play();
        StartCoroutine(esperaAudio());
    }

    IEnumerator esperaAudio(){
        yield return new WaitForSeconds(audio.clip.length);
        textMeshPro.SetActive(true);
        bttnAudio.SetActive(false);
    }

}
