using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private static Button MainMenuButton;
    private static Button PlayAgainButton;
    [SerializeField]
    private static Text PlayAgaintext;
    [SerializeField]
    private static Text MainMenutext;

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

        if (PlayAgaintext == null)
            PlayAgaintext = P1Canvas.GetComponentsInChildren<Text>()[3];

        if (PlayAgainButton == null)
            PlayAgainButton = P1Canvas.GetComponentsInChildren<Button>()[0];

        if (MainMenuButton == null)
            MainMenuButton = P2Canvas.GetComponentsInChildren<Button>()[0];

        if (MainMenutext == null)
            MainMenutext = P2Canvas.GetComponentsInChildren<Text>()[3];

        PlayAgainButton.interactable = false;
        MainMenuButton.interactable = false;

        p1Score = 0;
        p2Score = 0;

        P1Victorytext.text = "5 points wins";
        P2Victorytext.text = "5 points wins";
    }
	
	void Update ()
    {
        P1Scoretext.text = "Score: " + p1Score.ToString();
        P2Scoretext.text = "Score: " + p2Score.ToString();
    }

    public static void CheckForVictory()
    {
        if (p1Score >= 5)
        {
            Time.timeScale = 0;
            P1Victorytext.text = "You Win!";
            P2Victorytext.text = "You Lose!";
            PlayAgainButton.interactable = true;
            PlayAgaintext.text = "Play Again?";
            MainMenuButton.interactable = true;
            MainMenutext.text = "Main Menu";
        }
            
        if (p2Score >= 5)
        {
            Time.timeScale = 0;
            P2Victorytext.text = "You Win!";
            P1Victorytext.text = "You Lose!";
            PlayAgainButton.interactable = true;
            PlayAgaintext.text = "Play Again?";
            MainMenuButton.interactable = true;
            MainMenutext.text = "Main Menu";
        }
            
    }

    public void PlayAgainClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
