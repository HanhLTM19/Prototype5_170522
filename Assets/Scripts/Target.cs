using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float minSpeed = 5;
    //private float maxSpeed = 8;
    private float maxRotate = 30;
    private float rangeX = 4;
    private float spawnPosY = -1;
    private float m_rotate;

    GameController gameController;
    public int pointValue;
    public ParticleSystem explosionParticle;

    //private Transform childTransform;

    //Bien dung cho cach 3
    public float maxSpeed;
    public float timeZeroToMax;
    float m_acceleration;
    public float forwardVelocity;
    Vector3 m_translate;
    Vector3 m_direction;

    // Start is called before the first frame update
    void Start()
    {
        /* Cach 1
         targetRb = GetComponent<Rigidbody>();
         targetRb.AddForce(RandomForce(), ForceMode.Impulse);
         targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
         transform.position = RandomSpawnPos();*/

        /* Cach 2
        //xu ly di chuyen
        transform.position = RandomSpawnPos();
        m_rotate = RandomRotate();
        childTransform = transform.Find("Prop"); // tim doi tuong con*/
        transform.position = RandomSpawnPos();
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();


        // Cach 3
        m_acceleration = maxSpeed / timeZeroToMax;
        forwardVelocity = 0f;
        m_direction = new Vector3(Random.Range(-1, 1), 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /* cach 1
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();*/

        /* Cach 2
        transform.Translate(Vector3.up * Time.deltaTime * RandomSpeed()); // parent bay len
        transform.Rotate(Vector3.forward, Time.deltaTime * m_rotate);

        childTransform.Rotate(Vector3.right * Time.deltaTime * 50); // child xoay*/

        //cach 3
        
    }
    private void FixedUpdate()
    {
        forwardVelocity += m_acceleration * Time.deltaTime;
        forwardVelocity = Mathf.Min(forwardVelocity, maxSpeed);
        //transform.Translate(Vector3.forward * forwardVelocity);

        m_translate = transform.position + m_direction * forwardVelocity * Time.deltaTime;
        transform.Rotate(new Vector3(1, 1, 0) * Time.deltaTime * 40);
        transform.SetPositionAndRotation(m_translate, transform.rotation);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameController.UpdateLives();
        }
    }*/
    public void DestroyTarget()
    {
        if (!gameController.IsGameOver())
        {
            Destroy(gameObject);
            gameController.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }
   
    float RandomRotate()
    {
        return Random.Range(-maxRotate, maxRotate);
    }
    /*Vector3 RandomForce()
   {
       return Vector3.up * Random.Range(minSpeed, maxSpeed);
   }
   Vector3 RandomSpawnPos()
   {
       return new Vector3(Random.Range(-rangeX, rangeX), spawnPosY);
   }*/
    float RandomSpeed()
    {
        return Random.Range(minSpeed, maxSpeed);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-rangeX, rangeX), spawnPosY, 0);
    }
   

}
