using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image timerImage;
    public TMP_Text timerText;
    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Timer
        GameManager.gameManager.ResetTimer();
        timerText.text = "Hello World";

        // Other
    }

    // Update is called once per frame
    void Update()
    {
        // Timer Schenanigans
        if ( GameManager.gameManager.timeRemaining > 0 ) {
            UpdateTimer();
        } else {
            GameManager.gameManager.timeRemaining = 0;
        }

        // Score
        UpdateScore();
    }

    // Timer
    void UpdateTimer ()
    {
        GameManager.gameManager.timeRemaining -= Time.deltaTime;
        timerImage.fillAmount = GameManager.gameManager.timeRemaining / GameManager.gameManager.maxTime;
        float displayTimeRemaining = Mathf.Floor(GameManager.gameManager.timeRemaining);
        timerText.text = "Time Remaining: " + GameManager.gameManager.timeRemaining;
    }

    // Score
    void UpdateScore ()
    {
        scoreText.text = "Score: " + GameManager.gameManager.score;
    }
}
