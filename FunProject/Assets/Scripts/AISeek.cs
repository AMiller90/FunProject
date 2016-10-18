using UnityEngine;
using System.Collections;

public class AISeek : MonoBehaviour
{
    private Vector3 Speed = new Vector3(5,5,0);
    private bool move = false;
    private Transform computer;
    private Transform ball;
    float currentTime;
	
    void Seek()
    {
        float previousTime = currentTime++;
        float deltaTime = currentTime - previousTime;
        if (computer == null)
        {
            computer = GameObject.FindGameObjectWithTag("computer").transform;
            if (ball == null)
                if (ball = GameObject.FindGameObjectWithTag("ball").transform)
                    if (computer.position != ball.position)
                    {
                        computer.position = new Vector3((Speed.x += ball.position.x), (Speed.y += ball.position.y), -10);
                        move = true;
                    }
                    else
                        move = false;
        }
    }

	void Start ()
    {

    }
	
	void Update ()
    {
        Seek();
	}
}
