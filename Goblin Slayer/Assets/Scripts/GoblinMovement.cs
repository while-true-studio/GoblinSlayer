using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 2.5f;
    public bool isPlayer;
    
    private Vector2 directionMovement;
    private Transform target;
    private Rigidbody2D rb;
    private CapsuleCollider2D bodyCollider;
    private SpriteRenderer avatar;

    void Awake()
    {
        
    }

    void Start ()
    {
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        avatar = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	

	void Update ()
    {
        CheckEnemyPosition();
        transform.Translate(directionMovement*Time.deltaTime);
	}

    /// <summary>
    /// comprueba la posición del enemigo y asigna una dirección
    /// </summary>
    public void CheckEnemyPosition()
    {
        if(transform.position.x > target.position.x)
        {
            directionMovement = Vector2.left;
            avatar.flipX = false;
        }
        else
        {
            directionMovement = Vector2.right;
            avatar.flipX = true;

        }
    }


}
