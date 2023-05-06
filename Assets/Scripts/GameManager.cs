using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Ready,
        Playing,
        GameOver
    }

    public Player player;
    private Spawner spawner;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
    private int score;
    private GameState currentState = GameState.Ready;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        SetState(GameState.Ready);
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

        SetState(GameState.Playing);
    }

    public void GameOver()
    {
        SetState(GameState.GameOver);
    }

    public void Pause()
    {
        SetState(GameState.Ready);
    }

    private void SetState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.Ready:
                Time.timeScale = 0f;
                player.enabled = false;
                playButton.SetActive(true);
                gameOver.SetActive(false);
                getReady.SetActive(true);
                break;

            case GameState.Playing:
                Time.timeScale = 1f;
                player.enabled = true;
                playButton.SetActive(false);
                gameOver.SetActive(false);
                getReady.SetActive(false);
                break;

            case GameState.GameOver:
                Time.timeScale = 0f;
                player.enabled = false;
                playButton.SetActive(true);
                gameOver.SetActive(true);
                getReady.SetActive(false);
                break;
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}