using UnityEngine;
using System.Collections;

public class AIPaddle : MonoBehaviour
{    
    private Transform ball;
    
    void Start ()
    {
        if (ball == null)
            ball = GameObject.FindGameObjectWithTag("ball").transform;
    }
	
	void Update ()
    {
        gameObject.transform.position = new Vector3(ball.position.x / 1.16f, ball.position.y / 1.16f, -14.5f);
    }
}