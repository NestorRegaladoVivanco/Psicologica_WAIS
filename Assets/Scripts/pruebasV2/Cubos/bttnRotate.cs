using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bttnRotate : MonoBehaviour
{
    bool isSelected;
    Transform focus ,cuboAnterior;
    Camera cam;
    RaycastHit hit;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        isSelected=false;
        cam = Camera.main;
    }

    public void reiniciarPos()
    {
        if(isSelected)
        {
            //print("reiniciar posicion");
            focus.rotation =Quaternion.identity;
        }
        else
        {
            print("Selecciona un cubo");
        }
    }

    public void rotateLeft()
    {
        if(isSelected)
        {
            //print("rotateLeft");
            focus.Rotate(new Vector3(0f,45f,0f));
        }
        else
        {
            print("Selecciona un cubo");
        }
    }

    public void rotateRight()
    {
        if(isSelected)
        {
            //print("rotateRight");
            focus.Rotate(new Vector3(0f,-45f,0f));
        }
        else
        {
            print("Selecciona un cubo");
        }
    }

    public void rotateUp()
    {
        if(isSelected)
        {
            //print("rotateUp");
            focus.Rotate(new Vector3(45f,0f,0f));
        }
        else
        {
            print("Selecciona un cubo");
        }
    }

    public void rotateDown()
    {
        if(isSelected)
        {
            //print("rotateDown");
            focus.Rotate(new Vector3(-45f,0f,0f));
        }
        else
        {
            print("Selecciona un cubo");
        }
    }

    public void rotateGLeft()
    {
        if(isSelected)
        {
            //print("rotateGLeft");
            focus.Rotate(new Vector3(0f,0f,45f));
        }
        else
        {
            print("Selecciona un cubo");
        }
    }

    public void rotateGRight()
    {
        if(isSelected)
        {
            //print("rotateGRight");
            focus.Rotate(new Vector3(0f,0f,-45f));
        }
        else
        {
            print("Selecciona un cubo");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out hit))
            { 
                focus = hit.collider.transform;
                //print("Rotate Click = " + focus.name);
                if(isSelected && (cuboAnterior == focus))
                {
                    //isSelected = false;
                    //print("Rotate  = false");
                }
                else
                {
                    cuboAnterior = focus;
                    isSelected = true;
                    //print("Rotate  = true");
                }
            }
        }
    }
}
