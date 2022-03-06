using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosion;
    private GameManager gm;
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private float maxTorque = 10;
    public int pointValue;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);//far saltare gli oggetti in alto
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);// creare doppi oggetti spawnare
        transform.position = RandomSpawnPos(); // la possizione dove spawnare gli oggetti
    }


    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (gm.isGameActive)
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);

            gm.UpDateScore(pointValue);
        }

    }
    public void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gm.GameOver();
        }


    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(maxTorque, -maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(xRange, -xRange), ySpawnPos);
    }
}
