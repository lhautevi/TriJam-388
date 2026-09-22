using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform player;
    private Vector2 respawnPoint;
    public float timeLeft = 180f;
    public TextMeshProUGUI timerText;
    private bool gameEnded = false;
    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        respawnPoint = player.position;
    }

    public void Update()
    {
        if (!gameEnded)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                timerText.text = "GAME OVER\n Tap R to Restart";
                gameEnded = true;
                return;
            }
            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.FloorToInt(timeLeft % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void OnPlayerDied()
    {
        player.position = respawnPoint;
        AudioManager.Instance.PlayRandomSound( AudioManager.Instance.deathSounds);
    }
    
    public void OnPlayerWon()
    {
        gameEnded = true;
        timerText.text = "YOU WIN !";
    }
}
