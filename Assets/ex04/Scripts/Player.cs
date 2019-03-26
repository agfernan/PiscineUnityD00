using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode keyUp;
    public KeyCode keyDown;

    public Transform topBorder;
    public Transform bottomBorder;

    
    //movement related
    private Vector3 cacheVec;
    private int direction;
    public float speed;

    public int score;
    
    void Update()
    {
        SetDir();
        Move();
    }

    void SetDir()
    {
        bool upPressed = Input.GetKey(keyUp);
        bool downPressed = Input.GetKey(keyDown);

        Debug.Log(upPressed);
        Debug.Log(downPressed);

        if (!downPressed && upPressed)
            direction = 1;
        else if (!upPressed && downPressed)
            direction = -1;
        else
            direction = 0;
    }

    void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime * direction);

        float halfScale = transform.localScale.y / 2;

        cacheVec = transform.position;
        cacheVec.y = Mathf.Clamp(
            transform.position.y,
            bottomBorder.position.y + halfScale,
            topBorder.position.y - halfScale
        );
        transform.position = cacheVec;
    }
}