using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public List<GameObject> targets; // danh sach vat sinh ngau nhien

    private float spawnRate = 3.0f; // toc do phat sinh ngau nhien

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;
    
    public Button restartButton;
    public Button continueButton;
    public Button volumeButton;
    public Slider sliderVolume;
    public RawImage imageVolume;
    public Texture imageOnSound;
    public Texture imageMuteSound;

    public GameObject titleScreen;

    public int maxLive;
    private int m_score;

    //cac bien flag
    private bool m_isPause;
    private bool m_isStart;
    private bool m_isGameOver;
    private bool m_isShow;

    private float timer = 60;

    // Start is called before the first frame update
    void Start()
    {
        sliderVolume.value = 1;
       
    }
    public void StartGame(int difficulty)
    {
        m_isStart = true;
        m_isPause = false;
        m_isShow = false;
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
        timerText.gameObject.SetActive(true);
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
            livesText.gameObject.SetActive(true);
            timerText.gameObject.SetActive(false);
            SetIsGameOver(true);

            return;
            
        }
       if (m_isStart)
        {
            IsPause();
            CountdownTimer();
        }
        

    }
    public void CountdownTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            SetIsGameOver(true);
        }
        timerText.text = "Time: " + timer.ToString("0");
    }
    public void IsPause()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !m_isGameOver)
        {
            ContinueGame();
        }
    }
    public void ContinueGame()
    {
        if (m_isPause)
        {
            Time.timeScale = 1.0f;
            m_isPause = false;
            continueButton.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            m_isPause = true;
            continueButton.gameObject.SetActive(true);
        }
    }
    public void SetVolume ()
    {
        
        if (m_isShow)
        {
            sliderVolume.gameObject.SetActive(false);
            m_isShow = false;
        }
        else
        {
            sliderVolume.gameObject.SetActive(true);
            m_isShow = true;
        }
        
    }
    public void IsMute()
    {
        if (sliderVolume.value == 0)
        {
            imageVolume.texture = imageMuteSound;
        }
        else
        {
            imageVolume.texture = imageOnSound;
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    public void UpdateLives()
    {
        if (maxLive > 1)
        {
            maxLive = maxLive - 1;
        }
        else
        {
            maxLive = 0;
            SetIsGameOver(true);
        }
        livesText.text = "Live: " + maxLive;
        
        
    }
    public int GetLives()
    {
        return maxLive;
    }
}
