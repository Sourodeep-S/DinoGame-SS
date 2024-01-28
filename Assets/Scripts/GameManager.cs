using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;
  public float initialGameSpeed = 5f;
  public float gameSpeedIncrease = 0.2f;
  public float gameSpeed { get; private set; }

  private Player player;
  private Spawner spawner;

  public TextMeshProUGUI gameOverText;
  public Button retryButton;

  private void Awake()
  {
    if (Instance == null)
      Instance = this;
    else
      DestroyImmediate(gameObject);
  }

  private void OnDestroy()
  {
    if (Instance == this)
      Instance = null;
  }

  private void Start()
  {
    player = FindAnyObjectByType<Player>();
    spawner = FindAnyObjectByType<Spawner>();

    NewGame();
  }

  private void Update()
  {
    gameSpeed += gameSpeedIncrease * Time.deltaTime;
  }

  public void NewGame()
  {
    Obstacle[] obstacles = FindObjectsByType<Obstacle>(FindObjectsSortMode.None);

    foreach (var obs in obstacles)
    {
      Destroy(obs.gameObject);
    }

    gameSpeed = initialGameSpeed;
    enabled = true;

    player.gameObject.SetActive(true);
    spawner.gameObject.SetActive(true);
    gameOverText.gameObject.SetActive(false);
    retryButton.gameObject.SetActive(false);
  }

  public void GameOver()
  {
    gameSpeed = 0f;
    enabled = false;

    player.gameObject.SetActive(false);
    spawner.gameObject.SetActive(false);
    gameOverText.gameObject.SetActive(true);
    retryButton.gameObject.SetActive(true);
  }

}
