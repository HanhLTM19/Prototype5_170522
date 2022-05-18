using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndSwipe : MonoBehaviour
{
    GameController gameController;
    // bien dung xu ly keo tha chuot
    Camera m_camera;
    Vector3 mousePos;
    private TrailRenderer m_trail;
    private BoxCollider boxCollider;

    private bool swiping = false;
    // Start is called before the first frame update
    void Awake()
    {
        m_camera = Camera.main;
        //m_event = Event.current;
        m_trail = GetComponent<TrailRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        m_trail.enabled = false;
        boxCollider.enabled = false;

        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.IsGameOver())
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            } 
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }
            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }
    void UpdateMousePosition()
    {
        mousePos = m_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }
    void UpdateComponents()
    {
        m_trail.enabled = swiping;
        boxCollider.enabled = swiping;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            if (collision.gameObject.CompareTag("Bad"))
            {
                gameController.UpdateLives();
            }
            // Destroy target
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
    
}
