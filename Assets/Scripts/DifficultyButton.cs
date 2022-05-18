using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button m_button;
    private GameController gameController;
    public int difficulty;
    //public ColorBlock colorClick;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        m_button = GetComponent<Button>();
        m_button.onClick.AddListener(SetDifficulty);
        
    }
    void SetDifficulty()
    {
        gameController.StartGame(difficulty);
       // m_button.colors = colorClick;

    }
    // Update is called once per frame
    void Update()
    {
    }
}
