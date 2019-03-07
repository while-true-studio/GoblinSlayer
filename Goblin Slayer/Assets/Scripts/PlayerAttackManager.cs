using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeleeAttacker))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Shield))]
public class PlayerAttackManager : MonoBehaviour
{
    public enum Mode { Melee, Mage };
    public Mode currentMode;// { set; get; }
    public enum IsPlayer { Player,Enemy};
    public IsPlayer currentPlayer;
    public Transform player;

    private MeleeAttacker meleeAttacker;
    private Shooter shooter;
    private Shield shield;
    private SkillHealing skillHealing;


	// Use this for initialization
	void Start () {
        currentMode = Mode.Melee;
        shooter = GetComponent<Shooter>();
        if (!shooter)
            Debug.Log("Dependence not found: shooter");
        if (!(meleeAttacker = GetComponent<MeleeAttacker>()))
            Debug.Log("Dependence not found: meleeAttacker");

        if (!(shield = GetComponent<Shield>()))
            Debug.Log("Dependence not found: shield");

        skillHealing = GetComponent<SkillHealing>();

    }

    private Vector2 GetLookAt()
    {
        if(currentPlayer == IsPlayer.Player)
        {
            return (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        }
        else
        {
            print(player.transform.position.normalized);
            return ((player.transform.position - transform.position).normalized);
        }
    }

    public void SwitchMode()
    {
        currentMode = (Mode)((int)++currentMode%2);
    }

    public void Attack()
    {
        switch(currentMode)
        {
            case Mode.Melee:
                meleeAttacker.MakeAttack(GetLookAt());
                break;
            case Mode.Mage:
                shooter.Shoot(GetLookAt());
                break;
        }
    }

    public void Defend()
    {
        switch (currentMode)
        {
            case Mode.Melee:
                shield.ActiveShield(true);
                break;
            case Mode.Mage:
                
                break;
        }
    }
    public void StopDefending()
    {
        switch (currentMode)
        {
            case Mode.Melee:
                shield.ActiveShield(false);
                break;
            case Mode.Mage:
                skillHealing.Healing();
                break;
        }
    }

}
