using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string sceneName = "Menu";
    public float startingSpeed = 2.5f;
    public Text gameOverText;

    public static float speed;
    public static int score = 0;
    private static int highScore = 0;
    public static bool gameOver = false;
    
    // Use this for initialization
    void Start()
    {
        speed = startingSpeed;
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highScore)
        {
            highScore = score;
        }

        if (gameOver)
        {
            gameOverText.text = "Game Over\nPress space to back Menu";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOver = false;
                score = 0;
                Application.LoadLevel(sceneName);
            }
        }

        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 120, 20), "Score: " + score.ToString());
        GUI.Label(new Rect(0, 20, 120, 20), "Hi Score: " + highScore.ToString());
    }
}
