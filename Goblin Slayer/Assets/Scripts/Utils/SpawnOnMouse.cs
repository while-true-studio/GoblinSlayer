using UnityEngine;
/// <summary>
/// Debugging helper class
/// Spawns an enemy on the mouse position
/// Usage:
///     press a numeric key to spawn the enemy with that position on the list of the component at mouse position.
/// </summary>
public class SpawnOnMouse : MonoBehaviour
{
    //The list of enemies to spawn. Must be filled from the Editor
    public GameObject[] goblins;

    public void Update()
    {
        for (int i = (int) KeyCode.Alpha1, iterations = (int) KeyCode.Alpha1 + goblins.Length; i < iterations; i++)
            if (Input.GetKeyDown((KeyCode) i))
            {
                Vector2 rawWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 pos = new Vector3(rawWorldPoint.x, rawWorldPoint.y, 0);
                Instantiate(goblins[i - (int) KeyCode.Alpha1].gameObject, pos, Quaternion.identity, transform)
                    .SetActive(true);
            }
    }
}