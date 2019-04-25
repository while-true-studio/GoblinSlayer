using UnityEngine;
using UnityEngine.Assertions;

public class Walker_FacingFront : Walker {

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        SetupDependences();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, "ERROR: Couldn't find component of type 'SpriteRenderer' in object \"" + gameObject.name + "\" or any of its childs");
    }
    public override void Walk(WalkDirection direction)
    {
        spriteRenderer.flipX = direction == WalkDirection.LEFT;
        base.Walk(direction);
    }

}
