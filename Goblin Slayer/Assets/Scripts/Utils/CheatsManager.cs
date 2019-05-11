using UnityEngine;
using UnityEngine.UI;



//# Cheats
//    Para usar los cheats necesitas hacerte con una distribución que los tenga habilitados.
//    Para activar/desactivar los cheats pulsar la tecla `F3`

//## Tabla de *cheats*
//    |:-----------------------:|:---------------------------------------------------------:|
//    |      Short-cut          |           Function                                        |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     LCtrl + I           |   Activa/Desactiva la invulnerabilidad del jugador        |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     LCtrl + M           |   Activa/Desactiva el gasto de mana del jugador           |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     LCtrl + Click Izq   |   Elimina el enemigo sobre el que se ha clickeado         |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     LCtrl + U           |   Bloquea/Desbloquea la cámara del jugador.               |
//    |                         |   Una vez desbloqueada se  puede mover con las flechas del|
//    |                         |   teclado                                                 |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     LCtrl + T           |   Teletrasporta al jugador a la posición del ratón        |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     LCtrl + N           |   Desbloquea todos los niveles (TODAVÍA NO IMPLEMENTADO)  |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     1                   |   Spawnea un goblin* Kamikaze* en la posición del ratón   |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     2                   |   Spawnea un goblin* Infantería* en la posición del ratón |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     3                   |   Spawnea un goblin* Arquero* en la posición del ratón    |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     4                   |   Spawnea un goblin* chaman* en la posición del ratón     |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     5                   |   Spawnea un goblin* Trasgo* en la posición del ratón     |
//    |:-----------------------:|:---------------------------------------------------------:|
//    |     6                   |   Spawnea un goblin* King* en la posición del ratón       |  
//    |:-----------------------:|:---------------------------------------------------------:|

public class CheatsManager : MonoBehaviour
{
    public bool cheatsEnabled;

    private GameObject player = null;
    private Health playerHealth = null;
    private Mana playerMana = null;
    private CameraMovementManager cameraMovementManager = null;
    private SpawnOnMouse spawnOnMouse = null;
    private Image cheatsEnabledImage = null;

    #region Singleton
    private static CheatsManager _self = null;
    private void Awake()
    {
        if (_self == null)
        {
            _self = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    #endregion

    private void Start()
    {
        if (cheatsEnabledImage == null)
            cheatsEnabledImage = GameObject.Find("Cheetos").GetComponent<Image>();
        if (cheatsEnabledImage != null)
            cheatsEnabledImage.enabled = cheatsEnabled;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (cheatsEnabled)
                DisableCheats();
            else EnableCheats();
        }

        if (!cheatsEnabled) return;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.I))
                TogglePlayerInvincibility();
            if (Input.GetKeyDown(KeyCode.M))
                TogglePlayerInfiniteMana();
            if (Input.GetMouseButtonDown(0))
                KillOnClick();
            if (Input.GetKeyDown(KeyCode.U))
                ToggleCameraMovement();
            if (Input.GetKeyDown(KeyCode.T))
                TeletrasportPlayer();
        }
    }

    private void EnableCheats()
    {
        cheatsEnabled = true;
        if (spawnOnMouse == null)
            spawnOnMouse = GetComponent<SpawnOnMouse>();
        if (cheatsEnabledImage == null)
            cheatsEnabledImage = GameObject.Find("Cheetos").GetComponent<Image>();
        spawnOnMouse.enabled = true;
        cheatsEnabledImage.enabled = true;
    }

    private void DisableCheats()
    {
        //disable all cheats
        cheatsEnabled = false;

        if (spawnOnMouse == null)
            spawnOnMouse = GetComponent<SpawnOnMouse>();

        if (cheatsEnabledImage == null)
            cheatsEnabledImage = GameObject.Find("Cheetos").GetComponent<Image>();
        if (cheatsEnabledImage != null)
            cheatsEnabledImage.enabled = false;
        spawnOnMouse.enabled = false;

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

    private void KillOnClick()
    {
        RaycastHit2D[] hits =
            Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        foreach (var hit in hits)
        {
            GoblinDead goblin = hit.collider.GetComponent<GoblinDead>();
            if (goblin != null)
            {
                Debug.Log("Killing " + goblin.gameObject.name);
                goblin.ForcefullKill();
            }
        }
    }

    private void ToggleCameraMovement()
    {
        if (cameraMovementManager == null)
            cameraMovementManager = Camera.main.gameObject.GetComponent<CameraMovementManager>();
        if (cameraMovementManager != null)
            cameraMovementManager.ToggleCameraMovement();
    }

    private void TeletrasportPlayer()
    {
        if (!PlayerExist()) return;

        Vector3 pos = player.transform.position;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.x = newPos.x;
        pos.y = newPos.y;
        player.transform.position = pos;
    }
}
