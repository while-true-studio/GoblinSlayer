using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class Walker : MonoBehaviour {

    public float velocity;
    private float velocityStart;
    public float distanceToWall;

    public WalkingState walkingState { get; private set; }
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerBaseSounds sounds;

    private void Start()
    {
        velocityStart = velocity;
        SetupDependences();
    }

    protected void SetupDependences()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sounds = GetComponentInChildren<PlayerBaseSounds>();
        Assert.IsNotNull(animator, "ERROR: Couldn't find component of type 'Animator' in object \"" + gameObject.name + "\" or any of its childs");
    }

    public enum WalkingState { STOP = 0, RIGHT = 1, LEFT = -1};
    public enum WalkDirection { RIGHT = WalkingState.RIGHT, LEFT = WalkingState.LEFT};


    /// <summary>
    /// Makes the gameObject move in the given direction
    /// </summary>
    /// <param name="state">The direction in wich the gameObject should move</param>
    public virtual void Walk(WalkDirection direction)
    {
        walkingState = (WalkingState)direction;
        if (HitsWall(direction))
            Stop();
        else rb.velocity = new Vector2((float)direction * velocity, rb.velocity.y);

        if (!sounds.IsPlayingSound() && GetComponentInChildren<Toes>().onGound) 
        PlayWallOrRunSound();


        CheckAnimator();
    }
    private void PlayWallOrRunSound()
    {
        if (Mathf.Abs(rb.velocity.x) == velocityStart && Mathf.Abs(rb.velocity.x) > 0.25f)
        {
            sounds.PlayEffect(sounds.Walk);
        }
        else if(Mathf.Abs(rb.velocity.x) > velocityStart)
        {
            sounds.PlayEffect(sounds.Run);
        }
    }

    public void Stop()
    {
        walkingState = WalkingState.STOP;
        rb.velocity = new Vector2(0, rb.velocity.y);
        sounds.StopSounds(true);
        animator.SetFloat("speedWalk", 0);
    }

    private void CheckAnimator()
    {
        animator.SetFloat("speedWalk", Mathf.Abs(rb.velocity.x));
    }
    private bool HitsWall(WalkDirection direction)
    {
        /* Uncomment for debug
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, new Vector2((float)direction, 0), distanceToWall);
        bool hited = false;
        foreach (var hit in hits)
            if (hit.collider.tag == "Blocks")
            {
                hited = true;
                break;
            }

        Debug.DrawLine(transform.position, transform.position + (new Vector3((float)direction, 0, 0) * distanceToWall), hited ? Color.green: Color.red);
        return hited;
        */
        Vector2 dir = new Vector2((float)direction, 0);
        Vector2 point = transform.position;
        RaycastHit2D[] hits = Physics2D.RaycastAll(point, dir, distanceToWall);
        foreach (var hit in hits) if (hit.collider.tag == "Blocks") return true;
        //Debug.DrawLine(point, point + (dir * distanceToWall), Color.red);
        point.y += 0.5f;
        //Debug.DrawLine(point, point + (dir * distanceToWall), Color.red);
        hits = Physics2D.RaycastAll(point, dir, distanceToWall);
        foreach (var hit in hits) if (hit.collider.tag == "Blocks") return true;
        point.y -= 1.0f;
        //Debug.DrawLine(point, point + (dir * distanceToWall), Color.red);
        hits = Physics2D.RaycastAll(point, dir, distanceToWall);
        foreach (var hit in hits) if (hit.collider.tag == "Blocks") return true;
        return false;
    }

    
}