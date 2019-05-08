using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDead : MonoBehaviour, IDead
{
    private Rage playerRage;
    private Rigidbody2D rb;
    public int rageAmount = 2;
    public RageDoll rageDoll;
    private PlayerBaseSounds sounds;
    private Transform rageDollPool;

    private void Start()
    {
        rageDollPool = GameObject.Find(("RageDollPool")).transform;
        sounds = GetComponentInChildren<PlayerBaseSounds>();
        playerRage = GameObject.Find("Player").GetComponent<Rage>();
    }

    void IDead.OnDead()
    {
        sounds.PlayEffect(sounds.dead);
        GetComponent<GoblinState>().GoblinIsDead();
        GameManager.instancia.AddEnemy();
        playerRage.AddRage(rageAmount);
        Instantiate(rageDoll, transform.position, transform.rotation,rageDollPool);
        Destroy(gameObject);
    }
}
