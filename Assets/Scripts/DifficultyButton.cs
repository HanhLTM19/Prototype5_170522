using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button m_button;
    private GameController gameController;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        m_button = GetComponent<Button>();
        m_button.onClick.AddListener(SetDifficulty);
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }
    void SetDifficulty()
    {
        gameController.StartGame(difficulty);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
