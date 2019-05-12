using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Mana))]
public class Caster : Shooter
{
    private Animator effectAnim;
    private Mana mana;
    //private SpriteRenderer spriteRenderer;
    private AttackSounds attackSounds;

    private void Awake()
    {
        Assert.AreEqual(projectile.GetType(), typeof(MagicProjectile), "ERROR: The projectile is not a 'MagicProjectile' in GameObject: " + gameObject.name);
    }
    private void Start()
    {
        //spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        attackSounds = GetComponentInChildren<AttackSounds>();
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
        if (CanShoot() && mana.UseMana(((MagicProjectile)projectile).manaCost))
            ShootWork(direction);
    }

    protected override void CastAnimator(Vector2 dir)
    {
        attackSounds.PlayEffect(attackSounds.cast);
        base.CastAnimator(dir);
        if(effectAnim)
            effectAnim.SetTrigger("Casting");
    }

}
