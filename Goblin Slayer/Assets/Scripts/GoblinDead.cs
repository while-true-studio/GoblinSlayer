using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDead : MonoBehaviour, IDead
{
    private Rage playerRage;
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

    public void OnDead()
    {
        sounds.PlayEffect(sounds.dead);
        GetComponent<GoblinState>().GoblinIsDead();
        GameplayManager.OnEnemyDead();
        playerRage.AddRage(rageAmount);
        Instantiate(rageDoll, transform.position, transform.rotation,rageDollPool);
        Destroy(gameObject);
    }
}
