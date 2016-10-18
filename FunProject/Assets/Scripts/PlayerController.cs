using UnityEngine;
using System.Collections;

public sealed class PlayerController : MonoBehaviour {


    private static PlayerController instance;

    public static PlayerController self
    {
        get
        {
            if (instance == null)
                instance = new PlayerController();
            return instance;
        }
    }
    [SerializeField]
    private Transform player1;
    [SerializeField]
    [Range(6.0f, 10.0f)]
    private float p1Speed;

    [SerializeField]
    private Transform player2;
    [SerializeField]
    [Range(6.0f,10.0f)]
    private float p2Speed;

    private Vector3 Up;
    private Vector3 Down;
    private Vector3 Right;
    private Vector3 Left;

    private Vector3 pos1;
    private Vector3 pos2;

    // Use this for initialization
    void Start ()
    {
        if (player1 == null)
            player1 = GameObject.FindGameObjectWithTag("Player1").transform;

        if (player2 == null)
            player2 = GameObject.FindGameObjectWithTag("Player2").transform;

        Up = new Vector3(0, 1, 0);
        Down = new Vector3(0, -1, 0);
        Right = new Vector3(-1, 0, 0);
        Left = new Vector3(1, 0, 0);

        pos1 = player1.position;
        pos2 = player2.position;

        Mathf.Clamp(p1Speed, 5, 10);
        Mathf.Clamp(p2Speed, 5, 10);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Player1Movement();
        Player2Movement();
    }

    private void Player1Movement()
    {
        player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player2.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            pos1.y = Mathf.Clamp(player1.position.y, 0.5f, 9.5f);
            pos1 += Up * Time.deltaTime * p1Speed;
            player1.position = pos1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos1.x = Mathf.Clamp(player1.position.x, -4.5f, 4.5f);
            pos1 += Left * Time.deltaTime * p1Speed;
            player1.position = pos1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos1.y = Mathf.Clamp(player1.position.y, 0.5f, 9.5f);
            pos1 += Down * Time.deltaTime * p1Speed;
            player1.position = pos1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos1.x = Mathf.Clamp(player1.position.x, -4.5f, 4.5f);
            pos1 += Right * Time.deltaTime * p1Speed;
            player1.position = pos1;
        }
    }

    private void Player2Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos2.y = Mathf.Clamp(player2.position.y, 0.5f, 9.5f);
            pos2 += Up * Time.deltaTime * p2Speed;
            player2.position = pos2;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos2.x = Mathf.Clamp(player2.position.x, -4.5f, 4.5f);
            pos2 += Left * Time.deltaTime * p2Speed;
            player2.position = pos2;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos2.y = Mathf.Clamp(player2.position.y, 0.5f, 9.5f);
            pos2 += Down * Time.deltaTime * p2Speed;
            player2.position = pos2;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos2.x = Mathf.Clamp(player2.position.x, -4.5f, 4.5f);
            pos2 += Right * Time.deltaTime * p2Speed;
            player2.position = pos2;
        }

    }
}
