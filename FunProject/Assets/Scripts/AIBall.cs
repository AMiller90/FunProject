using UnityEngine;
using System.Collections;

public class AIBall : MonoBehaviour {

    private Transform player1;
    private Transform player2;
    // Use this for initialization
    void Start ()
    { 
        SpawnBall();

        if (player1 == null)
            player1 = GameObject.FindGameObjectWithTag("Player1").transform;

        if (player2 == null)
            player2 = GameObject.FindGameObjectWithTag("Player2").transform;

        //GetComponent<Rigidbody>().velocity += new Vector3(0, 0, -5);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -5), ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (transform.position.z > player1.position.z)
        {
            Debug.Log("Player2 Scored");
            SpawnBall();
        }

        if (transform.position.z < player2.position.z)
        {
            Debug.Log("Player1 Scored");
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        transform.position = new Vector3(0, 0.5f, Random.Range(-4, -6));
    }
}
