using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float minSpeed = 5;
    private float maxSpeed = 8;
    private float maxRotate = 30;
    private float rangeX = 4;
    private float spawnPosY = -1;
    private float m_rotate;

    GameController gameController;
    public int pointValue;
    public ParticleSystem explosionParticle;

    private Transform childTransform;

    // Start is called before the first frame update
    void Start()
    {
        /* targetRb = GetComponent<Rigidbody>();
         targetRb.AddForce(RandomForce(), ForceMode.Impulse);
         targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
         transform.position = RandomSpawnPos();*/

        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        //xu ly di chuyen
        transform.position = RandomSpawnPos();
        m_rotate = RandomRotate();
        childTransform = transform.Find("Prop"); // tim doi tuong con
    }

    // Update is called once per frame
    void Update()
    {
        /* targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();*/

        transform.Translate(Vector3.up * Time.deltaTime * RandomSpeed()); // parent bay len
        transform.Rotate(Vector3.forward, Time.deltaTime * m_rotate);

        childTransform.Rotate(Vector3.right * Time.deltaTime * 50); // child xoay

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameController.UpdateLives();
        }
    }
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
