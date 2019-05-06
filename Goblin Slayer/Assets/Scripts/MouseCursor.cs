using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseCursor : MonoBehaviour {
    private SpriteRenderer rend;
    public Sprite clickDerecho;
    public Sprite clickIzquierdo;
    public Sprite Normal;
   
	// Use this for initialization
	void Start () {
        
       
        rend = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update() {
       
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPos;


            if (Input.GetMouseButtonDown(0))
            {
            Cursor.visible = false;

            rend.sprite = clickIzquierdo;



            }
            else if (Input.GetMouseButtonDown(1))
        {
            Cursor.visible = false;


            rend.sprite = clickDerecho;
            }
            else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
            Cursor.visible = true;
                rend.sprite = Normal;


            }


        
    }
          
    
}
