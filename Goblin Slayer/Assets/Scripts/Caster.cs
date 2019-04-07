using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Mana))]
public class Caster : Shooter
{
    private Animator effectAnim;
    private Mana mana;

    private void Awake()
    {
        Assert.AreEqual(projectile.GetType(), typeof(MagicProjectile), "ERROR: The projectile is not a 'MagicProjectile' in GameObject: " + gameObject.name);
    }
    private void Start()
    {
        Init();
    }
    protected override void Init()
    {
        base.Init();
        mana = GetComponent<Mana>();
        if (transform.childCount >= 2)
            effectAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    public override void Shoot(Vector2 direction)
    {
        if (mana.UseMana(((MagicProjectile)projectile).manaCost))
            base.Shoot(direction);
    }

    protected override void CastAnimator(Vector2 dir)
    {
        base.CastAnimator(dir);
        if(effectAnim)
            effectAnim.SetTrigger("Casting");

    }

}
