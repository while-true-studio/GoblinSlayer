using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start() { spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>(); }

    public void FlipSprite(Walker.WalkDirection dir,Walker.WalkingState currDir)
    {
        if (currDir!=(Walker.WalkingState)dir)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
