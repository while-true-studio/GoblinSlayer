using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeleeAttacker))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Shield))]
[RequireComponent(typeof(Jumper))]

public class PlayerAttackManager : MonoBehaviour
{
    public enum Mode { Melee, Mage };
    public Mode currentMode;// { set; get; }
    public enum IsPlayer { Player, Enemy };
    public IsPlayer currentPlayer;
    public Transform player;


    private IncreaseAttack inc;
    private MeleeAttacker meleeAttacker;
    private Shooter shooter;
    private Shield shield;
    private SkillHealing skillHealing;
    private SkillJumper skillJumper;
    public AnimatorControllerParameter warriorController;
    public AnimatorControllerParameter mageController;
    private Jumper jumper;
    public Animator aura;
    private AttackSounds sounds;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        inc = GetComponent<IncreaseAttack>();
        shooter = GetComponent<Shooter>();
        if (!shooter)
            Debug.Log("Dependence not found: shooter");
        if (!(meleeAttacker = GetComponent<MeleeAttacker>()))
            Debug.Log("Dependence not found: meleeAttacker");

        if (!(shield = GetComponent<Shield>()))
            Debug.Log("Dependence not found: shield");

        skillHealing = GetComponent<SkillHealing>();
        skillJumper = GetComponent<SkillJumper>();
        jumper = GetComponent<Jumper>();
        sounds = GetComponentInChildren<AttackSounds>();
        animator = transform.GetChild(1).GetComponent<Animator>();
    }
    public int GetMode()
    {
        return (int)currentMode;
    }
    public Vector2 GetLookAt()
    {
        Vector3 aux = currentPlayer == IsPlayer.Player
            ? Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position
            : player.transform.position - transform.position;
        return new Vector2(aux.x, aux.y).normalized;
    }

    public void SwitchMode()
    {
        sounds.PlayEffect(sounds.changeMode);
        currentMode = (Mode)((int)++currentMode % 2);


        if (currentMode == Mode.Mage) { aura.gameObject.SetActive(true); }
        else aura.gameObject.SetActive(false);
    }

    public void Attack()
    {
        switch (currentMode)
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
                skillHealing.Healing(true);
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
                skillHealing.Healing(false);
                break;
        }
    }
    public void JumpController()
    {
        switch (currentMode)
        {
            case Mode.Mage:
                if (jumper.toes.onGound) jumper.Jump();
                else skillJumper.MakeADoubleJump(GetLookAt());
                break;
            case Mode.Melee:
                jumper.Jump();
                break;
        }
    }
    public void AttackControl( )
    {
        // Debug.Log("hola");
        switch (currentMode)
        {
            case Mode.Mage:
                inc.MageControl();
                break;
            case Mode.Melee:
                inc.MeleeControl();

                break;
        }

    }
    public void StopControl()
    {
        switch (currentMode)
        {
            case Mode.Mage:
                inc.MageStop();
                break;
            case Mode.Melee:
                inc.MeleeStop();

                break;
        }
    }
}




