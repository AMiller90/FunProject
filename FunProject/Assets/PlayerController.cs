using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Transform player1;
    [SerializeField]
    private Transform player2;

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
    }
	
	// Update is called once per frame
	void Update ()
    {
        Player1Movement();
        Player2Movement();
    }

    private void Player1Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            pos1.y = Mathf.Clamp(player1.position.y, 0.5f, 9.5f);
            pos1 += Up * Time.deltaTime * 2.5f;
            player1.position = pos1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos1.x = Mathf.Clamp(player1.position.x, -4.5f, 4.5f);
            pos1 += Left * Time.deltaTime * 2.5f;
            player1.position = pos1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos1.y = Mathf.Clamp(player1.position.y, 0.5f, 9.5f);
            pos1 += Down * Time.deltaTime * 2.5f;
            player1.position = pos1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos1.x = Mathf.Clamp(player1.position.x, -4.5f, 4.5f);
            pos1 += Right * Time.deltaTime * 2.5f;
            player1.position = pos1;
        }
    }

    private void Player2Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos2.y = Mathf.Clamp(player2.position.y, 0.5f, 9.5f);
            pos2 += Up * Time.deltaTime * 2.5f;
            player2.position = pos2;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos2.x = Mathf.Clamp(player2.position.x, -4.5f, 4.5f);
            pos2 += Left * Time.deltaTime * 2.5f;
            player2.position = pos2;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos2.y = Mathf.Clamp(player2.position.y, 0.5f, 9.5f);
            pos2 += Down * Time.deltaTime * 2.5f;
            player2.position = pos2;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos2.x = Mathf.Clamp(player2.position.x, -4.5f, 4.5f);
            pos2 += Right * Time.deltaTime * 2.5f;
            player2.position = pos2;
        }

    }

}
