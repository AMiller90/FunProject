using UnityEngine;
using System.Collections;

public sealed class AIBall : MonoBehaviour {

    private static AIBall instance;

    public static AIBall self
    {
        get
        {
            if (instance == null)
                instance = new AIBall();
            return instance;
        }
    }

    private Rigidbody rb;
    private Rigidbody p1;
    private Rigidbody p2;

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

        rb = GetComponent<Rigidbody>();
        p1 = player1.GetComponent<Rigidbody>();
        p2 = player1.GetComponent<Rigidbody>();

        StartCoroutine(Pause());
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 currentVelocity = rb.velocity;
            SpawnBall();
            rb.velocity = new Vector3(0, 0, 0);
            StartCoroutine(ResetBall(currentVelocity));
        }

        Vector3 speed = rb.velocity.normalized * 10;

        rb.velocity = Vector3.Lerp(rb.velocity, speed, Time.deltaTime * 10);

        if (transform.position.z > player1.position.z)
        {
            Debug.Log("Player2 Scored");
            StartCoroutine(Pause());
        }

        if (transform.position.z < player2.position.z)
        {
            Debug.Log("Player1 Scored");
            StartCoroutine(Pause());
        }
    }

    private void SpawnBall()
    {
        transform.position = new Vector3(0, 0.5f, -5);
    }

    private IEnumerator Pause()
    {
        SpawnBall();

        rb.velocity = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(2);

        float z = Random.Range(-1, 2);

        if (z == 0)
            z = 1;

        rb.velocity = new Vector3(0, 0, 6 * z);
    }

    private IEnumerator ResetBall(Vector3 currentVelocity)
    {
        yield return new WaitForSeconds(2);
        float z = Random.Range(-1, 2);

        if (z == 0)
            z = 1;

        rb.velocity = new Vector3(0, 0, 6 * z);
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Player1")
        {
            if(p1.velocity.y > 0)
                rb.velocity = new Vector3(0, -6, -6);

            if (p1.velocity.x > 0)
                rb.velocity = new Vector3(-6, 0, -6);
        }

        if (hit.gameObject.tag == "Player2")
        {
            if (p2.velocity.y > 0)
                rb.velocity = new Vector3(0, 6, 6);

            if (p2.velocity.x > 0)
                rb.velocity = new Vector3(6, 0, 6);
        }
    }
}
