using UnityEngine;

public class KillOnClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
        {

            RaycastHit2D[] hits =
                Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach (var hit in hits)
            {
                GoblinDead goblin = hit.collider.GetComponent<GoblinDead>();
                if (goblin != null)
                {
                    Debug.Log("Killing " + goblin.gameObject.name);
                  //  goblin.ForcefullKill();
                }
            }
        }
    }

}
