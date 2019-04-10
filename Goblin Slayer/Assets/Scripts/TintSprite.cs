using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class TintSprite : MonoBehaviour {


    private SpriteRenderer sprite;
    public float time;
    public Color color;
    private Color originalColor;
    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        Assert.IsNotNull(sprite);
        originalColor = sprite.color;
    }
    public void Tint()
    {
        sprite.color = color;
        Invoke("UnTint", time);
    }

    private void UnTint()
    {
        sprite.color = originalColor;
    }

}
