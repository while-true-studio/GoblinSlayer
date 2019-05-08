using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsManager : MonoBehaviour
{
    private static CheatsManager _self = null;
    public bool cheatsEnabled;

    private GameObject player = null;
    private Health playerHealth = null;
    private Mana playerMana = null;
    private CameraManager cameraManager = null;
    private KillOnClick killOnClick = null;
    private SpawnOnMouse spawnOnMouse = null;

    private void Awake()
    {
        if (_self == null)
        {
            _self = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (cheatsEnabled)
                DisableCheats();
            else EnableCheats();
        }

        if (!cheatsEnabled) return;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(Input.GetKeyDown(KeyCode.I))
                TogglePlayerInvincibility();
            if(Input.GetKeyDown(KeyCode.M))
                TogglePlayerInfiniteMana();
        }

    }

    private void EnableCheats()
    {
        cheatsEnabled = true;
        //Enable all cheats
    }

    private void DisableCheats()
    {
        cheatsEnabled = false;
        //disable all cheats
    }
    /// <summary>
    /// Finds out if the player exist, if do it make sure <see cref="player"/> is initialized
    /// </summary>
    /// <returns>true if <see cref="player"/> points to the player, false other wise</returns>
    private bool PlayerExist()
    {
        if (player != null || (player = GameObject.Find("Player")) != null) return true;
        Debug.LogWarning("You're trying to use a cheat with Player and doesn't exist in this scene");
        return false;
    }

    private void TogglePlayerInvincibility()
    {
        if (!PlayerExist()) return;

        if (playerHealth == null)
            playerHealth = player.GetComponent<Health>();

        playerHealth.invincible = !playerHealth.invincible;

    }

    private void TogglePlayerInfiniteMana()
    {
        if (!PlayerExist()) return;
        if (playerMana == null)
            playerMana = player.GetComponent<Mana>();

        playerMana.infiniteMana = !playerMana.infiniteMana;
    }

}
