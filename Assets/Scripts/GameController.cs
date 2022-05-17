using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 3.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int m_score;
    private bool m_isGameOver;
    public GameObject titleScreen;
    public int maxLive;
    // Start is called before the first frame update
    void Start()
    {
        /*StartCoroutine(SpawnTarget());
        m_score = 0;
        UpdateScore(0);*/
    }
    public void StartGame(int difficulty)
    {
        maxLive = 3;
        spawnRate /= difficulty;
        SetIsGameOver(false);
        StartCoroutine(SpawnTarget());
        m_score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        livesText.gameObject.SetActive(true);
        livesText.text = "Lives: " + maxLive;

    }
    // Update is called once per frame
    void Update()
    {
       if (IsGameOver())
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            livesText.gameObject.SetActive(false);
            SetIsGameOver(true);

            return;
            
        }
    }
    IEnumerator SpawnTarget()
    {
        while (IsGameOver()== false)
        {
            yield return new WaitForSeconds(spawnRate - Time.deltaTime);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
       
    }

    public void UpdateScore (int score)
    {
        m_score += score;
        scoreText.text = "Score: " + m_score;
    }
   
    public void SetIsGameOver (bool state)
    {
        m_isGameOver = state;
    }
    public bool IsGameOver()
    {
        return m_isGameOver;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateLives(int num)
    {
        maxLive = num;
        livesText.text = "Lives: " + maxLive;
    }
    public int GetLives()
    {
        return maxLive;
    }
}
