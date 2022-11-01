using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerSprite playerSprite;
    public Text countText; // text for in-game overlay
    public GameObject gameOverUI; // panel for end game
    public Text gameOverText; // text over end-game panel
    public int points;

    private bool gameOver = false;
    private bool fadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

        points = 0;
        countText.text = "Gold Collected: " + points.ToString();

        if (gameOver == true && Input.GetKeyDown("R"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSprite.gameEndingCollision)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            gameOverUI.SetActive(true);
            gameOverText.text = "GAMEOVER!" + "\n" + "Score - " + points.ToString() + "\n" + "PRESS 'R' TO RESTART...";
            fadeOut = true;
            Fade();
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameScene");
            Debug.Log("GAME RESTARTED!");
        }
    }

    private void Fade()
    {
        if (fadeOut)
        {
            if(gameOverUI.GetComponent<CanvasGroup>().alpha >= 0)
            {
                gameOverUI.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
                
                if (gameOverUI.GetComponent<CanvasGroup>().alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
