using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Shooter_AI : MonoBehaviour, IAttacker_AI
{
    private SpriteRenderer spriteRenderer;
    private Shooter shooter;

    private void Start()
    {
        shooter = GetComponent<Shooter>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Attack(Transform target)
    {
        var position = target.position;
        shooter.Shoot(new Vector2((transform.position - position).x < 0 ? 0.5f : -0.5f, 0.5f));
        FlipCast(position);
    }

    /// <summary>
    /// flip when attack in another direction
    /// </summary>
    /// <param name="direction"></param>
    private void FlipCast(Vector2 direction)
    {
        spriteRenderer.flipX = transform.position.x > direction.x;
    }
}