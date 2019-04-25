using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageDoll : MonoBehaviour
{
    private Animator animator;

    public void Die()
    {
        Destroy(gameObject);

    }

	void Start ()
    {
        //provicional
        if (tag == "Player")
        {
            GameManager.instancia.ResetScene(0);
        }

        animator = GetComponent<Animator>();
        animator.SetTrigger("Die");
	}
    
	

}
