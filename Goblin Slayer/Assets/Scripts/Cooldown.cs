using UnityEngine;

/// <summary> 
/// The Cooldown class utility. 
/// </summary> 
public class Cooldown
{
    /// <summary> 
    /// Constructs a new Cooldown instance with a given cooldown. 
    /// </summary> 
    /// <param name="cooldown">The amount of time in seconds the cooldown should last.</param> 
    public Cooldown(float cooldown)
    {
        this.cooldown = cooldown;
    }

    /// <summary> 
    /// The amount of time in seconds the cooldown is applied for. 
    /// </summary> 
    public float cooldown;

    /// <summary> 
    /// When this Cooldown is reset back to a full state. 
    /// </summary> 
    private float time = 0;

    /// <summary> 
    /// Check whether or not this cooldown is limited. 
    /// </summary> 
    /// <param name="now">The current time in seconds, this usually is `Time.time`.</param> 
    /// <returns>Whether or not this is still on cooldown.</returns> 
    public bool CanUse()
    {
        if (Time.time < time) return false;
        ResetTime(Time.time);
        return true;
    }

    /// <summary> 
    /// Sets the internal time to the current timestamp plus the cooldown. 
    /// </summary> 
    /// <param name="now">The current time in seconds.</param> 
    private void ResetTime(float now)
    {
        time = now + cooldown;
    }
}