using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScreen : MonoBehaviour
{
    public GameObject dMG;
    public bool gameOver { get; set; }
    private Renderer dmgEffect;
    public float timeRender;
    private float timer;
	void Start ()
    {
        dmgEffect = dMG.GetComponent<Renderer>();
	}
	
	void Update ()
    {
		if(gameOver)
        {
            timer += Time.deltaTime * timeRender;
            //No sé como cojer el renderer de una imgen del canvas
            //dmgEffect.material.SetColor("_Color", Color.Lerp(Color.clear, Color.white, timer));
        }
	}
}
