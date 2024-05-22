using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameover;
    public int score;
    private Vector3 playerStartPosition;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        playerStartPosition = player.transform.position; // Store the initial player position
        gameover.SetActive(false);
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        gameover.SetActive(false);
        playButton.SetActive(false);
        Time.timeScale = 1f;
        player.transform.position = playerStartPosition; // Reset player position
        player.enabled = true;

        // Destroy all existing pipes
        pipes[] existingPipes = FindObjectsOfType<pipes>();
        for (int i = 0; i < existingPipes.Length; i++)
        {
            Destroy(existingPipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameover.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
