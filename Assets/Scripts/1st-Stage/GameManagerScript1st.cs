using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript1st : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject goalText;
    public Text scoreText; // Not GameObject because has to change the word
    private const int MAX_SCORE = 9999;
    private int score = 0;
    
    // SE
    public AudioClip gameClearSe;
    public AudioClip gameOverSe;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        audioSource.PlayOneShot(gameOverSe); // play once
    }

    public void Goal()
    {
        goalText.SetActive(true);
        audioSource.PlayOneShot(gameClearSe);
    }

    // public void addScore() // Not good. Obey Coding regulation that function name's first character is Capital Letter
    public void AddScore(int value)
    {
        // score += 100;
        score += value; // Change additional score depends an item the player got
        if (score > MAX_SCORE)
        {
            score = MAX_SCORE;
        }

        // scoreText.text = score; // score is INT. Needs to convert to String by ToString()
        scoreText.text = score.ToString();
    }
}
