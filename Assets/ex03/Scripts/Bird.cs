using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static bool loose;
    public float score;
    
    public bool jumpin;
    private float lastJump;
    public float jumpDuration;
    public float jumpSpeed;

    public float fallSpeed;


    private Vector3 cacheVec;

    public Transform ground;
    
    void Update()
    {
        if (!loose)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpin = true;
                lastJump = Time.time;
            }

            if (jumpin)
            {
                if (lastJump + jumpDuration < Time.time)
                    jumpin = false;
                transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
            }
            else
                transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);

            if (transform.position.y <= ground.position.y)
                GameOver();
        }
    }

    public void GameOver()
    {
        loose = true;
        Debug.Log("Score: " + score + "\nTime: " + Mathf.RoundToInt(Time.time) + "s");
    }
}