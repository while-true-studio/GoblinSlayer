using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelSelector : MonoBehaviour
{

    public KeyCode next = KeyCode.D;
    public KeyCode previous = KeyCode.A;
    public KeyCode enter = KeyCode.Return;

    public Transform[] levelsPositions;

    public ActivateLevels activateLevels;
   
    public AudioClip enterInLevelAudioClip;

    public HUD hud;


    public float iconVelocity;
    public bool allLevelsUnlocked = false;

    public int currentLevelIndex = 0;
    public int CurrentLevelIndex
    {
        get { return currentLevelIndex; }
        set { currentLevelIndex = (value % GameManager.GetLevelsCount()); }
    }
    public int NextLevelIndex()
    {
        return (currentLevelIndex + 1) % GameManager.GetLevelsCount();
    }
    public int PreviousLevelIndex()
    {
        return (currentLevelIndex + GameManager.GetLevelsCount() - 1) % GameManager.GetLevelsCount();
    }

    private bool moving = false;
    private SoundEffectsMenu soundEffects;
    private PlayerInfo.Level[] levelsInfo = null;
    private void Start()
    {
        CurrentLevelIndex = 0;
        soundEffects = Camera.main.GetComponent<SoundEffectsMenu>();
        levelsInfo = PlayerInfoManager.GetCurrentPlayerInfo().Levels;
        Assert.IsNotNull(levelsInfo, "Error: Couldn't find the levelsInfo in LevelSelector\n<color=yellow>Tip: is PlayerInfoManager initialized?(Have you used/created GameManager?)</color>");

        int index = 0;
        for (int i = 1; i< levelsInfo.Length; i++)
            if(levelsInfo[i].unlocked)
                activateLevels.FastActiveSprite(index++);

        hud.UpdateHUD();
    }

    private void Update()
    {
        if (moving) return;

        if (Input.GetKeyDown(previous)  && (levelsInfo[PreviousLevelIndex()].unlocked || allLevelsUnlocked))
        {
            CurrentLevelIndex = PreviousLevelIndex();
            MoveIcon();
        }
        else if (Input.GetKeyDown(next) && (levelsInfo[NextLevelIndex()].unlocked     || allLevelsUnlocked))
        {
            CurrentLevelIndex = NextLevelIndex();
            MoveIcon();
        }
        else if (Input.GetKeyDown(enter))
        {
            soundEffects.PlayEffect(enterInLevelAudioClip);
            if (levelsInfo[currentLevelIndex].unlocked)
                GameManager.ChangeScene(GameManager.LevelIndexToScene(CurrentLevelIndex));
        }
    }

    private void MoveIcon()
    {
        StartCoroutine(Move(transform, levelsPositions[CurrentLevelIndex]));
    }

    private IEnumerator Move(Transform from, Transform to)
    {
        moving = true;
        soundEffects.PlayWalkSound();

        while (Vector3.Distance(from.position, to.position) > 0.1)
        {
            Vector3 pos = from.position;
            Vector3 dir = (to.position - from.position).normalized;
            pos += dir * iconVelocity * Time.deltaTime;
            from.position = pos;
            yield return null;
        }
        from.position = to.position;
        moving = false;
        hud.UpdateHUD();
    }

}