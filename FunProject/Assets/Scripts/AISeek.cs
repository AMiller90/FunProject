using UnityEngine;
using System.Collections;

public class AISeek : MonoBehaviour
{    
    private Transform ball;
    float currentTime;
    
    void Start ()
    {
        if (ball == null)
            ball = GameObject.FindGameObjectWithTag("ball").transform;
    }
	
	void Update ()
    {

        float previousTime = currentTime++;
        float deltaTime = currentTime - previousTime;
        gameObject.transform.position = new Vector3(ball.position.x / 1.175f, ball.position.y / 1.175f, -14.5f);
    }
}