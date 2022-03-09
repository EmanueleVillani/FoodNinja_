using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI textGameOver;
    public float spawnRate = 1.5f;
    public List<GameObject> targets;
    public bool isGameActive ;
    public GameObject restarBotton;
    public GameObject titleScreen;

    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {


        while (isGameActive)
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

    public void GameOver()
    {
        restarBotton.gameObject.SetActive(true);
        textGameOver.gameObject.SetActive(true);
        isGameActive = false;
       
    }

    public void RestartButton()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate = spawnRate / difficulty;
        isGameActive = true;
        score = 0;

        UpDateScore(0);

        StartCoroutine(SpawnTarget());
        titleScreen.SetActive(false);
    }
}
