using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseCursor : MonoBehaviour {
    public int tamCursor = 32;
    public Texture2D clickDerecho, clickIzquierdo, normal;
    private Texture2D cursoractive;
    public Texture2D ataquemago, defensamago, ataqueguerrero, defensaguerrero,normalmago,normalguerrero;
    void Start()
    {
        Cursor.visible = false;
        cursoractive = normal;
       
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            cursoractive = clickDerecho;
        }
      else if (Input.GetMouseButtonDown(0))
        {
            cursoractive = clickIzquierdo;
           
            
        }
        else if(Input.GetMouseButtonUp(1)||Input.GetMouseButtonUp(0))
        {
            cursoractive = normal;
        }
    }
  public  void ChangueCursor(int modo)
    {


        if (modo == 0)
        {
            clickIzquierdo = ataqueguerrero;
            clickDerecho = defensaguerrero;
            normal = normalguerrero;
        }
        else
        {
            clickIzquierdo = ataquemago;
            clickDerecho = defensamago;
            normal = normalmago;
        }
        
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, tamCursor, tamCursor), cursoractive);
    }



}
