using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    static float speed = 5;

    public bool passed;

    //screen limits
    public Transform leftLimit;
    public Transform rightLimit;

    //pipe borders
    public Transform leftBorder;
    public Transform rightBorder;
    public Transform topBorder;
    public Transform bottomBorder;

    public Bird bird;

    void Update()
    {
        if (!Bird.loose)
        {
            MovePipe();

            Vector3 birdPos = bird.transform.position;
            if (!passed)
                CheckCollisions(birdPos);
        }
    }

    private void CheckCollisions(Vector3 birdPos)
    {
        //check pipe horizontal hit
        if (birdPos.x > leftBorder.position.x && birdPos.x < rightBorder.position.x)
        {
            //check verticalPipeHit
            if (birdPos.y > topBorder.position.y || birdPos.y < bottomBorder.position.y)
                bird.GameOver();
        }
        else if (birdPos.x > rightBorder.position.x)
        {
            passed = true;
            bird.score += 5;
        }
    }

    private void MovePipe()
    {
        if (transform.position.x < leftLimit.position.x)
        {
            transform.position = rightLimit.position;
            speed += .05f;
            passed = false;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}