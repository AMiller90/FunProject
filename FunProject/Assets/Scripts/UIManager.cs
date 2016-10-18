using UnityEngine;
using UnityEngine.UI;

public sealed class UIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas P1Canvas;

    [SerializeField]
    private Canvas P2Canvas;

    [SerializeField]
    private Text P1Scoretext;
    [SerializeField]
    private Text P2Scoretext;

    [SerializeField]
    private static Text P1Victorytext;
    [SerializeField]
    private static Text P2Victorytext;

    private static float p1Score;
    private static float p2Score;

    public static float P1Score
    {
        get
        {
            return p1Score;
        }

        set
        {
            p1Score = value;
        }
    }

    public static float P2Score
    {
        get
        {
            return p2Score;
        }

        set
        {
            p2Score = value;
        }
    }

    void Start ()
    {
        if (P1Canvas == null)
            P1Canvas = GameObject.Find("P1Canvas").GetComponent<Canvas>();

        if (P2Canvas == null)
            P2Canvas = GameObject.Find("P2Canvas").GetComponent<Canvas>();

        if(P1Scoretext == null)
            P1Scoretext = P1Canvas.GetComponentsInChildren<Text>()[1];

        if(P2Scoretext == null)
            P2Scoretext = P2Canvas.GetComponentsInChildren<Text>()[1];

        if (P1Victorytext == null)
            P1Victorytext = P1Canvas.GetComponentsInChildren<Text>()[2];

        if (P2Victorytext == null)
            P2Victorytext = P2Canvas.GetComponentsInChildren<Text>()[2];

        p1Score = 0;
        p2Score = 0;
    }
	
	void Update ()
    {
        P1Scoretext.text = "Score: " + p1Score.ToString();
        P2Scoretext.text = "Score: " + p2Score.ToString();
    }

    public static void CheckForVictory()
    {
        if (p1Score >= 2)
        {
            P1Victorytext.text = "You Win!";
            P2Victorytext.text = "You Lose!";
        }
            

        if (p2Score >= 2)
        {
            P2Victorytext.text = "You Win!";
            P1Victorytext.text = "You Lose!";
        }
            
    }
}
