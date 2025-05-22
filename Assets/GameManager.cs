using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public TMP_Text gameOverText;
    public Button restartButton;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public static GameManager Instance;

    private int score = 0;
    private int highScore = 0;

    private void Awake()
    {
        Instance = this;

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);

        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        UpdateScoreUI();
    }

    private void Update()
    {
        if (gameOverText.gameObject.activeSelf && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
    }

    public void GameOver()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        UpdateScoreUI();

        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
