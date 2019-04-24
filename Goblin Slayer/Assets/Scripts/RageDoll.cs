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
        animator = GetComponent<Animator>();
        animator.SetTrigger("Die");
	}
    
    public void ResetLvl()
    {

    }
	

}
