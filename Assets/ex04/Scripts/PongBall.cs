using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PongBall : MonoBehaviour
{
    public Transform leftBorder;
    public Transform rightBorder;
    public Transform topBorder;
    public Transform bottomBorder;

    public Player p1;
    public Player p2;

    //move related
    private Vector3 direction;
    public float speed = 5;

    bool launched;
    float timeToLaunch;
    const float LAUNCH_DELAY = 3;


    private Vector3 cacheVec;

    void Start()
    {
        StartLaunch();
    }

    void Update()
    {
        if (!launched)
        {
            if (Time.time > timeToLaunch)
                launched = true;
        }
        else
        {
            transform.Translate(direction * speed * Time.deltaTime);
            CheckWallHit();
            CheckPaddleHit();
            CheckOutside();
        }
    }

    void CheckWallHit()
    {
        cacheVec = transform.position;
        if (cacheVec.y > topBorder.position.y || cacheVec.y < bottomBorder.position.y)
        {
            cacheVec.y = Mathf.Clamp(cacheVec.y, bottomBorder.position.y, topBorder.position.y);
            transform.position = cacheVec;
            direction.y *= -1;
        }
    }

    void CheckPaddleHit()
    {
        cacheVec = transform.position;
        if (HitTestP1() || HitTestP2())
        {
            cacheVec.y = Mathf.Clamp(cacheVec.y, p1.transform.position.x, p2.transform.position.x);
            transform.position = cacheVec;
            direction.x *= -1;
            StartLaunch();
        }
    }

    bool HitTestP1()
    {
        return (direction.x < 0 && (cacheVec.x < p1.transform.position.x + p1.transform.localScale.x
                 && cacheVec.x > p1.transform.position.x - p1.transform.localScale.x)
                && (cacheVec.y < p1.transform.position.y + p1.transform.localScale.y / 2
                    && cacheVec.y > p1.transform.position.y - p1.transform.localScale.y / 2));
    }

    bool HitTestP2()
    {
        return (direction.x > 0 && (cacheVec.x < p2.transform.position.x + p2.transform.localScale.x
                && cacheVec.x > p2.transform.position.x - p2.transform.localScale.x)
                && (cacheVec.y < p2.transform.position.y + p2.transform.localScale.y / 2
                    && cacheVec.y > p2.transform.position.y - p2.transform.localScale.y / 2));
    }

    void ResetBall()
    {
        launched = false;
        cacheVec = Camera.main.transform.position;
        cacheVec.z = 0;
        transform.position = cacheVec;
        Debug.Log("Player 1: " + p1.score + " | Player 2: " + p2.score);
    }

    void CheckOutside()
    {
        cacheVec = transform.position;
        if (cacheVec.x < leftBorder.position.x)
        {
            p2.score += 1;
            ResetBall();
        }
        else if (cacheVec.x > rightBorder.position.x)
        {
            p1.score += 1;
            ResetBall();
        }
    }

    void StartLaunch()
    {
        direction = Random.Range(0, 2) == 1 ? Vector3.up : Vector3.down;
        direction += Random.Range(0, 2) == 1 ? Vector3.left : Vector3.right;

        timeToLaunch = Time.time + LAUNCH_DELAY;
    }
}