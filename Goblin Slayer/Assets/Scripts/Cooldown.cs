/// <summary>
/// The Cooldown class utility.
/// </summary>
public class Cooldown {

    /// <summary>
    /// Constructs a new Cooldown instance with a given cooldown.
    /// </summary>
    /// <param name="cooldown">The amount of time in milliseconds the cooldown should last.</param>
    public Cooldown(uint cooldown)
    {
        this.cooldown = cooldown;
    }

    /// <summary>
    /// The amount of time in milliseconds the cooldown is applied for.
    /// </summary>
    public uint cooldown;

    /// <summary>
    /// When this Cooldown is reset back to a full state.
    /// </summary>
    private uint time = 0;

    /// <summary>
    /// Check whether or not this cooldown is limited.
    /// </summary>
    /// <param name="now">The current time in milliseconds, this usually is `Time.time`.</param>
    /// <returns>Whether or not this is still on cooldown.</returns>
    public bool Limited(uint now)
    {
        if (now < time) return true;
        ResetTime(now);
        return false;
    }

    /// <summary>
    /// Sets the internal time to the current timestamp plus the cooldown.
    /// </summary>
    /// <param name="now">The current time in milliseconds.</param>
	private void ResetTime(uint now)
    {
        time = now + cooldown;
    }
}
