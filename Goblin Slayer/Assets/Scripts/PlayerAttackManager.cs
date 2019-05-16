﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeleeAttacker))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Shield))]
[RequireComponent(typeof(Jumper))]

public class PlayerAttackManager : MonoBehaviour
{
    public enum Mode { MELEE, MAGE };
    public Mode CurrentMode { get; set; }
    public Transform player;

    private MouseCursor cursor;
    private MeleeAttacker meleeAttacker;
    private Shooter shooter;
    private Shield shield;
    private SkillHealing skillHealing;
    private SkillJumper jumper;
    //public AnimatorControllerParameter warriorController;
    //public AnimatorControllerParameter mageController;
    public Animator aura;
    private AttackSounds sounds;
    //private Animator animator;

	// Use this for initialization
    private void Start ()
    {
        cursor = GetComponent<MouseCursor>();
        shooter = GetComponent<Shooter>();
        if (!shooter)
            Debug.Log("Dependence not found: shooter");
        if (!(meleeAttacker = GetComponent<MeleeAttacker>()))
            Debug.Log("Dependence not found: meleeAttacker");

        if (!(shield = GetComponent<Shield>()))
            Debug.Log("Dependence not found: shield");

        skillHealing = GetComponent<SkillHealing>();
        jumper = GetComponent<SkillJumper>();
        sounds = GetComponentInChildren<AttackSounds>();
        //animator = transform.GetChild(1).GetComponent<Animator>();
        cursor.ChangueCursor((int)CurrentMode);
    }
    public  int GetMode()
    {
        return (int)CurrentMode;
    }
    public Vector2 GetLookAt()
    {
        //Vector3 aux = currentPlayer == IsPlayer.Player
        //    ? Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position
        //    : player.transform.position - transform.position;
        Vector3 aux = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        return new Vector2(aux.x, aux.y).normalized;
    }

    public void SwitchMode()
    {
        sounds.PlayEffect(sounds.changeMode);
        CurrentMode = (Mode)((int)++CurrentMode % 2);

        cursor.ChangueCursor((int)CurrentMode);

        aura.gameObject.SetActive(CurrentMode == Mode.MAGE);
    }

    public void Attack()
    {
        switch(CurrentMode)
        {
            case Mode.MELEE:
                meleeAttacker.MakeAttack(GetLookAt());
                break;
            case Mode.MAGE:
                shooter.Shoot(GetLookAt());
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Defend()
    {
        switch (CurrentMode)
        {
            case Mode.MELEE:
                shield.ActiveShield(true);
                break;
            case Mode.MAGE:
                skillHealing.Heal();
               
                break;
        }
    }
    public void StopDefending()
    {
        switch (CurrentMode)
        {
            case Mode.MELEE:
                shield.ActiveShield(false);
                break;
            case Mode.MAGE:
                skillHealing.StopHealing();
                break;
        }
    }
    public void JumpController()
    {
        switch (CurrentMode)
        {
            case Mode.MAGE:
                if (jumper.toes.OnGround) jumper.Jump();
                else jumper.MakeADoubleJump(GetLookAt());
                break;
            case Mode.MELEE:
                jumper.Jump();
                break;
        }
    }


}
