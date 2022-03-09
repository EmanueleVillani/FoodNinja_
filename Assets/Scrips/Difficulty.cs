using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    private GameManager gm;
    public int difficulty;
   
    
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
       
        Debug.Log(button.gameObject.name + "sto premendo");
        gm.StartGame(difficulty);
        
    }
}
