using UnityEngine;

public class CameraFreeMovement : MonoBehaviour
{
    public float velocity= 1.0f;

	void Update ()
    {
        /**/ if (Input.GetKey(KeyCode.UpArrow))    Move(Vector2.up);
        else if (Input.GetKey(KeyCode.DownArrow))  Move(Vector2.down);
        /**/ if (Input.GetKey(KeyCode.LeftArrow))  Move(Vector2.left);
        else if (Input.GetKey(KeyCode.RightArrow)) Move(Vector2.right);

    }

    void Move(Vector2 direction)
    {
        Vector3 position = transform.position;
        position.x += direction.x * velocity * Time.deltaTime;
        position.y += direction.y * velocity * Time.deltaTime;
        transform.position = position;
    }
}
