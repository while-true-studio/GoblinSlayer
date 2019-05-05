using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageDoll : MonoBehaviour
{
    private Animator animator;

    public void Die()
    {
        //Destroy(gameObject);
    }

	void Start ()
    {
        if (CompareTag("Player"))
        {
            GameManager.instancia.ResetScene(4);
        }

	}
}
