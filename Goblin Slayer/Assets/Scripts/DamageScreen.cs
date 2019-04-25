using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScreen : MonoBehaviour
{
    public Renderer dMG;
    public bool gameOver { get; set; }
    public float timeRender;
    private float timer;

	void Start ()
    {
        dMG.material.SetColor("_Color",Color.clear);
	}
	
	void Update ()
    {
		if(gameOver)
        {
            timer += Time.deltaTime * timeRender;
            dMG.material.SetColor("_Color", Color.Lerp(Color.clear, Color.white, timer));
        }
        else
        {
            timer = 0.0f;
        }   
	}

}
