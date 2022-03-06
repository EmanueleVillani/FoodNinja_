using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public float spawnRate = 1.5f;
    public List<GameObject> targets;
    void Start()
    {
        score = 0;
        UpDateScore(0);
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
           
        }
        
    }
    public void UpDateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score " + score;
    }
}
